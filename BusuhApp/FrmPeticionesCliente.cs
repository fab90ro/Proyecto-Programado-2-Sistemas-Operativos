using System.Net.Sockets;
using System.Text;

namespace BusuhApp;

public partial class FrmPeticionesCliente : Form
{
    private const int PuertoServidor = 30000;
    private TcpClient? _client;
    private NetworkStream? _stream;

    public FrmPeticionesCliente()
    {
        InitializeComponent();
    }

    protected override void OnFormClosing(FormClosingEventArgs e)
    {
        Desconectar();
        base.OnFormClosing(e);
    }

    private async void btnConectar_Click(object sender, EventArgs e)
    {
        try
        {
            if (string.IsNullOrWhiteSpace(txtServidor.Text))
            {
                MessageBox.Show("Digite una dirección IP.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            _client = new TcpClient();
            await _client.ConnectAsync(txtServidor.Text.Trim(), PuertoServidor);
            _stream = _client.GetStream();

            btnConectar.Enabled = false;
            btnDesconectar.Enabled = true;
            btnEnviar.Enabled = true;
            txtServidor.Enabled = false;

            AgregarBitacora($"Conectado a {txtServidor.Text.Trim()}:{PuertoServidor}.");
        }
        catch (Exception ex)
        {
            Desconectar();
            AgregarBitacora($"No se pudo conectar: {ex.Message}");
            MessageBox.Show("No se pudo conectar al servidor.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }

    private void btnDesconectar_Click(object sender, EventArgs e)
    {
        Desconectar();
        AgregarBitacora("Cliente desconectado.");
    }

    private async void btnEnviar_Click(object sender, EventArgs e)
    {
        if (_stream is null || _client is null || !_client.Connected)
        {
            MessageBox.Show("No hay conexión activa con el servidor.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
            return;
        }

        string trama = txtTrama.Text.Trim();
        if (!ValidarTramaSolicitud(trama))
        {
            MessageBox.Show("La trama debe ser de 3 dígitos: 01-02 código de viaje y 03 cantidad (1 a 5).", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            return;
        }

        try
        {
            byte[] solicitud = Encoding.UTF8.GetBytes(trama);
            await _stream.WriteAsync(solicitud.AsMemory(0, solicitud.Length));
            AgregarBitacora($"Solicitud enviada: {trama}");

            string respuesta = await LeerRespuestaAsync(24);
            AgregarBitacora($"Respuesta recibida: {respuesta}");
        }
        catch (Exception ex)
        {
            AgregarBitacora($"Error al enviar/recibir: {ex.Message}");
            MessageBox.Show("Se perdió la conexión con el servidor.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            Desconectar();
        }
    }

    private async Task<string> LeerRespuestaAsync(int longitudEsperada)
    {
        if (_stream is null)
        {
            return string.Empty;
        }

        byte[] buffer = new byte[longitudEsperada];
        int totalLeido = 0;

        while (totalLeido < longitudEsperada)
        {
            int leido = await _stream.ReadAsync(buffer.AsMemory(totalLeido, longitudEsperada - totalLeido));
            if (leido == 0)
            {
                break;
            }

            totalLeido += leido;
        }

        return Encoding.UTF8.GetString(buffer, 0, totalLeido);
    }

    private static bool ValidarTramaSolicitud(string trama)
    {
        if (trama.Length != 3 || !trama.All(char.IsDigit))
        {
            return false;
        }

        int cantidad = int.Parse(trama.Substring(2, 1));

        return cantidad is >= 1 and <= 5;
    }

    private void Desconectar()
    {
        try
        {
            _stream?.Close();
            _client?.Close();
        }
        catch
        {
            // Ignorado
        }
        finally
        {
            _stream = null;
            _client = null;
            btnConectar.Enabled = true;
            btnDesconectar.Enabled = false;
            btnEnviar.Enabled = false;
            txtServidor.Enabled = true;
        }
    }

    private void AgregarBitacora(string mensaje)
    {
        lstBitacora.Items.Add($"{DateTime.Now:HH:mm:ss} - {mensaje}");
        lstBitacora.TopIndex = lstBitacora.Items.Count - 1;
    }
}
