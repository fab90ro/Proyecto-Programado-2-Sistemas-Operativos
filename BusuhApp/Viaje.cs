namespace BusuhApp;

public class Viaje
{
    public int CodigoViaje { get; set; }
    public string Descripcion { get; set; } = string.Empty;
    public string TerminalSalida { get; set; } = string.Empty;
    public string TerminalLlegada { get; set; } = string.Empty;
    public int Capacidad { get; set; }
    public decimal Costo { get; set; }
    public int CapacidadDisponible { get; set; }
    public int[,] Asientos { get; set; }

    public Viaje()
    {
        Asientos = new int[13, 7];
    }

    public void LlenarDisponibilidadAsientos()
    {
        for (int fila = 0; fila < 13; fila++)
        {
            for (int col = 0; col < 7; col++)
            {
                if (fila < 12)
                {
                    Asientos[fila, col] = col < 5 ? 1 : 0;
                }
                else
                {
                    Asientos[fila, col] = 1;
                }
            }
        }
    }

    public string ObtenerDisponibilidadFila(int fila)
    {
        if (fila < 0 || fila >= Asientos.GetLength(0))
        {
            return string.Empty;
        }

        char[] resultado = new char[Asientos.GetLength(1)];
        for (int col = 0; col < Asientos.GetLength(1); col++)
        {
            resultado[col] = Asientos[fila, col] == 1 ? '1' : '0';
        }

        return new string(resultado);
    }

    public int ObtenerAsientosDisponiblesEnFila(int fila)
    {
        if (fila < 0 || fila >= Asientos.GetLength(0))
        {
            return 0;
        }

        int disponibles = 0;
        for (int col = 0; col < Asientos.GetLength(1); col++)
        {
            if (Asientos[fila, col] == 1)
            {
                disponibles++;
            }
        }

        return disponibles;
    }

    public List<int> ReservarAsientosEnFila(int fila, int cantidad)
    {
        List<int> asientosReservados = new();
        if (fila < 0 || fila >= Asientos.GetLength(0) || cantidad <= 0)
        {
            return asientosReservados;
        }

        for (int col = 0; col < Asientos.GetLength(1) && asientosReservados.Count < cantidad; col++)
        {
            if (Asientos[fila, col] == 1)
            {
                Asientos[fila, col] = 0;
                asientosReservados.Add(col + 1);
            }
        }

        return asientosReservados;
    }
}
