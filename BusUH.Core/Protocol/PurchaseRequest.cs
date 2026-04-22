namespace BusUH.Core.Protocol;

public sealed class PurchaseRequest
{
    public string TripCode { get; init; } = string.Empty;
    public int Quantity { get; init; }

    public static bool TryParse(string frame, out PurchaseRequest? request)
    {
        request = null;

        if (string.IsNullOrWhiteSpace(frame))
        {
            return false;
        }

        var sanitized = frame.Trim();
        if (sanitized.Length != 3)
        {
            return false;
        }

        var tripCode = sanitized[..2];
        if (!int.TryParse(sanitized[2..3], out var quantity))
        {
            return false;
        }

        request = new PurchaseRequest
        {
            TripCode = tripCode,
            Quantity = quantity
        };

        return true;
    }
}
