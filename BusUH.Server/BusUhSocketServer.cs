using System.Net;
using System.Net.Sockets;
using System.Text;
using BusUH.Core.Services;

namespace BusUH.Server;

public sealed class BusUhSocketServer
{
    private readonly BusUhManager _manager;
    private readonly Encoding _encoding = Encoding.UTF8;
    private TcpListener? _listener;
    private CancellationTokenSource? _cts;
    private int _clientCount;

    public BusUhSocketServer(BusUhManager manager)
    {
        _manager = manager;
    }

    public event EventHandler<string>? LogGenerated;
    public event EventHandler<int>? ClientCountChanged;

    public Task StartAsync(int port)
    {
        if (_listener is not null)
        {
            throw new InvalidOperationException("El socket ya se encuentra iniciado.");
        }

        _cts = new CancellationTokenSource();
        _listener = new TcpListener(IPAddress.Any, port);
        _listener.Start();
        _ = AcceptLoopAsync(_cts.Token);
        return Task.CompletedTask;
    }

    public Task StopAsync()
    {
        _cts?.Cancel();
        _listener?.Stop();
        _cts = null;
        _listener = null;
        _clientCount = 0;
        ClientCountChanged?.Invoke(this, _clientCount);
        return Task.CompletedTask;
    }

    private async Task AcceptLoopAsync(CancellationToken cancellationToken)
    {
        while (!cancellationToken.IsCancellationRequested && _listener is not null)
        {
            try
            {
                var client = await _listener.AcceptTcpClientAsync(cancellationToken);
                _ = HandleClientAsync(client, cancellationToken);
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
                LogGenerated?.Invoke(this, $"Error en el socket: {ex.Message}");
            }
        }
    }

    private async Task HandleClientAsync(TcpClient client, CancellationToken cancellationToken)
    {
        Interlocked.Increment(ref _clientCount);
        ClientCountChanged?.Invoke(this, _clientCount);
        LogGenerated?.Invoke(this, $"Cliente conectado desde {client.Client.RemoteEndPoint}.");

        try
        {
            await using var stream = client.GetStream();
            using var reader = new StreamReader(stream, _encoding, leaveOpen: true);
            using var writer = new StreamWriter(stream, _encoding, leaveOpen: true) { AutoFlush = true };

            while (!cancellationToken.IsCancellationRequested && client.Connected)
            {
                var line = await reader.ReadLineAsync(cancellationToken);
                if (string.IsNullOrWhiteSpace(line))
                {
                    break;
                }

                var response = _manager.ProcessFrame(line);
                await writer.WriteLineAsync(response.ToFrame());
                LogGenerated?.Invoke(this, $"Solicitud: {line} | Respuesta: {response.ToFrame()} | {response.Message}");
            }
        }
        catch (OperationCanceledException)
        {
        }
        catch (IOException)
        {
        }
        catch (Exception ex)
        {
            LogGenerated?.Invoke(this, $"Error atendiendo cliente: {ex.Message}");
        }
        finally
        {
            client.Close();
            Interlocked.Decrement(ref _clientCount);
            ClientCountChanged?.Invoke(this, _clientCount);
            LogGenerated?.Invoke(this, "Cliente desconectado.");
        }
    }
}
