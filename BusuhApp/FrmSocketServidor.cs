using System.Net;
using System.Net.Sockets;
using System.Text;

namespace BusuhApp;

public partial class FrmSocketServidor : Form
{
    private const int PuertoServidor = 30000;
    private TcpListener? _listener;
    private CancellationTokenSource? _cts;
    private int _clientesConectados;

    public FrmSocketServidor()
    {
        InitializeComponent();
    }

    protected override void OnShown(EventArgs e)
    {
        base.OnShown(e);
        IniciarServidor();
    }

    protected override void OnFormClosing(FormClosingEventArgs e)
    {
        DetenerServidor();
        base.OnFormClosing(e);
    }

    private void IniciarServidor()
    {
        try
        {
            _cts = new CancellationTokenSource();
            _listener = new TcpListener(IPAddress.Any, PuertoServidor);
            _listener.Start();

            AgregarBitacora($"Servidor levantado en puerto {PuertoServidor}.");
            _ = AceptarClientesAsync(_cts.Token);
        }
        catch (Exception ex)
        {
            AgregarBitacora($"No se pudo iniciar el servidor: {ex.Message}");
            MessageBox.Show("No se pudo iniciar el socket del servidor.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }

    private void DetenerServidor()
    {
        try
        {
            _cts?.Cancel();
            _listener?.Stop();
            AgregarBitacora("Servidor detenido.");
        }
        catch
        {
            // Ignorado
        }
    }

    private async Task AceptarClientesAsync(CancellationToken cancellationToken)
    {
        if (_listener is null)
        {
            return;
        }

        while (!cancellationToken.IsCancellationRequested)
        {
            try
            {
                TcpClient client = await _listener.AcceptTcpClientAsync(cancellationToken);
                int clienteId = Interlocked.Increment(ref _clientesConectados);
                ActualizarCantidadClientes();
                AgregarBitacora($"Cliente conectado. Total: {_clientesConectados}");

                _ = ManejarClienteAsync(client, clienteId, cancellationToken);
            }
            catch (OperationCanceledException)
            {
                break;
            }
            catch (ObjectDisposedException)
            {
                break;
            }
            catch (Exception ex)
            {
                AgregarBitacora($"Error aceptando cliente: {ex.Message}");
            }
        }
    }

    private async Task ManejarClienteAsync(TcpClient client, int clienteId, CancellationToken cancellationToken)
    {
        try
        {
            using TcpClient _ = client;
            using NetworkStream networkStream = client.GetStream();
            byte[] buffer = new byte[1024];

            while (!cancellationToken.IsCancellationRequested)
            {
                int bytesLeidos = await networkStream.ReadAsync(buffer.AsMemory(0, buffer.Length), cancellationToken);
                if (bytesLeidos == 0)
                {
                    break;
                }

                string mensaje = Encoding.UTF8.GetString(buffer, 0, bytesLeidos).Trim();
                if (!string.IsNullOrWhiteSpace(mensaje))
                {
                    AgregarBitacora($"Cliente {clienteId}: {mensaje}");

                    string respuesta = ViajesRepository.ProcesarSolicitud(mensaje, out string detalleBitacora);
                    byte[] tramaRespuesta = Encoding.UTF8.GetBytes(respuesta);
                    await networkStream.WriteAsync(tramaRespuesta.AsMemory(0, tramaRespuesta.Length), cancellationToken);

                    AgregarBitacora($"Cliente {clienteId} respuesta: {respuesta}");
                    if (!string.IsNullOrWhiteSpace(detalleBitacora))
                    {
                        AgregarBitacora($"Bitácora: {detalleBitacora}");
                    }
                }
            }
        }
        catch (OperationCanceledException)
        {
        }
        catch (Exception ex)
        {
            AgregarBitacora($"Error en cliente {clienteId}: {ex.Message}");
        }
        finally
        {
            Interlocked.Decrement(ref _clientesConectados);
            ActualizarCantidadClientes();
            AgregarBitacora($"Cliente {clienteId} desconectado. Total: {_clientesConectados}");
        }
    }

    private void ActualizarCantidadClientes()
    {
        if (InvokeRequired)
        {
            BeginInvoke(ActualizarCantidadClientes);
            return;
        }

        txtClientesConectados.Text = _clientesConectados.ToString();
    }

    private void AgregarBitacora(string mensaje)
    {
        if (InvokeRequired)
        {
            BeginInvoke(() => AgregarBitacora(mensaje));
            return;
        }

        lstBitacora.Items.Add($"{DateTime.Now:HH:mm:ss} - {mensaje}");
        lstBitacora.TopIndex = lstBitacora.Items.Count - 1;
    }

    private void btnCliente_Click(object sender, EventArgs e)
    {
        FrmPeticionesCliente frm = new();
        frm.Show(this);
    }

    private void btnMapaAsientos_Click(object sender, EventArgs e)
    {
        if (!int.TryParse(txtCodigoMapa.Text.Trim(), out int codigoViaje) || codigoViaje <= 0)
        {
            MessageBox.Show("Digite un código de viaje válido.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            txtCodigoMapa.Focus();
            return;
        }

        FrmMapaAsientos frm = new(codigoViaje);
        frm.Show(this);
    }
}