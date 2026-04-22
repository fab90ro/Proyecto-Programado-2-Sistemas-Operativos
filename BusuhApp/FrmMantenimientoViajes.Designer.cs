namespace BusuhApp;

partial class FrmMantenimientoViajes
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
        lblTerminalSalida = new Label();
        cboTerminalSalida = new ComboBox();
        lblTerminalLlegada = new Label();
        cboTerminalLlegada = new ComboBox();
        lblCapacidad = new Label();
        txtCapacidad = new TextBox();
        lblCosto = new Label();
        txtCosto = new TextBox();
        btnGrabar = new Button();
        btnEliminar = new Button();
        btnLimpiar = new Button();
        btnSalir = new Button();
        dgvViajes = new DataGridView();
        colCodigo = new DataGridViewTextBoxColumn();
        colTerminalSalida = new DataGridViewTextBoxColumn();
        colTerminalLlegada = new DataGridViewTextBoxColumn();
        colCapacidad = new DataGridViewTextBoxColumn();
        colCosto = new DataGridViewTextBoxColumn();
        colCapacidadDisponible = new DataGridViewTextBoxColumn();
        ((System.ComponentModel.ISupportInitialize)dgvViajes).BeginInit();
        SuspendLayout();
        // 
        // lblCodigo
        // 
        lblCodigo.AutoSize = true;
        lblCodigo.Font = new System.Drawing.Font("Segoe UI", 14F);
        lblCodigo.Location = new System.Drawing.Point(28, 29);
        lblCodigo.Name = "lblCodigo";
        lblCodigo.Size = new System.Drawing.Size(168, 32);
        lblCodigo.TabIndex = 0;
        lblCodigo.Text = "Código de Viaje";
        // 
        // txtCodigo
        // 
        txtCodigo.Font = new System.Drawing.Font("Segoe UI", 14F);
        txtCodigo.Location = new System.Drawing.Point(308, 26);
        txtCodigo.Name = "txtCodigo";
        txtCodigo.Size = new System.Drawing.Size(140, 39);
        txtCodigo.TabIndex = 1;
        // 
        // lblDescripcion
        // 
        lblDescripcion.AutoSize = true;
        lblDescripcion.Font = new System.Drawing.Font("Segoe UI", 14F);
        lblDescripcion.Location = new System.Drawing.Point(28, 83);
        lblDescripcion.Name = "lblDescripcion";
        lblDescripcion.Size = new System.Drawing.Size(137, 32);
        lblDescripcion.TabIndex = 2;
        lblDescripcion.Text = "Descripción";
        // 
        // txtDescripcion
        // 
        txtDescripcion.Font = new System.Drawing.Font("Segoe UI", 14F);
        txtDescripcion.Location = new System.Drawing.Point(308, 80);
        txtDescripcion.Name = "txtDescripcion";
        txtDescripcion.Size = new System.Drawing.Size(426, 39);
        txtDescripcion.TabIndex = 3;
        // 
        // lblTerminalSalida
        // 
        lblTerminalSalida.AutoSize = true;
        lblTerminalSalida.Font = new System.Drawing.Font("Segoe UI", 14F);
        lblTerminalSalida.Location = new System.Drawing.Point(28, 137);
        lblTerminalSalida.Name = "lblTerminalSalida";
        lblTerminalSalida.Size = new System.Drawing.Size(207, 32);
        lblTerminalSalida.TabIndex = 4;
        lblTerminalSalida.Text = "Terminal de Salida";
        // 
        // cboTerminalSalida
        // 
        cboTerminalSalida.DropDownStyle = ComboBoxStyle.DropDownList;
        cboTerminalSalida.Font = new System.Drawing.Font("Segoe UI", 14F);
        cboTerminalSalida.FormattingEnabled = true;
        cboTerminalSalida.Items.AddRange(new object[] { "SAN JOSE", "EL COCO" });
        cboTerminalSalida.Location = new System.Drawing.Point(308, 134);
        cboTerminalSalida.Name = "cboTerminalSalida";
        cboTerminalSalida.Size = new System.Drawing.Size(240, 39);
        cboTerminalSalida.TabIndex = 5;
        // 
        // lblTerminalLlegada
        // 
        lblTerminalLlegada.AutoSize = true;
        lblTerminalLlegada.Font = new System.Drawing.Font("Segoe UI", 14F);
        lblTerminalLlegada.Location = new System.Drawing.Point(28, 191);
        lblTerminalLlegada.Name = "lblTerminalLlegada";
        lblTerminalLlegada.Size = new System.Drawing.Size(223, 32);
        lblTerminalLlegada.TabIndex = 6;
        lblTerminalLlegada.Text = "Terminal de Llegada";
        // 
        // cboTerminalLlegada
        // 
        cboTerminalLlegada.DropDownStyle = ComboBoxStyle.DropDownList;
        cboTerminalLlegada.Font = new System.Drawing.Font("Segoe UI", 14F);
        cboTerminalLlegada.FormattingEnabled = true;
        cboTerminalLlegada.Items.AddRange(new object[] { "SAN JOSE", "EL COCO" });
        cboTerminalLlegada.Location = new System.Drawing.Point(308, 188);
        cboTerminalLlegada.Name = "cboTerminalLlegada";
        cboTerminalLlegada.Size = new System.Drawing.Size(240, 39);
        cboTerminalLlegada.TabIndex = 7;
        // 
        // lblCapacidad
        // 
        lblCapacidad.AutoSize = true;
        lblCapacidad.Font = new System.Drawing.Font("Segoe UI", 14F);
        lblCapacidad.Location = new System.Drawing.Point(28, 245);
        lblCapacidad.Name = "lblCapacidad";
        lblCapacidad.Size = new System.Drawing.Size(123, 32);
        lblCapacidad.TabIndex = 8;
        lblCapacidad.Text = "Capacidad";
        // 
        // txtCapacidad
        // 
        txtCapacidad.Font = new System.Drawing.Font("Segoe UI", 14F);
        txtCapacidad.Location = new System.Drawing.Point(308, 242);
        txtCapacidad.Name = "txtCapacidad";
        txtCapacidad.Size = new System.Drawing.Size(240, 39);
        txtCapacidad.TabIndex = 9;
        // 
        // lblCosto
        // 
        lblCosto.AutoSize = true;
        lblCosto.Font = new System.Drawing.Font("Segoe UI", 14F);
        lblCosto.Location = new System.Drawing.Point(28, 299);
        lblCosto.Name = "lblCosto";
        lblCosto.Size = new System.Drawing.Size(75, 32);
        lblCosto.TabIndex = 10;
        lblCosto.Text = "Costo";
        // 
        // txtCosto
        // 
        txtCosto.Font = new System.Drawing.Font("Segoe UI", 14F);
        txtCosto.Location = new System.Drawing.Point(308, 296);
        txtCosto.Name = "txtCosto";
        txtCosto.Size = new System.Drawing.Size(240, 39);
        txtCosto.TabIndex = 11;
        txtCosto.TextAlign = HorizontalAlignment.Right;
        // 
        // btnGrabar
        // 
        btnGrabar.Font = new System.Drawing.Font("Segoe UI", 12F);
        btnGrabar.Location = new System.Drawing.Point(308, 359);
        btnGrabar.Name = "btnGrabar";
        btnGrabar.Size = new System.Drawing.Size(111, 44);
        btnGrabar.TabIndex = 12;
        btnGrabar.Text = "Grabar";
        btnGrabar.UseVisualStyleBackColor = true;
        btnGrabar.Click += btnGrabar_Click;
        // 
        // btnEliminar
        // 
        btnEliminar.Enabled = false;
        btnEliminar.Font = new System.Drawing.Font("Segoe UI", 12F);
        btnEliminar.Location = new System.Drawing.Point(425, 359);
        btnEliminar.Name = "btnEliminar";
        btnEliminar.Size = new System.Drawing.Size(111, 44);
        btnEliminar.TabIndex = 13;
        btnEliminar.Text = "Eliminar";
        btnEliminar.UseVisualStyleBackColor = true;
        // 
        // btnLimpiar
        // 
        btnLimpiar.Font = new System.Drawing.Font("Segoe UI", 12F);
        btnLimpiar.Location = new System.Drawing.Point(542, 359);
        btnLimpiar.Name = "btnLimpiar";
        btnLimpiar.Size = new System.Drawing.Size(111, 44);
        btnLimpiar.TabIndex = 14;
        btnLimpiar.Text = "Limpiar";
        btnLimpiar.UseVisualStyleBackColor = true;
        btnLimpiar.Click += btnLimpiar_Click;
        // 
        // btnSalir
        // 
        btnSalir.Font = new System.Drawing.Font("Segoe UI", 12F);
        btnSalir.Location = new System.Drawing.Point(659, 359);
        btnSalir.Name = "btnSalir";
        btnSalir.Size = new System.Drawing.Size(111, 44);
        btnSalir.TabIndex = 15;
        btnSalir.Text = "Salir";
        btnSalir.UseVisualStyleBackColor = true;
        btnSalir.Click += btnSalir_Click;
        // 
        // dgvViajes
        // 
        dgvViajes.AllowUserToAddRows = false;
        dgvViajes.AllowUserToDeleteRows = false;
        dgvViajes.AllowUserToResizeRows = false;
        dgvViajes.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
        dgvViajes.Columns.AddRange(new DataGridViewColumn[] { colCodigo, colTerminalSalida, colTerminalLlegada, colCapacidad, colCosto, colCapacidadDisponible });
        dgvViajes.Location = new System.Drawing.Point(28, 423);
        dgvViajes.MultiSelect = false;
        dgvViajes.Name = "dgvViajes";
        dgvViajes.ReadOnly = true;
        dgvViajes.RowHeadersVisible = false;
        dgvViajes.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        dgvViajes.Size = new System.Drawing.Size(742, 196);
        dgvViajes.TabIndex = 16;
        // 
        // colCodigo
        // 
        colCodigo.HeaderText = "CODIGO";
        colCodigo.Name = "colCodigo";
        colCodigo.ReadOnly = true;
        colCodigo.Width = 90;
        // 
        // colTerminalSalida
        // 
        colTerminalSalida.HeaderText = "TERMINAL SALIDA";
        colTerminalSalida.Name = "colTerminalSalida";
        colTerminalSalida.ReadOnly = true;
        colTerminalSalida.Width = 140;
        // 
        // colTerminalLlegada
        // 
        colTerminalLlegada.HeaderText = "TERMINAL LLEGADA";
        colTerminalLlegada.Name = "colTerminalLlegada";
        colTerminalLlegada.ReadOnly = true;
        colTerminalLlegada.Width = 140;
        // 
        // colCapacidad
        // 
        colCapacidad.HeaderText = "CAPACIDAD";
        colCapacidad.Name = "colCapacidad";
        colCapacidad.ReadOnly = true;
        colCapacidad.Width = 110;
        // 
        // colCosto
        // 
        colCosto.HeaderText = "COSTO";
        colCosto.Name = "colCosto";
        colCosto.ReadOnly = true;
        colCosto.Width = 110;
        // 
        // colCapacidadDisponible
        // 
        colCapacidadDisponible.HeaderText = "CAPACIDAD DISPONIBLE";
        colCapacidadDisponible.Name = "colCapacidadDisponible";
        colCapacidadDisponible.ReadOnly = true;
        colCapacidadDisponible.Width = 150;
        // 
        // FrmMantenimientoViajes
        // 
        AutoScaleMode = AutoScaleMode.Font;
        ClientSize = new System.Drawing.Size(800, 640);
        Controls.Add(dgvViajes);
        Controls.Add(btnSalir);
        Controls.Add(btnLimpiar);
        Controls.Add(btnEliminar);
        Controls.Add(btnGrabar);
        Controls.Add(txtCosto);
        Controls.Add(lblCosto);
        Controls.Add(txtCapacidad);
        Controls.Add(lblCapacidad);
        Controls.Add(cboTerminalLlegada);
        Controls.Add(lblTerminalLlegada);
        Controls.Add(cboTerminalSalida);
        Controls.Add(lblTerminalSalida);
        Controls.Add(txtDescripcion);
        Controls.Add(lblDescripcion);
        Controls.Add(txtCodigo);
        Controls.Add(lblCodigo);
        FormBorderStyle = FormBorderStyle.FixedSingle;
        MaximizeBox = false;
        Name = "FrmMantenimientoViajes";
        StartPosition = FormStartPosition.CenterParent;
        Text = "Mantenimiento de Viajes";
        ((System.ComponentModel.ISupportInitialize)dgvViajes).EndInit();
        ResumeLayout(false);
        PerformLayout();
    }

    #endregion

    private Label lblCodigo;
    private TextBox txtCodigo;
    private Label lblDescripcion;
    private TextBox txtDescripcion;
    private Label lblTerminalSalida;
    private ComboBox cboTerminalSalida;
    private Label lblTerminalLlegada;
    private ComboBox cboTerminalLlegada;
    private Label lblCapacidad;
    private TextBox txtCapacidad;
    private Label lblCosto;
    private TextBox txtCosto;
    private Button btnGrabar;
    private Button btnEliminar;
    private Button btnLimpiar;
    private Button btnSalir;
    private DataGridView dgvViajes;
    private DataGridViewTextBoxColumn colCodigo;
    private DataGridViewTextBoxColumn colTerminalSalida;
    private DataGridViewTextBoxColumn colTerminalLlegada;
    private DataGridViewTextBoxColumn colCapacidad;
    private DataGridViewTextBoxColumn colCosto;
    private DataGridViewTextBoxColumn colCapacidadDisponible;
}