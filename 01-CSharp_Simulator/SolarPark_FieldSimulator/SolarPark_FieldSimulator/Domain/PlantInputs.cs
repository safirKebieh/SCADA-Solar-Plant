namespace SolarPark_FieldSimulator.Domain
{
    public class PlantInputs
    {
        public bool GridAvailable { get; set; }
        public bool InverterAvailable { get; set; }
        public bool InverterEnabled { get; set; } = true;
        public bool PlantEnabled { get; set; } = true;
        public WeatherData Weather { get; set; } = new WeatherData();
    }
}