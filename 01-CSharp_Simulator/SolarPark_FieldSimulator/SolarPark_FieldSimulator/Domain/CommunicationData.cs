namespace SolarPark_FieldSimulator.Domain
{
    public class CommunicationData
    {
        public int HeartbeatCounter { get; set; }
        public bool CommunicationHealthy { get; set; } = true;
    }
}
