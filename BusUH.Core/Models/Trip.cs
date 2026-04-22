namespace BusUH.Core.Models;

public sealed class Trip
{
    private readonly bool[,] _seatAvailability = new bool[13, 7];

    public string Code { get; set; } = string.Empty;
    public string DepartureTerminalCode { get; set; } = string.Empty;
    public string DepartureTerminalName { get; set; } = string.Empty;
    public string ArrivalTerminalCode { get; set; } = string.Empty;
    public string ArrivalTerminalName { get; set; } = string.Empty;
    public int Capacity { get; set; }
    public decimal Cost { get; set; }
    public int AvailableCapacity { get; private set; }

    public string DisplayRoute => $"{DepartureTerminalName} -> {ArrivalTerminalName}";

    public void InitializeSeats()
    {
        for (var row = 0; row < 13; row++)
        {
            for (var seat = 0; seat < 7; seat++)
            {
                _seatAvailability[row, seat] = seat < SeatsInRow(row + 1);
            }
        }

        AvailableCapacity = Capacity;
    }

    public List<SeatAllocation> ReserveSeats(int quantity)
    {
        if (quantity <= 0)
        {
            return [];
        }

        var allocations = new List<SeatAllocation>();
        var remaining = quantity;

        for (var row = 1; row <= 13 && remaining > 0; row++)
        {
            var allocation = new SeatAllocation { RowNumber = row };

            for (var seat = 1; seat <= SeatsInRow(row) && remaining > 0; seat++)
            {
                if (!_seatAvailability[row - 1, seat - 1])
                {
                    continue;
                }

                _seatAvailability[row - 1, seat - 1] = false;
                allocation.Seats.Add(seat);
                remaining--;
            }

            if (allocation.Seats.Count > 0)
            {
                allocations.Add(allocation);
            }
        }

        if (remaining > 0)
        {
            foreach (var allocation in allocations)
            {
                foreach (var seat in allocation.Seats)
                {
                    _seatAvailability[allocation.RowNumber - 1, seat - 1] = true;
                }
            }

            return [];
        }

        AvailableCapacity -= quantity;
        return allocations;
    }

    public string SeatAvailabilitySummary()
    {
        var lines = new List<string>();

        for (var row = 1; row <= 13; row++)
        {
            var line = string.Concat(
                Enumerable.Range(1, SeatsInRow(row))
                    .Select(seat => _seatAvailability[row - 1, seat - 1] ? '1' : '0'));

            lines.Add($"Fila {row:00}: {line}");
        }

        return string.Join(Environment.NewLine, lines);
    }

    public int SeatsInRow(int rowNumber) => rowNumber == 13 ? 7 : 5;
}
