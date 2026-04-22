using System.Text;

namespace BusuhApp;

public static class ViajesRepository
{
    private const int MaxViajes = 100;
    private const int LongitudTramaRespuesta = 24;
    private static readonly object SyncRoot = new();
    private static readonly List<Viaje> Viajes = new();

    public static IReadOnlyList<Viaje> ObtenerViajes()
    {
        lock (SyncRoot)
        {
            return Viajes.ToList();
        }
    }

    public static bool TryObtenerEstadoViaje(int codigoViaje, out int[,] asientos, out int capacidadDisponible, out string descripcion)
    {
        lock (SyncRoot)
        {
            Viaje? viaje = Viajes.FirstOrDefault(v => v.CodigoViaje == codigoViaje);
            if (viaje is null)
            {
                asientos = new int[13, 7];
                capacidadDisponible = 0;
                descripcion = string.Empty;
                return false;
            }

            asientos = (int[,])viaje.Asientos.Clone();
            capacidadDisponible = viaje.CapacidadDisponible;
            descripcion = viaje.Descripcion;
            return true;
        }
    }

    public static bool TryAgregarViaje(Viaje viaje, out string mensajeError)
    {
        lock (SyncRoot)
        {
            if (Viajes.Count >= MaxViajes)
            {
                mensajeError = "No se pueden registrar más viajes.";
                return false;
            }

            if (Viajes.Any(v => v.CodigoViaje == viaje.CodigoViaje))
            {
                mensajeError = "El código de viaje ya existe.";
                return false;
            }

            viaje.LlenarDisponibilidadAsientos();
            viaje.CapacidadDisponible = viaje.Capacidad;
            Viajes.Add(viaje);
            mensajeError = string.Empty;
            return true;
        }
    }

    public static string ProcesarSolicitud(string tramaSolicitud, out string bitacora)
    {
        bitacora = string.Empty;

        if (!TryParseSolicitud(tramaSolicitud, out int codigoViaje, out int cantidad))
        {
            bitacora = "Formato inválido.";
            return ConstruirTramaRespuesta('5', 0, 0, string.Empty, 0, string.Empty, 0, 0);
        }

        lock (SyncRoot)
        {
            if (cantidad > 5)
            {
                bitacora = $"Solicitud rechazada. Viaje {codigoViaje:D2}, cantidad {cantidad} excede límite.";
                return ConstruirTramaRespuesta('3', codigoViaje, 0, string.Empty, 0, string.Empty, 0, 0);
            }

            Viaje? viaje = Viajes.FirstOrDefault(v => v.CodigoViaje == codigoViaje);
            if (viaje is null)
            {
                bitacora = $"Código de viaje no existe: {codigoViaje:D2}.";
                return ConstruirTramaRespuesta('4', codigoViaje, 0, string.Empty, 0, string.Empty, 0, 0);
            }

            if (cantidad <= 0)
            {
                bitacora = $"Formato inválido para viaje {codigoViaje:D2}.";
                return ConstruirTramaRespuesta('5', codigoViaje, 0, string.Empty, 0, string.Empty, 0, 0);
            }

            if (viaje.CapacidadDisponible < cantidad)
            {
                bitacora = $"Sin espacios disponibles suficientes en viaje {codigoViaje:D2}.";
                return ConstruirTramaRespuesta('0', codigoViaje, 0, string.Empty, 0, string.Empty, 0, viaje.CapacidadDisponible);
            }

            if (!TryReservarAsientos(viaje, cantidad, out int fila1, out List<int> asientosFila1, out int fila2, out List<int> asientosFila2))
            {
                bitacora = $"No se pudo asignar asientos en viaje {codigoViaje:D2}.";
                return ConstruirTramaRespuesta('0', codigoViaje, 0, string.Empty, 0, string.Empty, 0, viaje.CapacidadDisponible);
            }

            viaje.CapacidadDisponible -= cantidad;
            int montoTransaccion = (int)(viaje.Costo * cantidad);
            string seats1 = string.Concat(asientosFila1.Select(a => a.ToString()));
            string seats2 = string.Concat(asientosFila2.Select(a => a.ToString()));
            string respuesta = ConstruirTramaRespuesta('1', codigoViaje, fila1, seats1, fila2, seats2, montoTransaccion, viaje.CapacidadDisponible);

            bitacora = $"Viaje {codigoViaje:D2}, cantidad {cantidad}, F1:{fila1:D2} S1:{seats1.PadRight(5, '0')} F2:{fila2:D2} S2:{seats2.PadRight(5, '0')} MONTO:{montoTransaccion:D5} DISP:{viaje.CapacidadDisponible:D2}";
            return respuesta;
        }
    }

