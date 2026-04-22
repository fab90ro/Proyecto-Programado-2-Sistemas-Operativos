namespace BusuhApp;

public partial class FrmMapaAsientos : Form
{
    private readonly int _codigoViaje;

    public FrmMapaAsientos(int codigoViaje)
    {
        _codigoViaje = codigoViaje;
        InitializeComponent();
    }

    protected override void OnShown(EventArgs e)
    {
        base.OnShown(e);
        txtCodigo.Text = _codigoViaje.ToString("D2");
        RefrescarMapa();
    }

    private void btnActualizar_Click(object sender, EventArgs e)
    {
        RefrescarMapa();
    }

    private void RefrescarMapa()
    {
        if (!ViajesRepository.TryObtenerEstadoViaje(_codigoViaje, out int[,] asientos, out int disponibles, out string descripcion))
        {
            MessageBox.Show($"No existe el viaje {_codigoViaje:D2}.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
            Close();
            return;
        }

        txtDescripcion.Text = descripcion;
        txtDisponibles.Text = disponibles.ToString();

        flpAsientos.SuspendLayout();
        flpAsientos.Controls.Clear();
        flpAsientos.FlowDirection = FlowDirection.TopDown;
        flpAsientos.WrapContents = false;
        flpAsientos.AutoScroll = true;

        for (int fila = 0; fila < 13; fila++)
        {
            FlowLayoutPanel filaPanel = new()
            {
                FlowDirection = FlowDirection.LeftToRight,
                WrapContents = false,
                AutoSize = true,
                Margin = new Padding(0, 0, 0, 4)
            };

            for (int col = 0; col < 7; col++)
            {
                bool asientoExiste = fila == 12 || col < 5;
                Button btn = new()
                {
                    Width = 46,
                    Height = 32,
                    Margin = new Padding(3),
                    Enabled = false,
                    Text = asientoExiste ? $"{fila + 1:D2}-{col + 1}" : "--"
                };

                if (!asientoExiste)
                {
                    btn.BackColor = Color.LightGray;
                }
                else
                {
                    bool libre = asientos[fila, col] == 1;
                    btn.BackColor = libre ? Color.LightGreen : Color.IndianRed;
                }

                filaPanel.Controls.Add(btn);
            }

            flpAsientos.Controls.Add(filaPanel);
        }

        flpAsientos.ResumeLayout();
    }
}
