using SolarPark_FieldSimulator.Domain;
using System;

namespace SolarPark_FieldSimulator.Infrastructure.Modbus
{
    public static class ModbusDataMapper
    {
        public static bool[] MapOutputCoils(SimulationState state)
        {
            return new bool[]
            {
                state.Inputs.GridAvailable,               // 0
                state.Inputs.InverterAvailable,           // 1
                state.Faults.GridFaultActive,             // 2
                state.Faults.InverterFaultActive,         // 3
                state.Faults.SensorFaultActive,           // 4
                state.Communication.CommunicationHealthy  // 5
            };
        }

        public static ushort[] MapHoldingRegisters(SimulationState state)
        {
            var registers = new ushort[10];

            registers[ModbusRegisterMap.PlantStatus] = (ushort)state.PlantStatus;
            registers[ModbusRegisterMap.IrradianceWm2] = ToUShort(state.Inputs.Weather.IrradianceWm2);
            registers[ModbusRegisterMap.AmbientTempC] = ToUShort(state.Inputs.Weather.AmbientTempC * 10);
            registers[ModbusRegisterMap.ModuleTempC] = ToUShort(state.Inputs.Weather.ModuleTempC * 10);
            registers[ModbusRegisterMap.DcPowerKw] = ToUShort(state.Power.DcPowerKw * 100);
            registers[ModbusRegisterMap.AcPowerKw] = ToUShort(state.Power.AcPowerKw * 100);
            registers[ModbusRegisterMap.DailyEnergyKwh] = ToUShort(state.Energy.DailyEnergyKwh * 100);
            registers[ModbusRegisterMap.TotalEnergyKwh] = ToUShort(state.Energy.TotalEnergyKwh * 100);
            registers[ModbusRegisterMap.HeartbeatCounter] = ToUShort(state.Communication.HeartbeatCounter);

            return registers;
        }

        public static CommandInputs MapCommandInputs(bool[] coils, ushort[] registers)
        {
            return new CommandInputs
            {
                PlantRunCommand = GetCoilValue(coils, ModbusRegisterMap.CmdPlantRun),
                InverterEnableCommand = GetCoilValue(coils, ModbusRegisterMap.CmdInverterEnable),
                ResetFaultCommand = GetCoilValue(coils, ModbusRegisterMap.CmdResetFault)
            };
        }

        private static bool GetCoilValue(bool[] coils, ushort index)
        {
            if (coils == null || index >= coils.Length)
                return false;

            return coils[index];
        }

        private static ushort ToUShort(double value)
        {
            if (value < 0)
                return 0;

            if (value > ushort.MaxValue)
                return ushort.MaxValue;

            return (ushort)Math.Round(value);
        }
    }
}