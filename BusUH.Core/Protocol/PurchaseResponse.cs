using BusUH.Core.Models;

namespace BusUH.Core.Protocol;

public sealed class PurchaseResponse
{
    public string StatusCode { get; init; } = "5";
    public string TripCode { get; init; } = "00";
    public SeatAllocation? FirstAllocation { get; init; }
    public SeatAllocation? SecondAllocation { get; init; }
    public decimal TransactionAmount { get; init; }
    public int AvailableSeats { get; init; }
    public string Message { get; init; } = string.Empty;

    public string ToFrame()
    {
        return string.Concat(
            StatusCode,
            TripCode.PadLeft(2, '0'),
            FirstAllocation is null ? "00" : FirstAllocation.RowNumber.ToString("00"),
            FirstAllocation?.SeatsFrame ?? "00000",
            SecondAllocation is null ? "00" : SecondAllocation.RowNumber.ToString("00"),
            SecondAllocation?.SeatsFrame ?? "00000",
            ((int)TransactionAmount).ToString("00000"),
            AvailableSeats.ToString("00"));
    }
}
