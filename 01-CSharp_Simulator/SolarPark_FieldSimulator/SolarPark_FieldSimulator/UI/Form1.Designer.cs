namespace SolarPark_FieldSimulator
{
    partial class Form1
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            tableLayoutMain = new TableLayoutPanel();
            panelTop = new Panel();
            lblCommHealthy = new Label();
            lblHeartbeat = new Label();
            lblTime = new Label();
            lblStatus = new Label();
            lblMode = new Label();
            groupWeather = new GroupBox();
            lblIrradiance = new Label();
            chkSensorFault = new CheckBox();
            lblAmbient = new Label();
            lblModuleTemp = new Label();
            groupSystem = new GroupBox();
            lblTotalEnergy = new Label();
            lblDailyEnergy = new Label();
            lblAcPower = new Label();
            lblDcPower = new Label();
            lblGrid = new Label();
            chkInverterFault = new CheckBox();
            lblInverter = new Label();
            chkGridFault = new CheckBox();
            groupControls = new GroupBox();
            btnApplyFaults = new Button();
            btnAutoMode = new Button();
            btnManualMode = new Button();
            lblManualIrradiance = new Label();
            nudManualIrradiance = new NumericUpDown();
            btnApplyManual = new Button();
            uiTimer = new System.Windows.Forms.Timer(components);
            tableLayoutMain.SuspendLayout();
            panelTop.SuspendLayout();
            groupWeather.SuspendLayout();
            groupSystem.SuspendLayout();
            groupControls.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)nudManualIrradiance).BeginInit();
            SuspendLayout();
            // 
            // tableLayoutMain
            // 
            tableLayoutMain.ColumnCount = 1;
            tableLayoutMain.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tableLayoutMain.Controls.Add(panelTop, 0, 0);
            tableLayoutMain.Controls.Add(groupWeather, 0, 1);
            tableLayoutMain.Controls.Add(groupSystem, 0, 2);
            tableLayoutMain.Controls.Add(groupControls, 0, 3);
            tableLayoutMain.Dock = DockStyle.Fill;
            tableLayoutMain.Location = new Point(0, 0);
            tableLayoutMain.Name = "tableLayoutMain";
            tableLayoutMain.RowCount = 4;
            tableLayoutMain.RowStyles.Add(new RowStyle(SizeType.Absolute, 80F));
            tableLayoutMain.RowStyles.Add(new RowStyle(SizeType.Percent, 34F));
            tableLayoutMain.RowStyles.Add(new RowStyle(SizeType.Percent, 33F));
            tableLayoutMain.RowStyles.Add(new RowStyle(SizeType.Percent, 33F));
            tableLayoutMain.Size = new Size(900, 550);
            tableLayoutMain.TabIndex = 0;
            // 
            // panelTop
            // 
            panelTop.Controls.Add(lblCommHealthy);
            panelTop.Controls.Add(lblHeartbeat);
            panelTop.Controls.Add(lblTime);
            panelTop.Controls.Add(lblStatus);
            panelTop.Controls.Add(lblMode);
            panelTop.Dock = DockStyle.Fill;
            panelTop.Location = new Point(3, 3);
            panelTop.Name = "panelTop";
            panelTop.Padding = new Padding(10);
            panelTop.Size = new Size(894, 74);
            panelTop.TabIndex = 0;
            // 
            // lblCommHealthy
            // 
            lblCommHealthy.AutoSize = true;
            lblCommHealthy.Location = new Point(261, 30);
            lblCommHealthy.Name = "lblCommHealthy";
            lblCommHealthy.Size = new Size(154, 15);
            lblCommHealthy.TabIndex = 3;
            lblCommHealthy.Text = "Communication Healthy: --";
            // 
            // lblHeartbeat
            // 
            lblHeartbeat.AutoSize = true;
            lblHeartbeat.Location = new Point(261, 8);
            lblHeartbeat.Name = "lblHeartbeat";
            lblHeartbeat.Size = new Size(75, 15);
            lblHeartbeat.TabIndex = 3;
            lblHeartbeat.Text = "Heartbeat: --";
            // 
            // lblTime
            // 
            lblTime.AutoSize = true;
            lblTime.Location = new Point(10, 10);
            lblTime.Name = "lblTime";
            lblTime.Size = new Size(50, 15);
            lblTime.TabIndex = 0;
            lblTime.Text = "Time: --";
            // 
            // lblStatus
            // 
            lblStatus.AutoSize = true;
            lblStatus.Location = new Point(10, 30);
            lblStatus.Name = "lblStatus";
            lblStatus.Size = new Size(55, 15);
            lblStatus.TabIndex = 1;
            lblStatus.Text = "Status: --";
            // 
            // lblMode
            // 
            lblMode.AutoSize = true;
            lblMode.Location = new Point(10, 50);
            lblMode.Name = "lblMode";
            lblMode.Size = new Size(54, 15);
            lblMode.TabIndex = 2;
            lblMode.Text = "Mode: --";
            // 
            // groupWeather
            // 
            groupWeather.Controls.Add(lblIrradiance);
            groupWeather.Controls.Add(chkSensorFault);
            groupWeather.Controls.Add(lblAmbient);
            groupWeather.Controls.Add(lblModuleTemp);
            groupWeather.Dock = DockStyle.Fill;
            groupWeather.Location = new Point(3, 83);
            groupWeather.Name = "groupWeather";
            groupWeather.Padding = new Padding(10);
            groupWeather.Size = new Size(894, 153);
            groupWeather.TabIndex = 1;
            groupWeather.TabStop = false;
            groupWeather.Text = "Weather";
            // 
            // lblIrradiance
            // 
            lblIrradiance.AutoSize = true;
            lblIrradiance.Location = new Point(10, 25);
            lblIrradiance.Name = "lblIrradiance";
            lblIrradiance.Size = new Size(75, 15);
            lblIrradiance.TabIndex = 0;
            lblIrradiance.Text = "Irradiance: --";
            // 
            // chkSensorFault
            // 
            chkSensorFault.AutoSize = true;
            chkSensorFault.Location = new Point(608, 29);
            chkSensorFault.Name = "chkSensorFault";
            chkSensorFault.Size = new Size(90, 19);
            chkSensorFault.TabIndex = 5;
            chkSensorFault.Text = "Sensor Fault";
            chkSensorFault.UseVisualStyleBackColor = true;
            // 
            // lblAmbient
            // 
            lblAmbient.AutoSize = true;
            lblAmbient.Location = new Point(10, 50);
            lblAmbient.Name = "lblAmbient";
            lblAmbient.Size = new Size(102, 15);
            lblAmbient.TabIndex = 1;
            lblAmbient.Text = "Ambient Temp: --";
            // 
            // lblModuleTemp
            // 
            lblModuleTemp.AutoSize = true;
            lblModuleTemp.Location = new Point(10, 75);
            lblModuleTemp.Name = "lblModuleTemp";
            lblModuleTemp.Size = new Size(97, 15);
            lblModuleTemp.TabIndex = 2;
            lblModuleTemp.Text = "Module Temp: --";
            // 
            // groupSystem
            // 
            groupSystem.Controls.Add(lblTotalEnergy);
            groupSystem.Controls.Add(lblDailyEnergy);
            groupSystem.Controls.Add(lblAcPower);
            groupSystem.Controls.Add(lblDcPower);
            groupSystem.Controls.Add(lblGrid);
            groupSystem.Controls.Add(chkInverterFault);
            groupSystem.Controls.Add(lblInverter);
            groupSystem.Controls.Add(chkGridFault);
            groupSystem.Dock = DockStyle.Fill;
            groupSystem.Location = new Point(3, 242);
            groupSystem.Name = "groupSystem";
            groupSystem.Padding = new Padding(10);
            groupSystem.Size = new Size(894, 149);
            groupSystem.TabIndex = 2;
            groupSystem.TabStop = false;
            groupSystem.Text = "System";
            // 
            // lblTotalEnergy
            // 
            lblTotalEnergy.AutoSize = true;
            lblTotalEnergy.Location = new Point(272, 50);
            lblTotalEnergy.Name = "lblTotalEnergy";
            lblTotalEnergy.Size = new Size(88, 15);
            lblTotalEnergy.TabIndex = 7;
            lblTotalEnergy.Text = "Total Energy: --";
            // 
            // lblDailyEnergy
            // 
            lblDailyEnergy.AutoSize = true;
            lblDailyEnergy.Location = new Point(272, 23);
            lblDailyEnergy.Name = "lblDailyEnergy";
            lblDailyEnergy.Size = new Size(88, 15);
            lblDailyEnergy.TabIndex = 7;
            lblDailyEnergy.Text = "Daily Energy: --";
            // 
            // lblAcPower
            // 
            lblAcPower.AutoSize = true;
            lblAcPower.Location = new Point(13, 106);
            lblAcPower.Name = "lblAcPower";
            lblAcPower.Size = new Size(75, 15);
            lblAcPower.TabIndex = 6;
            lblAcPower.Text = "AC Power: --";
            // 
            // lblDcPower
            // 
            lblDcPower.AutoSize = true;
            lblDcPower.Location = new Point(13, 76);
            lblDcPower.Name = "lblDcPower";
            lblDcPower.Size = new Size(75, 15);
            lblDcPower.TabIndex = 6;
            lblDcPower.Text = "DC Power: --";
            // 
            // lblGrid
            // 
            lblGrid.AutoSize = true;
            lblGrid.Location = new Point(10, 25);
            lblGrid.Name = "lblGrid";
            lblGrid.Size = new Size(96, 15);
            lblGrid.TabIndex = 0;
            lblGrid.Text = "Grid Available: --";
            // 
            // chkInverterFault
            // 
            chkInverterFault.AutoSize = true;
            chkInverterFault.Location = new Point(608, 46);
            chkInverterFault.Name = "chkInverterFault";
            chkInverterFault.Size = new Size(95, 19);
            chkInverterFault.TabIndex = 5;
            chkInverterFault.Text = "Inverter Fault";
            chkInverterFault.UseVisualStyleBackColor = true;
            // 
            // lblInverter
            // 
            lblInverter.AutoSize = true;
            lblInverter.Location = new Point(10, 50);
            lblInverter.Name = "lblInverter";
            lblInverter.Size = new Size(114, 15);
            lblInverter.TabIndex = 1;
            lblInverter.Text = "Inverter Available: --";
            // 
            // chkGridFault
            // 
            chkGridFault.AutoSize = true;
            chkGridFault.Location = new Point(608, 21);
            chkGridFault.Name = "chkGridFault";
            chkGridFault.Size = new Size(77, 19);
            chkGridFault.TabIndex = 5;
            chkGridFault.Text = "Grid Fault";
            chkGridFault.UseVisualStyleBackColor = true;
            // 
            // groupControls
            // 
            groupControls.Controls.Add(btnApplyFaults);
            groupControls.Controls.Add(btnAutoMode);
            groupControls.Controls.Add(btnManualMode);
            groupControls.Controls.Add(lblManualIrradiance);
            groupControls.Controls.Add(nudManualIrradiance);
            groupControls.Controls.Add(btnApplyManual);
            groupControls.Dock = DockStyle.Fill;
            groupControls.Location = new Point(3, 397);
            groupControls.Name = "groupControls";
            groupControls.Padding = new Padding(10);
            groupControls.Size = new Size(894, 150);
            groupControls.TabIndex = 3;
            groupControls.TabStop = false;
            groupControls.Text = "Controls";
            // 
            // btnApplyFaults
            // 
            btnApplyFaults.Location = new Point(445, 72);
            btnApplyFaults.Name = "btnApplyFaults";
            btnApplyFaults.Size = new Size(228, 23);
            btnApplyFaults.TabIndex = 6;
            btnApplyFaults.Text = "Apply/Remove Faults";
            btnApplyFaults.UseVisualStyleBackColor = true;
            btnApplyFaults.Click += btnApplyFaults_Click;
            // 
            // btnAutoMode
            // 
            btnAutoMode.Location = new Point(10, 25);
            btnAutoMode.Name = "btnAutoMode";
            btnAutoMode.Size = new Size(100, 30);
            btnAutoMode.TabIndex = 0;
            btnAutoMode.Text = "Auto Mode";
            btnAutoMode.Click += btnAutoMode_Click;
            // 
            // btnManualMode
            // 
            btnManualMode.Location = new Point(120, 25);
            btnManualMode.Name = "btnManualMode";
            btnManualMode.Size = new Size(100, 30);
            btnManualMode.TabIndex = 1;
            btnManualMode.Text = "Manual Mode";
            btnManualMode.Click += btnManualMode_Click;
            // 
            // lblManualIrradiance
            // 
            lblManualIrradiance.AutoSize = true;
            lblManualIrradiance.Location = new Point(10, 75);
            lblManualIrradiance.Name = "lblManualIrradiance";
            lblManualIrradiance.Size = new Size(147, 15);
            lblManualIrradiance.TabIndex = 2;
            lblManualIrradiance.Text = "Manual Irradiance (W/m²):";
            // 
            // nudManualIrradiance
            // 
            nudManualIrradiance.Location = new Point(170, 72);
            nudManualIrradiance.Maximum = new decimal(new int[] { 1400, 0, 0, 0 });
            nudManualIrradiance.Name = "nudManualIrradiance";
            nudManualIrradiance.Size = new Size(120, 23);
            nudManualIrradiance.TabIndex = 3;
            nudManualIrradiance.Value = new decimal(new int[] { 800, 0, 0, 0 });
            // 
            // btnApplyManual
            // 
            btnApplyManual.Location = new Point(300, 70);
            btnApplyManual.Name = "btnApplyManual";
            btnApplyManual.Size = new Size(100, 28);
            btnApplyManual.TabIndex = 4;
            btnApplyManual.Text = "Apply";
            btnApplyManual.Click += btnApplyManual_Click;
            // 
            // uiTimer
            // 
            uiTimer.Interval = 1000;
            uiTimer.Tick += UiTimer_Tick;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(900, 550);
            Controls.Add(tableLayoutMain);
            Name = "Form1";
            Text = "SolarPark Field Simulator";
            tableLayoutMain.ResumeLayout(false);
            panelTop.ResumeLayout(false);
            panelTop.PerformLayout();
            groupWeather.ResumeLayout(false);
            groupWeather.PerformLayout();
            groupSystem.ResumeLayout(false);
            groupSystem.PerformLayout();
            groupControls.ResumeLayout(false);
            groupControls.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)nudManualIrradiance).EndInit();
            ResumeLayout(false);
        }

        private TableLayoutPanel tableLayoutMain;
        private Panel panelTop;

        private Label lblTime;
        private Label lblStatus;
        private Label lblMode;

        private GroupBox groupWeather;
        private Label lblIrradiance;
        private Label lblAmbient;
        private Label lblModuleTemp;

        private GroupBox groupSystem;
        private Label lblGrid;
        private Label lblInverter;

        private GroupBox groupControls;
        private Button btnAutoMode;
        private Button btnManualMode;
        private Label lblManualIrradiance;
        private NumericUpDown nudManualIrradiance;
        private Button btnApplyManual;
        private CheckBox chkSensorFault;
        private CheckBox chkInverterFault;
        private CheckBox chkGridFault;
        private Button btnApplyFaults;
        private Label lblAcPower;
        private Label lblDcPower;
        private Label lblTotalEnergy;
        private Label lblDailyEnergy;
        private Label lblCommHealthy;
        private Label lblHeartbeat;
        private System.Windows.Forms.Timer uiTimer;
    }
}