using System.Net.Sockets;
using System.Text;

namespace BusUH.Client;

public partial class Form1 : Form
{
    private readonly Encoding _encoding = Encoding.UTF8;
    private TcpClient? _client;
    private StreamReader? _reader;
    private StreamWriter? _writer;

    public Form1()
    {
        InitializeComponent();
        cmbTripCode.SelectedIndex = 0;
    }

    private void btnGenerateFrame_Click(object sender, EventArgs e)
    {
        txtFrame.Text = $"{cmbTripCode.SelectedItem}{nudQuantity.Value}";
    }

    private async void btnConnect_Click(object sender, EventArgs e)
    {
        try
        {
            _client = new TcpClient();
            await _client.ConnectAsync(txtServerIp.Text.Trim(), (int)nudPort.Value);
            var stream = _client.GetStream();
            _reader = new StreamReader(stream, _encoding, leaveOpen: true);
            _writer = new StreamWriter(stream, _encoding, leaveOpen: true) { AutoFlush = true };

            ToggleConnection(isConnected: true);
            AppendClientLog("Conexion establecida.");
        }
        catch (Exception ex)
        {
            MessageBox.Show(ex.Message, "Cliente", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }

    private async void btnDisconnect_Click(object sender, EventArgs e)
    {
        await DisconnectAsync();
    }

    private async void btnSend_Click(object sender, EventArgs e)
    {
        if (_writer is null || _reader is null)
        {
            MessageBox.Show("Primero conectese al servidor.", "Cliente", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            return;
        }

        if (string.IsNullOrWhiteSpace(txtFrame.Text))
        {
            MessageBox.Show("Digite o genere una trama valida.", "Cliente", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            return;
        }

        try
        {
            await _writer.WriteLineAsync(txtFrame.Text.Trim());
            var response = await _reader.ReadLineAsync();
            txtResponse.Text = response ?? string.Empty;
            txtInterpretation.Text = InterpretResponse(response);
            AppendClientLog($"Solicitud enviada: {txtFrame.Text.Trim()} | Respuesta: {response}");
        }
        catch (Exception ex)
        {
            MessageBox.Show(ex.Message, "Cliente", MessageBoxButtons.OK, MessageBoxIcon.Error);
            await DisconnectAsync();
        }
    }

    private async void Form1_FormClosing(object sender, FormClosingEventArgs e)
    {
        await DisconnectAsync();
    }

    private async Task DisconnectAsync()
    {
        if (_writer is not null)
        {
            await _writer.FlushAsync();
        }

        _reader?.Dispose();
        _writer?.Dispose();
        _client?.Close();
        _reader = null;
        _writer = null;
        _client = null;
        ToggleConnection(isConnected: false);
        AppendClientLog("Conexion cerrada.");
    }

    private void ToggleConnection(bool isConnected)
    {
        btnConnect.Enabled = !isConnected;
        btnDisconnect.Enabled = isConnected;
        btnSend.Enabled = isConnected;
        txtServerIp.Enabled = !isConnected;
        nudPort.Enabled = !isConnected;
        lblConnectionStatusValue.Text = isConnected ? "Conectado" : "Desconectado";
    }

    private void AppendClientLog(string message)
    {
        txtLog.AppendText($"[{DateTime.Now:HH:mm:ss}] {message}{Environment.NewLine}");
    }

    private static string InterpretResponse(string? response)
    {
        if (string.IsNullOrWhiteSpace(response))
        {
            return "Sin respuesta del servidor.";
        }

        var statusMessage = response[0] switch
        {
            '0' => "No hay asientos disponibles.",
            '1' => "Transaccion exitosa.",
            '3' => "La cantidad supera el maximo de 5 boletos.",
            '4' => "El codigo de viaje no existe.",
            '5' => "La trama enviada tiene formato invalido.",
            _ => "Respuesta desconocida."
        };

        if (response.Length < 24)
        {
            return $"{statusMessage}{Environment.NewLine}Trama recibida: {response}";
        }

        var tripCode = response.Substring(1, 2);
        var row1 = response.Substring(3, 2);
        var seats1 = response.Substring(5, 5);
        var row2 = response.Substring(10, 2);
        var seats2 = response.Substring(12, 5);
        var amount = response.Substring(17, 5);
        var available = response.Substring(22, 2);

        return string.Join(
            Environment.NewLine,
            statusMessage,
            $"Codigo de viaje: {tripCode}",
            $"Fila 1: {row1} - Asientos: {seats1}",
            $"Fila 2: {row2} - Asientos: {seats2}",
            $"Monto de la transaccion: {amount}",
            $"Asientos disponibles: {available}");
    }
}
