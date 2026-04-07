namespace SolarPark_FieldSimulator.Domain
{
    public class FaultInputs
    {
        // Fault sources from simulator GUI
        public bool GridFaultInjected { get; set; }
        public bool InverterFaultInjected { get; set; }
        public bool SensorFaultInjected { get; set; }

        // Latched/active plant faults
        public bool GridFaultActive { get; set; }
        public bool InverterFaultActive { get; set; }
        public bool SensorFaultActive { get; set; }
    }
}