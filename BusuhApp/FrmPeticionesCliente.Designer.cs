namespace BusuhApp;

partial class FrmPeticionesCliente
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
        txtServidor = new TextBox();
        btnConectar = new Button();
        btnDesconectar = new Button();
        lstBitacora = new ListBox();
        btnEnviar = new Button();
        txtTrama = new TextBox();
        SuspendLayout();
        // 
        // txtServidor
        // 
        txtServidor.Font = new System.Drawing.Font("Segoe UI", 12F);
        txtServidor.Location = new System.Drawing.Point(22, 20);
        txtServidor.Name = "txtServidor";
        txtServidor.Size = new System.Drawing.Size(456, 34);
        txtServidor.TabIndex = 0;
        txtServidor.Text = "127.0.0.1";
        // 
        // btnConectar
        // 
        btnConectar.Font = new System.Drawing.Font("Segoe UI", 11F);
        btnConectar.Location = new System.Drawing.Point(493, 17);
        btnConectar.Name = "btnConectar";
        btnConectar.Size = new System.Drawing.Size(98, 40);
        btnConectar.TabIndex = 1;
        btnConectar.Text = "Conectar";
        btnConectar.UseVisualStyleBackColor = true;
        btnConectar.Click += btnConectar_Click;
        // 
        // btnDesconectar
        // 
        btnDesconectar.Enabled = false;
        btnDesconectar.Font = new System.Drawing.Font("Segoe UI", 11F);
        btnDesconectar.Location = new System.Drawing.Point(602, 17);
        btnDesconectar.Name = "btnDesconectar";
        btnDesconectar.Size = new System.Drawing.Size(115, 40);
        btnDesconectar.TabIndex = 2;
        btnDesconectar.Text = "Desconectar";
        btnDesconectar.UseVisualStyleBackColor = true;
        btnDesconectar.Click += btnDesconectar_Click;
        // 
        // lstBitacora
        // 
        lstBitacora.Font = new System.Drawing.Font("Segoe UI", 11F);
        lstBitacora.FormattingEnabled = true;
        lstBitacora.ItemHeight = 25;
        lstBitacora.Location = new System.Drawing.Point(22, 106);
        lstBitacora.Name = "lstBitacora";
        lstBitacora.Size = new System.Drawing.Size(695, 279);
        lstBitacora.TabIndex = 4;
        // 
        // btnEnviar
        // 
        btnEnviar.Enabled = false;
        btnEnviar.Font = new System.Drawing.Font("Segoe UI", 11F);
        btnEnviar.Location = new System.Drawing.Point(602, 400);
        btnEnviar.Name = "btnEnviar";
        btnEnviar.Size = new System.Drawing.Size(115, 37);
        btnEnviar.TabIndex = 5;
        btnEnviar.Text = "Enviar";
        btnEnviar.UseVisualStyleBackColor = true;
        btnEnviar.Click += btnEnviar_Click;
        // 
        // txtTrama
        // 
        txtTrama.Font = new System.Drawing.Font("Segoe UI", 12F);
        txtTrama.Location = new System.Drawing.Point(22, 66);
        txtTrama.Name = "txtTrama";
        txtTrama.Size = new System.Drawing.Size(695, 34);
        txtTrama.TabIndex = 3;
        // 
        // FrmPeticionesCliente
        // 
        AutoScaleMode = AutoScaleMode.Font;
        ClientSize = new System.Drawing.Size(741, 451);
        Controls.Add(txtTrama);
        Controls.Add(btnEnviar);
        Controls.Add(lstBitacora);
        Controls.Add(btnDesconectar);
        Controls.Add(btnConectar);
        Controls.Add(txtServidor);
        FormBorderStyle = FormBorderStyle.FixedSingle;
        MaximizeBox = false;
        Name = "FrmPeticionesCliente";
        StartPosition = FormStartPosition.CenterParent;
        Text = "Peticiones de Cliente";
        ResumeLayout(false);
        PerformLayout();
    }

    #endregion

    private TextBox txtServidor;
    private Button btnConectar;
    private Button btnDesconectar;
    private ListBox lstBitacora;
    private Button btnEnviar;
    private TextBox txtTrama;
}