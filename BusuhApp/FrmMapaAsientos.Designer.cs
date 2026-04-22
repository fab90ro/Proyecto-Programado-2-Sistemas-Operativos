namespace BusuhApp;

partial class FrmMapaAsientos
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
        lblCodigo = new Label();
        txtCodigo = new TextBox();
        lblDescripcion = new Label();
        txtDescripcion = new TextBox();
        lblDisponibles = new Label();
        txtDisponibles = new TextBox();
        btnActualizar = new Button();
        flpAsientos = new FlowLayoutPanel();
        lblLeyendaLibre = new Label();
        pnlLibre = new Panel();
        lblLeyendaOcupado = new Label();
        pnlOcupado = new Panel();
        lblLeyendaNoAplica = new Label();
        pnlNoAplica = new Panel();
        SuspendLayout();
        // 
        // lblCodigo
        // 
        lblCodigo.AutoSize = true;
        lblCodigo.Location = new Point(20, 18);
        lblCodigo.Name = "lblCodigo";
        lblCodigo.Size = new Size(99, 20);
        lblCodigo.TabIndex = 0;
        lblCodigo.Text = "Código Viaje:";
        // 
        // txtCodigo
        // 
        txtCodigo.Location = new Point(125, 15);
        txtCodigo.Name = "txtCodigo";
        txtCodigo.ReadOnly = true;
        txtCodigo.Size = new Size(70, 27);
        txtCodigo.TabIndex = 1;
        // 
        // lblDescripcion
        // 
        lblDescripcion.AutoSize = true;
        lblDescripcion.Location = new Point(215, 18);
        lblDescripcion.Name = "lblDescripcion";
        lblDescripcion.Size = new Size(90, 20);
        lblDescripcion.TabIndex = 2;
        lblDescripcion.Text = "Descripción:";
        // 
        // txtDescripcion
        // 
        txtDescripcion.Location = new Point(311, 15);
        txtDescripcion.Name = "txtDescripcion";
        txtDescripcion.ReadOnly = true;
        txtDescripcion.Size = new Size(360, 27);
        txtDescripcion.TabIndex = 3;
        // 
        // lblDisponibles
        // 
        lblDisponibles.AutoSize = true;
        lblDisponibles.Location = new Point(690, 18);
        lblDisponibles.Name = "lblDisponibles";
        lblDisponibles.Size = new Size(88, 20);
        lblDisponibles.TabIndex = 4;
        lblDisponibles.Text = "Disponibles:";
        // 
        // txtDisponibles
        // 
        txtDisponibles.Location = new Point(784, 15);
        txtDisponibles.Name = "txtDisponibles";
        txtDisponibles.ReadOnly = true;
        txtDisponibles.Size = new Size(70, 27);
        txtDisponibles.TabIndex = 5;
        // 
        // btnActualizar
        // 
        btnActualizar.Location = new Point(875, 14);
        btnActualizar.Name = "btnActualizar";
        btnActualizar.Size = new Size(110, 30);
        btnActualizar.TabIndex = 6;
        btnActualizar.Text = "Actualizar";
        btnActualizar.UseVisualStyleBackColor = true;
        btnActualizar.Click += btnActualizar_Click;
        // 
        // flpAsientos
        // 
        flpAsientos.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
        flpAsientos.Location = new Point(20, 86);
        flpAsientos.Name = "flpAsientos";
        flpAsientos.Size = new Size(965, 595);
        flpAsientos.TabIndex = 7;
        // 
        // lblLeyendaLibre
        // 
        lblLeyendaLibre.AutoSize = true;
        lblLeyendaLibre.Location = new Point(70, 58);
        lblLeyendaLibre.Name = "lblLeyendaLibre";
        lblLeyendaLibre.Size = new Size(43, 20);
        lblLeyendaLibre.TabIndex = 8;
        lblLeyendaLibre.Text = "Libre";
        // 
        // pnlLibre
        // 
        pnlLibre.BackColor = Color.LightGreen;
        pnlLibre.BorderStyle = BorderStyle.FixedSingle;
        pnlLibre.Location = new Point(20, 58);
        pnlLibre.Name = "pnlLibre";
        pnlLibre.Size = new Size(40, 20);
        pnlLibre.TabIndex = 9;
        // 
        // lblLeyendaOcupado
        // 
        lblLeyendaOcupado.AutoSize = true;
        lblLeyendaOcupado.Location = new Point(200, 58);
        lblLeyendaOcupado.Name = "lblLeyendaOcupado";
        lblLeyendaOcupado.Size = new Size(66, 20);
        lblLeyendaOcupado.TabIndex = 10;
        lblLeyendaOcupado.Text = "Ocupado";
        // 
        // pnlOcupado
        // 
        pnlOcupado.BackColor = Color.IndianRed;
        pnlOcupado.BorderStyle = BorderStyle.FixedSingle;
        pnlOcupado.Location = new Point(150, 58);
        pnlOcupado.Name = "pnlOcupado";
        pnlOcupado.Size = new Size(40, 20);
        pnlOcupado.TabIndex = 11;
        // 
        // lblLeyendaNoAplica
        // 
        lblLeyendaNoAplica.AutoSize = true;
        lblLeyendaNoAplica.Location = new Point(348, 58);
        lblLeyendaNoAplica.Name = "lblLeyendaNoAplica";
        lblLeyendaNoAplica.Size = new Size(75, 20);
        lblLeyendaNoAplica.TabIndex = 12;
        lblLeyendaNoAplica.Text = "No aplica";
        // 
        // pnlNoAplica
        // 
        pnlNoAplica.BackColor = Color.LightGray;
        pnlNoAplica.BorderStyle = BorderStyle.FixedSingle;
        pnlNoAplica.Location = new Point(298, 58);
        pnlNoAplica.Name = "pnlNoAplica";
        pnlNoAplica.Size = new Size(40, 20);
        pnlNoAplica.TabIndex = 13;
        // 
        // FrmMapaAsientos
        // 
        AutoScaleMode = AutoScaleMode.Font;
        ClientSize = new Size(1008, 720);
        MinimumSize = new Size(980, 700);
        Controls.Add(pnlNoAplica);
        Controls.Add(lblLeyendaNoAplica);
        Controls.Add(pnlOcupado);
        Controls.Add(lblLeyendaOcupado);
        Controls.Add(pnlLibre);
        Controls.Add(lblLeyendaLibre);
        Controls.Add(flpAsientos);
        Controls.Add(btnActualizar);
        Controls.Add(txtDisponibles);
        Controls.Add(lblDisponibles);
        Controls.Add(txtDescripcion);
        Controls.Add(lblDescripcion);
        Controls.Add(txtCodigo);
        Controls.Add(lblCodigo);
        FormBorderStyle = FormBorderStyle.Sizable;
        MaximizeBox = true;
        Name = "FrmMapaAsientos";
        StartPosition = FormStartPosition.CenterParent;
        Text = "Mapa de Asientos";
        ResumeLayout(false);
        PerformLayout();
    }

    #endregion

    private Label lblCodigo;
    private TextBox txtCodigo;
    private Label lblDescripcion;
    private TextBox txtDescripcion;
    private Label lblDisponibles;
    private TextBox txtDisponibles;
    private Button btnActualizar;
    private FlowLayoutPanel flpAsientos;
    private Label lblLeyendaLibre;
    private Panel pnlLibre;
    private Label lblLeyendaOcupado;
    private Panel pnlOcupado;
    private Label lblLeyendaNoAplica;
    private Panel pnlNoAplica;
}
