using SolarPark_FieldSimulator.Domain;
using SolarPark_FieldSimulator.Infrastructure.Modbus;
using SolarPark_FieldSimulator.Simulation;

namespace SolarPark_FieldSimulator
{
    public partial class Form1 : Form
    {
        private readonly ISimulationService _simulationService;
        private readonly IModbusServerService _modbusServerService;

        private const int DefaultModbusPort = 1502;
        private const byte DefaultUnitId = 1;

        private CommandInputs _previousCommands = new CommandInputs();

        public Form1()
        {
            InitializeComponent();

            _simulationService = new SimulationService();
            _modbusServerService = new ModbusServerService();

            _simulationService.Initialize();
            _modbusServerService.Start(DefaultModbusPort, DefaultUnitId);
            _modbusServerService.UpdateFromSimulation(_simulationService.State);

            chkGridFault.CheckedChanged += FaultCheckbox_CheckedChanged;
            chkInverterFault.CheckedChanged += FaultCheckbox_CheckedChanged;
            chkSensorFault.CheckedChanged += FaultCheckbox_CheckedChanged;

            uiTimer.Start();
            UpdateUi();
        }

        private void UiTimer_Tick(object? sender, EventArgs e)
        {
            var commands = _modbusServerService.ReadCommandInputs() ?? new CommandInputs();

            // ResetFault should be pulse / rising-edge
            if (IsRisingEdge(commands.ResetFaultCommand, _previousCommands.ResetFaultCommand))
            {
                _simulationService.ResetFaults();
            }

            // PlantRunCommand is a continuous command state from PLC
            if (commands.PlantRunCommand)
            {
                _simulationService.StartPlant();
            }
            else
            {
                _simulationService.StopPlant();
            }

            // InverterEnableCommand is a continuous command state from PLC
            if (commands.InverterEnableCommand)
            {
                _simulationService.EnableInverter();
            }
            else
            {
                _simulationService.DisableInverter();
            }

            _previousCommands = commands;

            _simulationService.Tick(TimeSpan.FromSeconds(1));
            _modbusServerService.UpdateFromSimulation(_simulationService.State);

            UpdateUi();
        }

        private static bool IsRisingEdge(bool currentValue, bool previousValue)
        {
            return currentValue && !previousValue;
        }

        private void UpdateUi()
        {
            var state = _simulationService.State;

            lblTime.Text = $"Time: {state.SimulatedTime:HH:mm}";
            lblStatus.Text = $"Status: {state.PlantStatus}";
            lblMode.Text = $"Mode: {state.Mode}";

            lblIrradiance.Text = $"Irradiance: {state.Inputs.Weather.IrradianceWm2:F0} W/m²";
            lblAmbient.Text = $"Ambient Temp: {state.Inputs.Weather.AmbientTempC:F1} °C";
            lblModuleTemp.Text = $"Module Temp: {state.Inputs.Weather.ModuleTempC:F1} °C";

            lblGrid.Text = $"Grid Available: {(state.Inputs.GridAvailable ? "Yes" : "No")}";
            lblInverter.Text = $"Inverter Available: {(state.Inputs.InverterAvailable ? "Yes" : "No")}";

            lblDcPower.Text = $"DC Power: {state.Power.DcPowerKw:F2} kW";
            lblAcPower.Text = $"AC Power: {state.Power.AcPowerKw:F2} kW";

            lblDailyEnergy.Text = $"Daily Energy: {state.Energy.DailyEnergyKwh:F3} kWh";
            lblTotalEnergy.Text = $"Total Energy: {state.Energy.TotalEnergyKwh:F3} kWh";

            lblHeartbeat.Text = $"Heartbeat: {state.Communication.HeartbeatCounter}";
            lblCommHealthy.Text = $"Communication Healthy: {(state.Communication.CommunicationHealthy ? "Yes" : "No")}";
        }

        private void btnAutoMode_Click(object sender, EventArgs e)
        {
            _simulationService.SetMode(SimulationMode.Auto);
            _modbusServerService.UpdateFromSimulation(_simulationService.State);
            UpdateUi();
        }

        private void btnManualMode_Click(object sender, EventArgs e)
        {
            _simulationService.SetMode(SimulationMode.Manual);
            _modbusServerService.UpdateFromSimulation(_simulationService.State);
            UpdateUi();
        }

        private void btnApplyManual_Click(object sender, EventArgs e)
        {
            _simulationService.SetManualIrradiance((double)nudManualIrradiance.Value);
            _modbusServerService.UpdateFromSimulation(_simulationService.State);
            UpdateUi();
        }

        private void btnApplyFaults_Click(object sender, EventArgs e)
        {
            _simulationService.SetFaults(
                chkGridFault.Checked,
                chkInverterFault.Checked,
                chkSensorFault.Checked);

            _modbusServerService.UpdateFromSimulation(_simulationService.State);
            UpdateUi();
        }

        protected override void OnFormClosed(FormClosedEventArgs e)
        {
            uiTimer.Stop();
            _modbusServerService.Stop();

            base.OnFormClosed(e);
        }

        private void FaultCheckbox_CheckedChanged(object? sender, EventArgs e)
        {
            if (chkGridFault.Checked || chkInverterFault.Checked || chkSensorFault.Checked)
                return;

            _simulationService.SetFaults(false, false, false);
            _modbusServerService.UpdateFromSimulation(_simulationService.State);
            UpdateUi();
        }
    }
}