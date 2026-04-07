using SolarPark_FieldSimulator.Domain;

namespace SolarPark_FieldSimulator.Infrastructure.Modbus
{
    /// <summary>
    /// This service has two responsibilities:
    /// 1. publish simulator state outward
    /// 2. read external command inputs inward
    /// </summary>
    public interface IModbusServerService
    {
        void Start(int port = 502, byte unitId = 1);
        void Stop();

        void UpdateFromSimulation(SimulationState state);

        CommandInputs ReadCommandInputs();
    }
}
