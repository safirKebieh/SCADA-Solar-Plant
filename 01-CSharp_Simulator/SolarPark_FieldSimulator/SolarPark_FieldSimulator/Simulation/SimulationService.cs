using SolarPark_FieldSimulator.Domain;

namespace SolarPark_FieldSimulator.Simulation
{
    public class SimulationService : ISimulationService
    {
        public SimulationState State { get; private set; } = new SimulationState();

        private const double MinIrradianceForProduction = 50.0;

        public void Initialize()
        {
            SetDefaultOperatingMode();
            SetDefaultEquipmentAvailability();
            SetDefaultWeather();
            SetDefaultSimulatedTime();

            RefreshState();
        }

        public void Tick(TimeSpan deltaTime)
        {
            if (State.Mode == SimulationMode.Auto)
            {
                RunAutoSimulationStep(deltaTime);
            }

            RefreshState();
            UpdateEnergy(deltaTime);
            UpdateCommunication();
        }

        public void SetMode(SimulationMode mode)
        {
            State.Mode = mode;
        }

        public void SetManualIrradiance(double irradianceWm2)
        {
            if (State.Mode != SimulationMode.Manual)
                return;

            State.Inputs.Weather.IrradianceWm2 = irradianceWm2;

            State.Inputs.Weather.AmbientTempC = 15 + (irradianceWm2 / 1000.0) * 15;
            State.Inputs.Weather.ModuleTempC = State.Inputs.Weather.AmbientTempC + 5;

            RefreshState();
        }

        public void SetFaults(bool gridFault, bool inverterFault, bool sensorFault)
        {
            State.Faults.GridFaultInjected = gridFault;
            State.Faults.InverterFaultInjected = inverterFault;
            State.Faults.SensorFaultInjected = sensorFault;

            if (gridFault)
                State.Faults.GridFaultActive = true;
            else
                State.Faults.GridFaultActive = false;

            if (inverterFault)
                State.Faults.InverterFaultActive = true;
            else
                State.Faults.InverterFaultActive = false;

            if (sensorFault)
                State.Faults.SensorFaultActive = true;
            else
                State.Faults.SensorFaultActive = false;

                RefreshState();
        }

        private void RunAutoSimulationStep(TimeSpan deltaTime)
        {
            UpdateTime(deltaTime);
            UpdateWeatherFromSimulatedTime();
        }

        private void SetDefaultOperatingMode()
        {
            State.Mode = SimulationMode.Auto;
            State.PlantStatus = PlantStatus.Stopped;
        }

        private void SetDefaultEquipmentAvailability()
        {
            State.Inputs.GridAvailable = true;
            State.Inputs.InverterAvailable = true;
            State.Inputs.InverterEnabled = false;
            State.Inputs.PlantEnabled = false;
        }

        private void SetDefaultWeather()
        {
            State.Inputs.Weather.IrradianceWm2 = 800;
            State.Inputs.Weather.AmbientTempC = 25;
            State.Inputs.Weather.ModuleTempC = 30;
        }

        private void SetDefaultSimulatedTime()
        {
            State.SimulatedTime = DateTime.Today.AddHours(12);
        }

        private void UpdateTime(TimeSpan deltaTime)
        {
            State.SimulatedTime = State.SimulatedTime.AddMinutes(deltaTime.TotalSeconds);
        }

        private void UpdateWeatherFromSimulatedTime()
        {
            double hour = State.SimulatedTime.Hour + State.SimulatedTime.Minute / 60.0;

            // Irradiance(W/m²) = max(0, sin((hour - 6) / 12 × π)) × 1000
            double irradiance = Math.Max(0, Math.Sin((hour - 6) / 12 * Math.PI)) * 1000;

            State.Inputs.Weather.IrradianceWm2 = irradiance;
            State.Inputs.Weather.AmbientTempC = 15 + (irradiance / 1000.0) * 15;
            State.Inputs.Weather.ModuleTempC = State.Inputs.Weather.AmbientTempC + 5;
        }

