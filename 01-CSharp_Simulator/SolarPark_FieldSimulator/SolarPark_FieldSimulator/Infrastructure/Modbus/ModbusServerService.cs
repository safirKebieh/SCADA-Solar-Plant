using NModbus;
using SolarPark_FieldSimulator.Domain;
using System.Net;
using System.Net.Sockets;

namespace SolarPark_FieldSimulator.Infrastructure.Modbus
{
    /// <summary>
    /// Concrete Modbus TCP server implementation.
    ///
    /// This class owns the NModbus slave network and datastore.
    ///
    /// Responsibilities:
    /// - expose simulator outputs through Modbus
    /// - read external command values from Modbus
    /// </summary>
    public class ModbusServerService : IModbusServerService
    {
        private TcpListener? _listener;
        private IModbusSlaveNetwork? _slaveNetwork;
        private IModbusSlave? _slave;
        private bool _isRunning;
        private readonly object _dataLock = new();

        public void Start(int port = 502, byte unitId = 1)
        {
            if (_isRunning)
                return;

            var factory = new ModbusFactory();

            _listener = new TcpListener(IPAddress.Any, port);
            _listener.Start();

            _slaveNetwork = factory.CreateSlaveNetwork(_listener);
            _slave = factory.CreateSlave(unitId);
            _slaveNetwork.AddSlave(_slave);

            _isRunning = true;

            _ = Task.Run(async () =>
            {
                try
                {
                    await _slaveNetwork.ListenAsync();
                }
                catch
                {
                    _isRunning = false;
                }
            });
        }

        public void Stop()
        {
            try
            {
                _listener?.Stop();
            }
            catch
            {
            }

            _isRunning = false;
        }

        public void UpdateFromSimulation(SimulationState state)
        {
            if (!_isRunning || _slave?.DataStore == null)
                return;

            var outputCoils = ModbusDataMapper.MapOutputCoils(state);
            var holdingRegisters = ModbusDataMapper.MapHoldingRegisters(state);

            lock (_dataLock)
            {
                // Write only simulator output coils 0..5
                _slave.DataStore.CoilDiscretes.WritePoints(ModbusRegisterMap.GridAvailable, outputCoils);

                // Write simulator holding registers starting at 0
                _slave.DataStore.HoldingRegisters.WritePoints(ModbusRegisterMap.PlantStatus, holdingRegisters);
            }
        }

        public CommandInputs ReadCommandInputs()
        {
            if (!_isRunning || _slave?.DataStore == null)
                return new CommandInputs();

            lock (_dataLock)
            {
                // Read enough coils to include command addresses 8..12
                var coilSnapshot = _slave.DataStore.CoilDiscretes.ReadPoints(0, 16).ToArray();

                // Reserved for future command registers if needed
                var registerSnapshot = _slave.DataStore.HoldingRegisters.ReadPoints(0, 10).ToArray();

                return ModbusDataMapper.MapCommandInputs(coilSnapshot, registerSnapshot);
            }
        }
    }
}