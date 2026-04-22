namespace BusUH.Core.Models;

public sealed class SeatAllocation
{
    public int RowNumber { get; init; }
    public List<int> Seats { get; } = [];

    public string SeatsFrame => string.Concat(Seats.Select(seat => seat.ToString())).PadRight(5, '0');
}
