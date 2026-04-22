namespace BusuhApp;

public partial class FrmMantenimientoViajes : Form
{
    public FrmMantenimientoViajes()
    {
        InitializeComponent();
        CargarViajesEnGrilla();
    }

    private void btnGrabar_Click(object sender, EventArgs e)
    {
        if (!ValidarDatos(out int codigo, out int capacidad, out decimal costo))
        {
            return;
        }

        Viaje viaje = new()
        {
            CodigoViaje = codigo,
            Descripcion = txtDescripcion.Text.Trim(),
            TerminalSalida = cboTerminalSalida.Text,
            TerminalLlegada = cboTerminalLlegada.Text,
            Capacidad = capacidad,
            CapacidadDisponible = capacidad,
            Costo = costo
        };

        if (!ViajesRepository.TryAgregarViaje(viaje, out string mensajeError))
        {
            MessageBox.Show(mensajeError, "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            return;
        }

        AgregarViajeAGrilla(viaje);

        MessageBox.Show("Viaje registrado correctamente.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
        LimpiarCampos();
    }

    private void btnLimpiar_Click(object sender, EventArgs e)
    {
        LimpiarCampos();
    }

    private void btnSalir_Click(object sender, EventArgs e)
    {
        Close();
    }

    private bool ValidarDatos(out int codigo, out int capacidad, out decimal costo)
    {
        codigo = 0;
        capacidad = 0;
        costo = 0;

        if (!int.TryParse(txtCodigo.Text.Trim(), out codigo) || codigo <= 0)
        {
            MessageBox.Show("Ingrese un código de viaje válido.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            txtCodigo.Focus();
            return false;
        }

        if (string.IsNullOrWhiteSpace(txtDescripcion.Text))
        {
            MessageBox.Show("Ingrese una descripción.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            txtDescripcion.Focus();
            return false;
        }

        if (cboTerminalSalida.SelectedIndex < 0)
        {
            MessageBox.Show("Seleccione la terminal de salida.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            cboTerminalSalida.Focus();
            return false;
        }

        if (cboTerminalLlegada.SelectedIndex < 0)
        {
            MessageBox.Show("Seleccione la terminal de llegada.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            cboTerminalLlegada.Focus();
            return false;
        }

        if (cboTerminalSalida.Text == cboTerminalLlegada.Text)
        {
            MessageBox.Show("La terminal de salida y llegada deben ser diferentes.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            cboTerminalLlegada.Focus();
            return false;
        }

        if (!int.TryParse(txtCapacidad.Text.Trim(), out capacidad) || capacidad <= 0)
        {
            MessageBox.Show("Ingrese una capacidad válida.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            txtCapacidad.Focus();
            return false;
        }

        if (!decimal.TryParse(txtCosto.Text.Trim(), out costo) || costo <= 0)
        {
            MessageBox.Show("Ingrese un costo válido.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            txtCosto.Focus();
            return false;
        }

        return true;
    }

    private void CargarViajesEnGrilla()
    {
        dgvViajes.Rows.Clear();
        foreach (Viaje viaje in ViajesRepository.ObtenerViajes())
        {
            AgregarViajeAGrilla(viaje);
        }
    }

    private void AgregarViajeAGrilla(Viaje viaje)
    {
        dgvViajes.Rows.Add(
            viaje.CodigoViaje.ToString("D2"),
            viaje.TerminalSalida,
            viaje.TerminalLlegada,
            viaje.Capacidad,
            viaje.Costo.ToString("N0"),
            viaje.CapacidadDisponible);
    }

    private void LimpiarCampos()
    {
        txtCodigo.Clear();
        txtDescripcion.Clear();
        cboTerminalSalida.SelectedIndex = -1;
        cboTerminalLlegada.SelectedIndex = -1;
        txtCapacidad.Clear();
        txtCosto.Clear();
        txtCodigo.Focus();
    }
}