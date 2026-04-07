namespace SolarPark_FieldSimulator.Infrastructure.Modbus
{
    /// <summary>
    /// Central address map for Modbus data.
    ///
    /// DESIGN RULE:
    /// - Simulator outputs are written by the C# simulator.
    /// - Command inputs are written by PLC/SCADA and read by the simulator.
    /// </summary>
    public static class ModbusRegisterMap
    {
        // =========================================================
        // COILS
        // =========================================================

        // OUTPUT COILS (C# → PLC/SCADA)
        public const ushort GridAvailable = 0;
        public const ushort InverterAvailable = 1;
        public const ushort GridFaultActive = 2;
        public const ushort InverterFaultActive = 3;
        public const ushort SensorFaultActive = 4;
        public const ushort CommunicationHealthy = 5;

        // 6..7 reserved

        // INPUT COMMAND COILS (PLC/SCADA → C#)
        public const ushort CmdPlantRun = 8;          
        public const ushort CmdInverterEnable = 9;    
        public const ushort CmdResetFault = 10;       

        // 11..15 reserved

        // =========================================================
        // HOLDING REGISTERS (C# → PLC/SCADA)
        // =========================================================

        public const ushort PlantStatus = 0;          
        public const ushort IrradianceWm2 = 1;
        public const ushort AmbientTempC = 2;         
        public const ushort ModuleTempC = 3;          
        // 4 reserved
        public const ushort DcPowerKw = 5;            
        public const ushort AcPowerKw = 6;            
        public const ushort DailyEnergyKwh = 7;       
        public const ushort TotalEnergyKwh = 8;       
        public const ushort HeartbeatCounter = 9;
    }
}