        private void ApplyFaults()
        {
            State.Inputs.GridAvailable = !State.Faults.GridFaultActive;
            State.Inputs.InverterAvailable = !State.Faults.InverterFaultActive;

            if (State.Faults.SensorFaultActive)
            {
                State.Inputs.Weather.IrradianceWm2 = 0;
                State.Inputs.Weather.AmbientTempC = 0;
                State.Inputs.Weather.ModuleTempC = 0;
            }
        }

        private void UpdatePlantStatus()
        {
            bool hasActiveFault =
                State.Faults.GridFaultActive ||
                State.Faults.InverterFaultActive ||
                State.Faults.SensorFaultActive;

            if (hasActiveFault)
            {
                State.PlantStatus = PlantStatus.Faulted;
                return;
            }

            if (!State.Inputs.PlantEnabled ||
                !State.Inputs.InverterEnabled ||
                !State.Inputs.GridAvailable ||
                !State.Inputs.InverterAvailable)
            {
                State.PlantStatus = PlantStatus.Stopped;
                return;
            }

            State.PlantStatus = PlantStatus.Running;
        }

        private void CalculatePower()
        {
            if (State.PlantStatus != PlantStatus.Running)
            {
                State.Power.DcPowerKw = 0;
                State.Power.AcPowerKw = 0;
                return;
            }

            if (State.Inputs.Weather.IrradianceWm2 < MinIrradianceForProduction)
            {
                State.Power.DcPowerKw = 0;
                State.Power.AcPowerKw = 0;
                return;
            }

            const double totalDcPeakKw = 7.36;
            const double inverterEff = 0.98;
            const double inverterAcLimitKw = 5.0;
            const double tempCoeffPerDeg = 0.0029;
            const double stcTemp = 25.0;

            double irradianceFactor = State.Inputs.Weather.IrradianceWm2 / 1000.0;
            double tempDelta = State.Inputs.Weather.ModuleTempC - stcTemp;
            double tempFactor = 1.0 - (tempDelta * tempCoeffPerDeg);

            if (tempFactor < 0)
                tempFactor = 0;

            double dcPower = totalDcPeakKw * irradianceFactor * tempFactor;
            double acPower = dcPower * inverterEff;

            if (acPower > inverterAcLimitKw)
                acPower = inverterAcLimitKw;

            if (dcPower < 0)
                dcPower = 0;

            if (acPower < 0)
                acPower = 0;

            State.Power.DcPowerKw = dcPower;
            State.Power.AcPowerKw = acPower;
        }

        private void UpdateEnergy(TimeSpan deltaTime)
        {
            double hours = deltaTime.TotalHours;
            double producedEnergyKwh = State.Power.AcPowerKw * hours;

            State.Energy.DailyEnergyKwh += producedEnergyKwh;
            State.Energy.TotalEnergyKwh += producedEnergyKwh;
        }

        private void UpdateCommunication()
        {
            if (State.Communication.HeartbeatCounter >= 999999)
                State.Communication.HeartbeatCounter = 0;
            else
                State.Communication.HeartbeatCounter++;

            State.Communication.CommunicationHealthy = true;
        }

        private void RefreshState()
        {
            ApplyFaults();
            UpdatePlantStatus();
            CalculatePower();
        }

        public void RefreshAfterResetRequest()
        {
            RefreshState();
        }

        public void ResetFaults()
        {
            if (State.Faults.GridFaultInjected ||
                State.Faults.InverterFaultInjected ||
                State.Faults.SensorFaultInjected)
            {
                return;
            }

            State.Faults.GridFaultActive = false;
            State.Faults.InverterFaultActive = false;
            State.Faults.SensorFaultActive = false;

            RefreshState();
        }

        public void EnableInverter()
        {
            State.Inputs.InverterEnabled = true;
            RefreshState();
        }

        public void DisableInverter()
        {
            State.Inputs.InverterEnabled = false;
            RefreshState();
        }

        public void StartPlant()
        {
            State.Inputs.PlantEnabled = true;
            RefreshState();
        }

        public void StopPlant()
        {
            State.Inputs.PlantEnabled = false;
            RefreshState();
        }
    }
}