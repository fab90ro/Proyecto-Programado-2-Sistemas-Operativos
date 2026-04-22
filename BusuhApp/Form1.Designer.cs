namespace BusuhApp;

partial class Form1
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
        lblTitulo = new Label();
        btnTerminales = new Button();
        btnViajes = new Button();
        btnSocket = new Button();
        SuspendLayout();
        // 
        // lblTitulo
        // 
        lblTitulo.AutoSize = true;
        lblTitulo.Font = new System.Drawing.Font("Segoe UI", 18F, FontStyle.Bold, GraphicsUnit.Point, 0);
        lblTitulo.Location = new System.Drawing.Point(84, 37);
        lblTitulo.Name = "lblTitulo";
        lblTitulo.Size = new System.Drawing.Size(230, 41);
        lblTitulo.TabIndex = 0;
        lblTitulo.Text = "Menu Principal";
        // 
        // btnTerminales
        // 
        btnTerminales.Font = new System.Drawing.Font("Segoe UI", 11F);
        btnTerminales.Location = new System.Drawing.Point(78, 105);
        btnTerminales.Name = "btnTerminales";
        btnTerminales.Size = new System.Drawing.Size(241, 67);
        btnTerminales.TabIndex = 1;
        btnTerminales.Text = "Mantenimiento de\r\nTerminales";
        btnTerminales.UseVisualStyleBackColor = true;
        // 
        // btnViajes
        // 
        btnViajes.Font = new System.Drawing.Font("Segoe UI", 11F);
        btnViajes.Location = new System.Drawing.Point(78, 189);
        btnViajes.Name = "btnViajes";
        btnViajes.Size = new System.Drawing.Size(241, 67);
        btnViajes.TabIndex = 2;
        btnViajes.Text = "Mantenimiento de\r\nViajes";
        btnViajes.UseVisualStyleBackColor = true;
        btnViajes.Click += btnViajes_Click;
        // 
        // btnSocket
        // 
        btnSocket.Font = new System.Drawing.Font("Segoe UI", 11F);
        btnSocket.Location = new System.Drawing.Point(78, 273);
        btnSocket.Name = "btnSocket";
        btnSocket.Size = new System.Drawing.Size(241, 67);
        btnSocket.TabIndex = 3;
        btnSocket.Text = "Socket de\r\nComunicacion";
        btnSocket.UseVisualStyleBackColor = true;
        btnSocket.Click += btnSocket_Click;
        AutoScaleMode = AutoScaleMode.Font;
        ClientSize = new Size(400, 380);
        Controls.Add(btnSocket);
        Controls.Add(btnViajes);
        Controls.Add(btnTerminales);
        Controls.Add(lblTitulo);
        FormBorderStyle = FormBorderStyle.FixedSingle;
        MaximizeBox = false;
        Name = "Form1";
        StartPosition = FormStartPosition.CenterScreen;
        Text = "Frm_Principal";
        ResumeLayout(false);
        PerformLayout();
    }

    #endregion

    private Label lblTitulo;
    private Button btnTerminales;
    private Button btnViajes;
    private Button btnSocket;
}
