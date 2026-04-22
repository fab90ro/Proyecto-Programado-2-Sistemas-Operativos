namespace BusuhApp;

partial class FrmSocketServidor
{
    /// <summary>
    ///  Required designer variable.
    /// </summary>
    private System.ComponentModel.IContainer components = null;

    /// <summary>
    ///  Clean up any resources being used.
    /// </summary>
    /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
    protected override void Dispose(bool disposing)
    {
        if (disposing && (components != null))
        {
            components.Dispose();
        }
        base.Dispose(disposing);
    }

    #region Windows Form Designer generated code

    /// <summary>
    ///  Required method for Designer support - do not modify
    ///  the contents of this method with the code editor.
    /// </summary>
    private void InitializeComponent()
    {
        lblClientes = new Label();
        txtClientesConectados = new TextBox();
        lstBitacora = new ListBox();
        btnCliente = new Button();
        txtCodigoMapa = new TextBox();
        btnMapaAsientos = new Button();
        SuspendLayout();
        // 
        // lblClientes
        // 
        lblClientes.AutoSize = true;
        lblClientes.Font = new System.Drawing.Font("Segoe UI", 12F);
        lblClientes.Location = new System.Drawing.Point(325, 36);
        lblClientes.Name = "lblClientes";
        lblClientes.Size = new System.Drawing.Size(71, 28);
        lblClientes.TabIndex = 0;
        lblClientes.Text = "Clientes:";
        // 
        // txtClientesConectados
        // 
        txtClientesConectados.Font = new System.Drawing.Font("Segoe UI", 14F);
        txtClientesConectados.Anchor = AnchorStyles.Top;
        txtClientesConectados.Location = new System.Drawing.Point(402, 30);
        txtClientesConectados.Name = "txtClientesConectados";
        txtClientesConectados.ReadOnly = true;
        txtClientesConectados.Size = new System.Drawing.Size(90, 39);
        txtClientesConectados.TabIndex = 1;
        txtClientesConectados.Text = "0";
        txtClientesConectados.TextAlign = HorizontalAlignment.Center;
        // 
        // lstBitacora
        // 
        lstBitacora.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
        lstBitacora.Font = new System.Drawing.Font("Segoe UI", 11F);
        lstBitacora.FormattingEnabled = true;
        lstBitacora.ItemHeight = 25;
        lstBitacora.Location = new System.Drawing.Point(27, 94);
        lstBitacora.Name = "lstBitacora";
        lstBitacora.Size = new System.Drawing.Size(777, 404);
        lstBitacora.TabIndex = 2;
        // 
        // btnCliente
        // 
        btnCliente.Anchor = AnchorStyles.Top | AnchorStyles.Right;
        btnCliente.Font = new System.Drawing.Font("Segoe UI", 10F);
        btnCliente.Location = new System.Drawing.Point(645, 29);
        btnCliente.Name = "btnCliente";
        btnCliente.Size = new System.Drawing.Size(159, 40);
        btnCliente.TabIndex = 3;
        btnCliente.Text = "Abrir Cliente";
        btnCliente.UseVisualStyleBackColor = true;
        btnCliente.Click += btnCliente_Click;
        // 
        // txtCodigoMapa
        // 
        txtCodigoMapa.Font = new System.Drawing.Font("Segoe UI", 10F);
        txtCodigoMapa.Location = new System.Drawing.Point(27, 36);
        txtCodigoMapa.MaxLength = 2;
        txtCodigoMapa.Name = "txtCodigoMapa";
        txtCodigoMapa.PlaceholderText = "Código viaje";
        txtCodigoMapa.Size = new System.Drawing.Size(110, 30);
        txtCodigoMapa.TabIndex = 4;
        txtCodigoMapa.TextAlign = HorizontalAlignment.Center;
        // 
        // btnMapaAsientos
        // 
        btnMapaAsientos.Font = new System.Drawing.Font("Segoe UI", 10F);
        btnMapaAsientos.Location = new System.Drawing.Point(153, 29);
        btnMapaAsientos.Name = "btnMapaAsientos";
        btnMapaAsientos.Size = new System.Drawing.Size(159, 40);
        btnMapaAsientos.TabIndex = 5;
        btnMapaAsientos.Text = "Ver Mapa Asientos";
        btnMapaAsientos.UseVisualStyleBackColor = true;
        btnMapaAsientos.Click += btnMapaAsientos_Click;
        // 
        // FrmSocketServidor
        // 
        AutoScaleMode = AutoScaleMode.Font;
        ClientSize = new System.Drawing.Size(832, 525);
        Controls.Add(btnMapaAsientos);
        Controls.Add(txtCodigoMapa);
        Controls.Add(btnCliente);
        Controls.Add(lstBitacora);
        Controls.Add(txtClientesConectados);
        Controls.Add(lblClientes);
        FormBorderStyle = FormBorderStyle.Sizable;
        MaximizeBox = true;
        MinimumSize = new Size(860, 560);
        Name = "FrmSocketServidor";
        StartPosition = FormStartPosition.CenterParent;
        Text = "Servidor";
        ResumeLayout(false);
        PerformLayout();
    }

    #endregion

    private Label lblClientes;
    private TextBox txtClientesConectados;
    private ListBox lstBitacora;
    private Button btnCliente;
    private TextBox txtCodigoMapa;
    private Button btnMapaAsientos;
}