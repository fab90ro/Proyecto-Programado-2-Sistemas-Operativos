namespace BusUH.Client;

partial class Form1
{
    private System.ComponentModel.IContainer components = null;
    private TextBox txtServerIp;
    private NumericUpDown nudPort;
    private Button btnConnect;
    private Button btnDisconnect;
    private ComboBox cmbTripCode;
    private NumericUpDown nudQuantity;
    private Button btnGenerateFrame;
    private TextBox txtFrame;
    private Button btnSend;
    private TextBox txtResponse;
    private TextBox txtInterpretation;
    private TextBox txtLog;
    private Label lblConnectionStatusValue;
    private Label lblServerIp;
    private Label lblPort;
    private Label lblStatus;
    private Label lblTripCode;
    private Label lblQuantity;
    private Label lblFrame;
    private Label lblResponse;
    private Label lblInterpretation;
    private Label lblLog;

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
        txtServerIp = new TextBox();
        nudPort = new NumericUpDown();
        btnConnect = new Button();
        btnDisconnect = new Button();
        cmbTripCode = new ComboBox();
        nudQuantity = new NumericUpDown();
        btnGenerateFrame = new Button();
        txtFrame = new TextBox();
        btnSend = new Button();
        txtResponse = new TextBox();
        txtInterpretation = new TextBox();
        txtLog = new TextBox();
        lblConnectionStatusValue = new Label();
        lblServerIp = new Label();
        lblPort = new Label();
        lblStatus = new Label();
        lblTripCode = new Label();
        lblQuantity = new Label();
        lblFrame = new Label();
        lblResponse = new Label();
        lblInterpretation = new Label();
        lblLog = new Label();
        ((System.ComponentModel.ISupportInitialize)nudPort).BeginInit();
        ((System.ComponentModel.ISupportInitialize)nudQuantity).BeginInit();
        SuspendLayout();
        // 
        // txtServerIp
        // 
        txtServerIp.Location = new Point(20, 44);
        txtServerIp.Name = "txtServerIp";
        txtServerIp.Size = new Size(160, 23);
        txtServerIp.TabIndex = 1;
        txtServerIp.Text = "127.0.0.1";
        // 
        // nudPort
        // 
        nudPort.Location = new Point(200, 44);
        nudPort.Maximum = new decimal(new int[] { 65000, 0, 0, 0 });
        nudPort.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
        nudPort.Name = "nudPort";
        nudPort.Size = new Size(120, 23);
        nudPort.TabIndex = 3;
        nudPort.Value = new decimal(new int[] { 30000, 0, 0, 0 });
        // 
        // btnConnect
        // 
        btnConnect.Location = new Point(340, 38);
        btnConnect.Name = "btnConnect";
        btnConnect.Size = new Size(110, 34);
        btnConnect.TabIndex = 4;
        btnConnect.Text = "Conectar";
        btnConnect.UseVisualStyleBackColor = true;
        btnConnect.Click += btnConnect_Click;
        // 
        // btnDisconnect
        // 
        btnDisconnect.Enabled = false;
        btnDisconnect.Location = new Point(465, 38);
        btnDisconnect.Name = "btnDisconnect";
        btnDisconnect.Size = new Size(120, 34);
        btnDisconnect.TabIndex = 5;
        btnDisconnect.Text = "Desconectar";
        btnDisconnect.UseVisualStyleBackColor = true;
        btnDisconnect.Click += btnDisconnect_Click;
        // 
        // cmbTripCode
        // 
        cmbTripCode.DropDownStyle = ComboBoxStyle.DropDownList;
        cmbTripCode.FormattingEnabled = true;
        cmbTripCode.Items.AddRange(new object[] { "01", "02" });
        cmbTripCode.Location = new Point(20, 124);
        cmbTripCode.Name = "cmbTripCode";
        cmbTripCode.Size = new Size(160, 23);
        cmbTripCode.TabIndex = 9;
        // 
        // nudQuantity
        // 
        nudQuantity.Location = new Point(200, 124);
        nudQuantity.Maximum = new decimal(new int[] { 5, 0, 0, 0 });
        nudQuantity.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
        nudQuantity.Name = "nudQuantity";
        nudQuantity.Size = new Size(160, 23);
        nudQuantity.TabIndex = 11;
        nudQuantity.Value = new decimal(new int[] { 1, 0, 0, 0 });
        // 
        // btnGenerateFrame
        // 
        btnGenerateFrame.Location = new Point(385, 118);
        btnGenerateFrame.Name = "btnGenerateFrame";
        btnGenerateFrame.Size = new Size(140, 34);
        btnGenerateFrame.TabIndex = 12;
        btnGenerateFrame.Text = "Generar trama";
        btnGenerateFrame.UseVisualStyleBackColor = true;
        btnGenerateFrame.Click += btnGenerateFrame_Click;
        // 
        // txtFrame
        // 
        txtFrame.Location = new Point(20, 204);
        txtFrame.Name = "txtFrame";
        txtFrame.Size = new Size(220, 23);
        txtFrame.TabIndex = 14;
        // 
        // btnSend
        // 
        btnSend.Enabled = false;
        btnSend.Location = new Point(260, 198);
        btnSend.Name = "btnSend";
        btnSend.Size = new Size(145, 34);
        btnSend.TabIndex = 15;
        btnSend.Text = "Enviar al servidor";
        btnSend.UseVisualStyleBackColor = true;
        btnSend.Click += btnSend_Click;
        // 
        // txtResponse
        // 
        txtResponse.Location = new Point(20, 284);
        txtResponse.Name = "txtResponse";
        txtResponse.ReadOnly = true;
        txtResponse.Size = new Size(385, 23);
        txtResponse.TabIndex = 17;
        // 
        // txtInterpretation
        // 
        txtInterpretation.Location = new Point(20, 354);
        txtInterpretation.Multiline = true;
        txtInterpretation.Name = "txtInterpretation";
        txtInterpretation.ReadOnly = true;
        txtInterpretation.ScrollBars = ScrollBars.Vertical;
        txtInterpretation.Size = new Size(385, 220);
        txtInterpretation.TabIndex = 19;
        // 
        // txtLog
        // 
        txtLog.Location = new Point(430, 204);
        txtLog.Multiline = true;
        txtLog.Name = "txtLog";
        txtLog.ReadOnly = true;
        txtLog.ScrollBars = ScrollBars.Vertical;
        txtLog.Size = new Size(410, 370);
        txtLog.TabIndex = 21;
        // 
        // lblConnectionStatusValue
        // 
        lblConnectionStatusValue.AutoSize = true;
        lblConnectionStatusValue.Location = new Point(665, 46);
        lblConnectionStatusValue.Name = "lblConnectionStatusValue";
        lblConnectionStatusValue.Size = new Size(89, 15);
        lblConnectionStatusValue.TabIndex = 7;
        lblConnectionStatusValue.Text = "Desconectado";
        // 
        // lblServerIp
        // 
        lblServerIp.AutoSize = true;
        lblServerIp.Location = new Point(20, 18);
        lblServerIp.Name = "lblServerIp";
        lblServerIp.Size = new Size(77, 15);
        lblServerIp.TabIndex = 0;
        lblServerIp.Text = "IP del servidor";
        // 
        // lblPort
        // 
        lblPort.AutoSize = true;
        lblPort.Location = new Point(200, 18);
        lblPort.Name = "lblPort";
        lblPort.Size = new Size(41, 15);
        lblPort.TabIndex = 2;
        lblPort.Text = "Puerto";
        // 
        // lblStatus
        // 
        lblStatus.AutoSize = true;
        lblStatus.Location = new Point(610, 46);
        lblStatus.Name = "lblStatus";
        lblStatus.Size = new Size(45, 15);
        lblStatus.TabIndex = 6;
        lblStatus.Text = "Estado:";
        // 
        // lblTripCode
        // 
        lblTripCode.AutoSize = true;
        lblTripCode.Location = new Point(20, 98);
        lblTripCode.Name = "lblTripCode";
        lblTripCode.Size = new Size(85, 15);
        lblTripCode.TabIndex = 8;
        lblTripCode.Text = "Codigo de viaje";
        // 
        // lblQuantity
        // 
        lblQuantity.AutoSize = true;
        lblQuantity.Location = new Point(200, 98);
        lblQuantity.Name = "lblQuantity";
        lblQuantity.Size = new Size(114, 15);
        lblQuantity.TabIndex = 10;
        lblQuantity.Text = "Cantidad de boletos";
        // 
        // lblFrame
        // 
        lblFrame.AutoSize = true;
        lblFrame.Location = new Point(20, 178);
        lblFrame.Name = "lblFrame";
        lblFrame.Size = new Size(84, 15);
        lblFrame.TabIndex = 13;
        lblFrame.Text = "Trama a enviar";
        // 
        // lblResponse
        // 
        lblResponse.AutoSize = true;
        lblResponse.Location = new Point(20, 258);
        lblResponse.Name = "lblResponse";
        lblResponse.Size = new Size(110, 15);
        lblResponse.TabIndex = 16;
        lblResponse.Text = "Trama de respuesta";
        // 
        // lblInterpretation
        // 
        lblInterpretation.AutoSize = true;
        lblInterpretation.Location = new Point(20, 328);
        lblInterpretation.Name = "lblInterpretation";
        lblInterpretation.Size = new Size(76, 15);
        lblInterpretation.TabIndex = 18;
        lblInterpretation.Text = "Interpretacion";
        // 
        // lblLog
        // 
        lblLog.AutoSize = true;
        lblLog.Location = new Point(430, 178);
        lblLog.Name = "lblLog";
        lblLog.Size = new Size(100, 15);
        lblLog.TabIndex = 20;
        lblLog.Text = "Bitacora del cliente";
        // 
        // Form1
        // 
        AutoScaleDimensions = new SizeF(7F, 15F);
        AutoScaleMode = AutoScaleMode.Font;
        ClientSize = new Size(864, 601);
        Controls.Add(txtLog);
        Controls.Add(lblLog);
        Controls.Add(txtInterpretation);
        Controls.Add(lblInterpretation);
        Controls.Add(txtResponse);
        Controls.Add(lblResponse);
        Controls.Add(btnSend);
        Controls.Add(txtFrame);
        Controls.Add(lblFrame);
        Controls.Add(btnGenerateFrame);
        Controls.Add(nudQuantity);
        Controls.Add(lblQuantity);
        Controls.Add(cmbTripCode);
        Controls.Add(lblTripCode);
        Controls.Add(lblConnectionStatusValue);
        Controls.Add(lblStatus);
        Controls.Add(btnDisconnect);
        Controls.Add(btnConnect);
        Controls.Add(nudPort);
        Controls.Add(lblPort);
        Controls.Add(txtServerIp);
        Controls.Add(lblServerIp);
        MinimumSize = new Size(880, 640);
        Name = "Form1";
        StartPosition = FormStartPosition.CenterScreen;
        Text = "BUS UH - Cliente";
        FormClosing += Form1_FormClosing;
        ((System.ComponentModel.ISupportInitialize)nudPort).EndInit();
        ((System.ComponentModel.ISupportInitialize)nudQuantity).EndInit();
        ResumeLayout(false);
        PerformLayout();
    }
}
