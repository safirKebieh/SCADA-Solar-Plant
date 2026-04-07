namespace SolarPark_FieldSimulator.Domain
{
    public class SimulationState
    {
        public SimulationMode Mode { get; set; } = SimulationMode.Auto;
        public PlantStatus PlantStatus { get; set; } = PlantStatus.Stopped;
        public PlantInputs Inputs { get; set; } = new PlantInputs();
        public FaultInputs Faults { get; set; } = new FaultInputs();
        public PowerData Power { get; set; } = new PowerData();
        public EnergyData Energy { get; set; } = new EnergyData();
        public CommunicationData Communication { get; set; } = new CommunicationData();
        public DateTime SimulatedTime { get; set; } = DateTime.Today.AddHours(12);
    }
}
