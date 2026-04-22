namespace BusUH.Server;

partial class Form1
{
    private System.ComponentModel.IContainer components = null;
    private TabControl tabMain;
    private TabPage tabTerminals;
    private TabPage tabTrips;
    private TabPage tabSocket;
    private DataGridView dgvTerminals;
    private DataGridView dgvTrips;
    private TextBox txtTerminalCode;
    private TextBox txtTerminalName;
    private TextBox txtTripCode;
    private ComboBox cmbDepartureTerminal;
    private ComboBox cmbArrivalTerminal;
    private NumericUpDown nudCapacity;
    private NumericUpDown nudCost;
    private Button btnSaveTerminal;
    private Button btnNewTerminal;
    private Button btnSaveTrip;
    private Button btnNewTrip;
    private TextBox txtSeatSummary;
    private TextBox txtLog;
    private Button btnStartSocket;
    private Button btnStopSocket;
    private NumericUpDown nudPort;
    private Label lblConnectedClientsValue;
    private Label lblSocketStatusValue;
    private Label lblTerminalCode;
    private Label lblTerminalName;
    private Label lblTripCode;
    private Label lblDeparture;
    private Label lblArrival;
    private Label lblCapacity;
    private Label lblCost;
    private Label lblSeatSummary;
    private Label lblPort;
    private Label lblSocketStatus;
    private Label lblConnectedClients;

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
        tabMain = new TabControl();
        tabTerminals = new TabPage();
        dgvTerminals = new DataGridView();
        btnNewTerminal = new Button();
        btnSaveTerminal = new Button();
        txtTerminalName = new TextBox();
        txtTerminalCode = new TextBox();
        lblTerminalName = new Label();
        lblTerminalCode = new Label();
        tabTrips = new TabPage();
        txtSeatSummary = new TextBox();
        lblSeatSummary = new Label();
        btnNewTrip = new Button();
        btnSaveTrip = new Button();
        nudCost = new NumericUpDown();
        lblCost = new Label();
        nudCapacity = new NumericUpDown();
        lblCapacity = new Label();
        cmbArrivalTerminal = new ComboBox();
        lblArrival = new Label();
        cmbDepartureTerminal = new ComboBox();
        lblDeparture = new Label();
        txtTripCode = new TextBox();
        lblTripCode = new Label();
        dgvTrips = new DataGridView();
        tabSocket = new TabPage();
        txtLog = new TextBox();
        lblConnectedClientsValue = new Label();
        lblConnectedClients = new Label();
        lblSocketStatusValue = new Label();
        lblSocketStatus = new Label();
        btnStopSocket = new Button();
        btnStartSocket = new Button();
        nudPort = new NumericUpDown();
        lblPort = new Label();
        tabMain.SuspendLayout();
        tabTerminals.SuspendLayout();
        ((System.ComponentModel.ISupportInitialize)dgvTerminals).BeginInit();
        tabTrips.SuspendLayout();
        ((System.ComponentModel.ISupportInitialize)nudCost).BeginInit();
        ((System.ComponentModel.ISupportInitialize)nudCapacity).BeginInit();
        ((System.ComponentModel.ISupportInitialize)dgvTrips).BeginInit();
        tabSocket.SuspendLayout();
        ((System.ComponentModel.ISupportInitialize)nudPort).BeginInit();
        SuspendLayout();
        // 
        // tabMain
        // 
        tabMain.Controls.Add(tabTerminals);
        tabMain.Controls.Add(tabTrips);
        tabMain.Controls.Add(tabSocket);
        tabMain.Dock = DockStyle.Fill;
        tabMain.Font = new Font("Segoe UI", 10F);
        tabMain.Location = new Point(0, 0);
        tabMain.Name = "tabMain";
        tabMain.SelectedIndex = 0;
        tabMain.Size = new Size(1184, 661);
        tabMain.TabIndex = 0;
        // 
        // tabTerminals
        // 
        tabTerminals.BackColor = Color.WhiteSmoke;
        tabTerminals.Controls.Add(dgvTerminals);
        tabTerminals.Controls.Add(btnNewTerminal);
        tabTerminals.Controls.Add(btnSaveTerminal);
        tabTerminals.Controls.Add(txtTerminalName);
        tabTerminals.Controls.Add(txtTerminalCode);
        tabTerminals.Controls.Add(lblTerminalName);
        tabTerminals.Controls.Add(lblTerminalCode);
        tabTerminals.Location = new Point(4, 26);
        tabTerminals.Name = "tabTerminals";
        tabTerminals.Padding = new Padding(3);
        tabTerminals.Size = new Size(1176, 631);
        tabTerminals.TabIndex = 0;
        tabTerminals.Text = "Mantenimiento de Terminales";
        // 
        // dgvTerminals
        // 
        dgvTerminals.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
        dgvTerminals.Location = new Point(20, 190);
        dgvTerminals.Name = "dgvTerminals";
        dgvTerminals.ReadOnly = true;
        dgvTerminals.Size = new Size(1120, 390);
        dgvTerminals.TabIndex = 6;
        dgvTerminals.SelectionChanged += dgvTerminals_SelectionChanged;
        // 
        // btnNewTerminal
        // 
        btnNewTerminal.Location = new Point(750, 44);
        btnNewTerminal.Name = "btnNewTerminal";
        btnNewTerminal.Size = new Size(120, 34);
        btnNewTerminal.TabIndex = 5;
        btnNewTerminal.Text = "Nuevo";
        btnNewTerminal.UseVisualStyleBackColor = true;
        btnNewTerminal.Click += btnNewTerminal_Click;
        // 
        // btnSaveTerminal
        // 
        btnSaveTerminal.Location = new Point(610, 44);
        btnSaveTerminal.Name = "btnSaveTerminal";
        btnSaveTerminal.Size = new Size(120, 34);
        btnSaveTerminal.TabIndex = 4;
        btnSaveTerminal.Text = "Guardar";
        btnSaveTerminal.UseVisualStyleBackColor = true;
        btnSaveTerminal.Click += btnSaveTerminal_Click;
        // 
        // txtTerminalName
        // 
        txtTerminalName.Location = new Point(220, 48);
        txtTerminalName.Name = "txtTerminalName";
        txtTerminalName.Size = new Size(360, 25);
        txtTerminalName.TabIndex = 3;
        // 
        // txtTerminalCode
        // 
        txtTerminalCode.Location = new Point(20, 48);
        txtTerminalCode.Name = "txtTerminalCode";
        txtTerminalCode.Size = new Size(180, 25);
        txtTerminalCode.TabIndex = 1;
        // 
        // lblTerminalName
        // 
        lblTerminalName.AutoSize = true;
        lblTerminalName.Location = new Point(220, 24);
        lblTerminalName.Name = "lblTerminalName";
        lblTerminalName.Size = new Size(62, 19);
        lblTerminalName.TabIndex = 2;
        lblTerminalName.Text = "Nombre";
        // 
        // lblTerminalCode
        // 
        lblTerminalCode.AutoSize = true;
        lblTerminalCode.Location = new Point(20, 24);
        lblTerminalCode.Name = "lblTerminalCode";
        lblTerminalCode.Size = new Size(54, 19);
        lblTerminalCode.TabIndex = 0;
        lblTerminalCode.Text = "Codigo";
        // 
        // tabTrips
        // 
        tabTrips.BackColor = Color.WhiteSmoke;
        tabTrips.Controls.Add(txtSeatSummary);
        tabTrips.Controls.Add(lblSeatSummary);
        tabTrips.Controls.Add(btnNewTrip);
        tabTrips.Controls.Add(btnSaveTrip);
        tabTrips.Controls.Add(nudCost);
        tabTrips.Controls.Add(lblCost);
        tabTrips.Controls.Add(nudCapacity);
        tabTrips.Controls.Add(lblCapacity);
        tabTrips.Controls.Add(cmbArrivalTerminal);
        tabTrips.Controls.Add(lblArrival);
        tabTrips.Controls.Add(cmbDepartureTerminal);
        tabTrips.Controls.Add(lblDeparture);
        tabTrips.Controls.Add(txtTripCode);
        tabTrips.Controls.Add(lblTripCode);
        tabTrips.Controls.Add(dgvTrips);
        tabTrips.Location = new Point(4, 26);
        tabTrips.Name = "tabTrips";
        tabTrips.Padding = new Padding(3);
        tabTrips.Size = new Size(1176, 631);
        tabTrips.TabIndex = 1;
        tabTrips.Text = "Mantenimiento de Viajes";
        // 
        // txtSeatSummary
        // 
        txtSeatSummary.Location = new Point(800, 44);
        txtSeatSummary.Multiline = true;
        txtSeatSummary.Name = "txtSeatSummary";
        txtSeatSummary.ReadOnly = true;
        txtSeatSummary.ScrollBars = ScrollBars.Vertical;
        txtSeatSummary.Size = new Size(340, 536);
        txtSeatSummary.TabIndex = 14;
        // 
        // lblSeatSummary
        // 
        lblSeatSummary.AutoSize = true;
        lblSeatSummary.Location = new Point(800, 18);
        lblSeatSummary.Name = "lblSeatSummary";
        lblSeatSummary.Size = new Size(169, 19);
        lblSeatSummary.TabIndex = 13;
        lblSeatSummary.Text = "Disponibilidad de asientos";
        // 
        // btnNewTrip
        // 
        btnNewTrip.Location = new Point(580, 114);
        btnNewTrip.Name = "btnNewTrip";
        btnNewTrip.Size = new Size(130, 34);
        btnNewTrip.TabIndex = 11;
        btnNewTrip.Text = "Nuevo viaje";
        btnNewTrip.UseVisualStyleBackColor = true;
        btnNewTrip.Click += btnNewTrip_Click;
        // 
        // btnSaveTrip
        // 
        btnSaveTrip.Location = new Point(430, 114);
        btnSaveTrip.Name = "btnSaveTrip";
        btnSaveTrip.Size = new Size(130, 34);
        btnSaveTrip.TabIndex = 10;
        btnSaveTrip.Text = "Guardar viaje";
        btnSaveTrip.UseVisualStyleBackColor = true;
        btnSaveTrip.Click += btnSaveTrip_Click;
        // 
        // nudCost
        // 
        nudCost.Location = new Point(190, 118);
        nudCost.Maximum = new decimal(new int[] { 99999, 0, 0, 0 });
        nudCost.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
        nudCost.Name = "nudCost";
        nudCost.Size = new Size(150, 25);
        nudCost.TabIndex = 9;
        nudCost.ThousandsSeparator = true;
        nudCost.Value = new decimal(new int[] { 3500, 0, 0, 0 });
        // 
        // lblCost
        // 
        lblCost.AutoSize = true;
        lblCost.Location = new Point(190, 92);
        lblCost.Name = "lblCost";
        lblCost.Size = new Size(45, 19);
        lblCost.TabIndex = 8;
        lblCost.Text = "Costo";
        // 
        // nudCapacity
        // 
        nudCapacity.Location = new Point(20, 118);
        nudCapacity.Maximum = new decimal(new int[] { 67, 0, 0, 0 });
        nudCapacity.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
        nudCapacity.Name = "nudCapacity";
        nudCapacity.Size = new Size(150, 25);
        nudCapacity.TabIndex = 7;
        nudCapacity.Value = new decimal(new int[] { 67, 0, 0, 0 });
        // 
        // lblCapacity
        // 
        lblCapacity.AutoSize = true;
        lblCapacity.Location = new Point(20, 92);
        lblCapacity.Name = "lblCapacity";
        lblCapacity.Size = new Size(72, 19);
        lblCapacity.TabIndex = 6;
        lblCapacity.Text = "Capacidad";
        // 
        // cmbArrivalTerminal
        // 
        cmbArrivalTerminal.DropDownStyle = ComboBoxStyle.DropDownList;
        cmbArrivalTerminal.FormattingEnabled = true;
        cmbArrivalTerminal.Location = new Point(430, 44);
        cmbArrivalTerminal.Name = "cmbArrivalTerminal";
        cmbArrivalTerminal.Size = new Size(220, 25);
        cmbArrivalTerminal.TabIndex = 5;
        // 
        // lblArrival
        // 
        lblArrival.AutoSize = true;
        lblArrival.Location = new Point(430, 18);
        lblArrival.Name = "lblArrival";
        lblArrival.Size = new Size(108, 19);
        lblArrival.TabIndex = 4;
        lblArrival.Text = "Terminal llegada";
        // 
        // cmbDepartureTerminal
        // 
        cmbDepartureTerminal.DropDownStyle = ComboBoxStyle.DropDownList;
        cmbDepartureTerminal.FormattingEnabled = true;
        cmbDepartureTerminal.Location = new Point(190, 44);
        cmbDepartureTerminal.Name = "cmbDepartureTerminal";
        cmbDepartureTerminal.Size = new Size(220, 25);
        cmbDepartureTerminal.TabIndex = 3;
        // 
        // lblDeparture
        // 
        lblDeparture.AutoSize = true;
        lblDeparture.Location = new Point(190, 18);
        lblDeparture.Name = "lblDeparture";
        lblDeparture.Size = new Size(102, 19);
        lblDeparture.TabIndex = 2;
        lblDeparture.Text = "Terminal salida";
        // 
        // txtTripCode
        // 
        txtTripCode.Location = new Point(20, 44);
        txtTripCode.Name = "txtTripCode";
        txtTripCode.Size = new Size(150, 25);
        txtTripCode.TabIndex = 1;
        // 
        // lblTripCode
        // 
        lblTripCode.AutoSize = true;
        lblTripCode.Location = new Point(20, 18);
        lblTripCode.Name = "lblTripCode";
        lblTripCode.Size = new Size(104, 19);
        lblTripCode.TabIndex = 0;
        lblTripCode.Text = "Codigo de viaje";
        // 
        // dgvTrips
        // 
        dgvTrips.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
        dgvTrips.Location = new Point(20, 220);
        dgvTrips.Name = "dgvTrips";
        dgvTrips.ReadOnly = true;
        dgvTrips.Size = new Size(760, 360);
        dgvTrips.TabIndex = 12;
        dgvTrips.SelectionChanged += dgvTrips_SelectionChanged;
        // 
        // tabSocket
        // 
        tabSocket.BackColor = Color.WhiteSmoke;
        tabSocket.Controls.Add(txtLog);
        tabSocket.Controls.Add(lblConnectedClientsValue);
        tabSocket.Controls.Add(lblConnectedClients);
        tabSocket.Controls.Add(lblSocketStatusValue);
        tabSocket.Controls.Add(lblSocketStatus);
        tabSocket.Controls.Add(btnStopSocket);
        tabSocket.Controls.Add(btnStartSocket);
        tabSocket.Controls.Add(nudPort);
        tabSocket.Controls.Add(lblPort);
        tabSocket.Location = new Point(4, 26);
        tabSocket.Name = "tabSocket";
        tabSocket.Padding = new Padding(3);
        tabSocket.Size = new Size(1176, 631);
        tabSocket.TabIndex = 2;
        tabSocket.Text = "Socket de Comunicacion";
        // 
        // txtLog
        // 
        txtLog.Location = new Point(20, 110);
        txtLog.Multiline = true;
        txtLog.Name = "txtLog";
        txtLog.ReadOnly = true;
        txtLog.ScrollBars = ScrollBars.Vertical;
        txtLog.Size = new Size(1120, 470);
        txtLog.TabIndex = 8;
        // 
        // lblConnectedClientsValue
        // 
        lblConnectedClientsValue.AutoSize = true;
        lblConnectedClientsValue.Location = new Point(860, 50);
        lblConnectedClientsValue.Name = "lblConnectedClientsValue";
        lblConnectedClientsValue.Size = new Size(17, 19);
        lblConnectedClientsValue.TabIndex = 7;
        lblConnectedClientsValue.Text = "0";
        // 
        // lblConnectedClients
        // 
        lblConnectedClients.AutoSize = true;
        lblConnectedClients.Location = new Point(700, 50);
        lblConnectedClients.Name = "lblConnectedClients";
        lblConnectedClients.Size = new Size(153, 19);
        lblConnectedClients.TabIndex = 6;
        lblConnectedClients.Text = "Clientes conectados:";
        // 
        // lblSocketStatusValue
        // 
        lblSocketStatusValue.AutoSize = true;
        lblSocketStatusValue.Location = new Point(580, 50);
        lblSocketStatusValue.Name = "lblSocketStatusValue";
        lblSocketStatusValue.Size = new Size(65, 19);
        lblSocketStatusValue.TabIndex = 5;
        lblSocketStatusValue.Text = "Detenido";
        // 
        // lblSocketStatus
        // 
        lblSocketStatus.AutoSize = true;
        lblSocketStatus.Location = new Point(520, 50);
        lblSocketStatus.Name = "lblSocketStatus";
        lblSocketStatus.Size = new Size(54, 19);
        lblSocketStatus.TabIndex = 4;
        lblSocketStatus.Text = "Estado:";
        // 
        // btnStopSocket
        // 
        btnStopSocket.Enabled = false;
        btnStopSocket.Location = new Point(350, 44);
        btnStopSocket.Name = "btnStopSocket";
        btnStopSocket.Size = new Size(140, 34);
        btnStopSocket.TabIndex = 3;
        btnStopSocket.Text = "Detener";
        btnStopSocket.UseVisualStyleBackColor = true;
        btnStopSocket.Click += btnStopSocket_Click;
        // 
        // btnStartSocket
        // 
        btnStartSocket.Location = new Point(190, 44);
        btnStartSocket.Name = "btnStartSocket";
        btnStartSocket.Size = new Size(140, 34);
        btnStartSocket.TabIndex = 2;
        btnStartSocket.Text = "Iniciar socket";
        btnStartSocket.UseVisualStyleBackColor = true;
        btnStartSocket.Click += btnStartSocket_Click;
        // 
        // nudPort
        // 
        nudPort.Location = new Point(20, 50);
        nudPort.Maximum = new decimal(new int[] { 65000, 0, 0, 0 });
        nudPort.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
        nudPort.Name = "nudPort";
        nudPort.Size = new Size(140, 25);
        nudPort.TabIndex = 1;
        nudPort.Value = new decimal(new int[] { 30000, 0, 0, 0 });
        // 
        // lblPort
        // 
        lblPort.AutoSize = true;
        lblPort.Location = new Point(20, 24);
        lblPort.Name = "lblPort";
        lblPort.Size = new Size(46, 19);
        lblPort.TabIndex = 0;
        lblPort.Text = "Puerto";
        // 
        // Form1
        // 
        AutoScaleDimensions = new SizeF(7F, 15F);
        AutoScaleMode = AutoScaleMode.Font;
        ClientSize = new Size(1184, 661);
        Controls.Add(tabMain);
        MinimumSize = new Size(1200, 700);
        Name = "Form1";
        StartPosition = FormStartPosition.CenterScreen;
        Text = "BUS UH - Servidor";
        FormClosing += Form1_FormClosing;
        tabMain.ResumeLayout(false);
        tabTerminals.ResumeLayout(false);
        tabTerminals.PerformLayout();
        ((System.ComponentModel.ISupportInitialize)dgvTerminals).EndInit();
        tabTrips.ResumeLayout(false);
        tabTrips.PerformLayout();
        ((System.ComponentModel.ISupportInitialize)nudCost).EndInit();
        ((System.ComponentModel.ISupportInitialize)nudCapacity).EndInit();
        ((System.ComponentModel.ISupportInitialize)dgvTrips).EndInit();
        tabSocket.ResumeLayout(false);
        tabSocket.PerformLayout();
        ((System.ComponentModel.ISupportInitialize)nudPort).EndInit();
        ResumeLayout(false);
    }
}
