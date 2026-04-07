using SolarPark_FieldSimulator.Domain;

namespace SolarPark_FieldSimulator.Simulation
{
    public interface ISimulationService
    {
        SimulationState State { get; }

        void Initialize();
        void Tick(TimeSpan deltaTime);
        void SetMode(SimulationMode mode);
        void SetManualIrradiance(double irradianceWm2);
        void SetFaults(bool gridFault, bool inverterFault, bool sensorFault);
        void RefreshAfterResetRequest();
        void ResetFaults();
        void EnableInverter();
        void DisableInverter();
        void StartPlant();
        void StopPlant();
    }
}