    private static bool TryParseSolicitud(string tramaSolicitud, out int codigoViaje, out int cantidad)
    {
        codigoViaje = 0;
        cantidad = 0;

        if (string.IsNullOrWhiteSpace(tramaSolicitud))
        {
            return false;
        }

        string trama = tramaSolicitud.Trim();
        if (trama.Length != 3 || !trama.All(char.IsDigit))
        {
            return false;
        }

        return int.TryParse(trama.Substring(0, 2), out codigoViaje)
               && int.TryParse(trama.Substring(2, 1), out cantidad);
    }

    private static bool TryReservarAsientos(Viaje viaje, int cantidad, out int fila1, out List<int> asientosFila1, out int fila2, out List<int> asientosFila2)
    {
        fila1 = 0;
        fila2 = 0;
        asientosFila1 = new List<int>();
        asientosFila2 = new List<int>();

        int totalFilas = viaje.Asientos.GetLength(0);

        for (int fila = 0; fila < totalFilas; fila++)
        {
            int disponibles = viaje.ObtenerAsientosDisponiblesEnFila(fila);
            if (disponibles >= cantidad)
            {
                fila1 = fila + 1;
                asientosFila1 = viaje.ReservarAsientosEnFila(fila, cantidad);
                return asientosFila1.Count == cantidad;
            }
        }

        for (int filaA = 0; filaA < totalFilas; filaA++)
        {
            int disponiblesA = viaje.ObtenerAsientosDisponiblesEnFila(filaA);
            if (disponiblesA == 0)
            {
                continue;
            }

            for (int filaB = filaA + 1; filaB < totalFilas; filaB++)
            {
                int disponiblesB = viaje.ObtenerAsientosDisponiblesEnFila(filaB);
                if (disponiblesA + disponiblesB < cantidad)
                {
                    continue;
                }

                int reservarA = Math.Min(disponiblesA, cantidad);
                int reservarB = cantidad - reservarA;

                fila1 = filaA + 1;
                fila2 = filaB + 1;
                asientosFila1 = viaje.ReservarAsientosEnFila(filaA, reservarA);
                asientosFila2 = reservarB > 0 ? viaje.ReservarAsientosEnFila(filaB, reservarB) : new List<int>();

                return asientosFila1.Count + asientosFila2.Count == cantidad;
            }
        }

        return false;
    }

    private static string ConstruirTramaRespuesta(char verificador, int codigoViaje, int fila1, string asientosFila1, int fila2, string asientosFila2, int montoTransaccion, int asientosDisponibles)
    {
        StringBuilder trama = new(LongitudTramaRespuesta);
        trama.Append(verificador);
        trama.Append(codigoViaje.ToString("D2"));
        trama.Append(Math.Clamp(fila1, 0, 99).ToString("D2"));
        trama.Append((asientosFila1 ?? string.Empty).PadRight(5, '0')[..5]);
        trama.Append(Math.Clamp(fila2, 0, 99).ToString("D2"));
        trama.Append((asientosFila2 ?? string.Empty).PadRight(5, '0')[..5]);
        trama.Append(Math.Clamp(montoTransaccion, 0, 99999).ToString("D5"));
        trama.Append(Math.Clamp(asientosDisponibles, 0, 99).ToString("D2"));
        return trama.ToString();
    }
}
