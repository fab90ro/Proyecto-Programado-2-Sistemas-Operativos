using BusUH.Core.Models;
using BusUH.Core.Protocol;

namespace BusUH.Core.Services;

public sealed class BusUhManager
{
    private readonly Lock _sync = new();

    public BusUhManager()
    {
        Terminals =
        [
            new TerminalInfo { Code = "SJ", Name = "San Jose" },
            new TerminalInfo { Code = "CC", Name = "El Coco" }
        ];

        Trips =
        [
            CreateTrip("01", Terminals[0], Terminals[1], 67, 3500m),
            CreateTrip("02", Terminals[1], Terminals[0], 67, 4000m)
        ];
    }

    public List<TerminalInfo> Terminals { get; }
    public List<Trip> Trips { get; }

    public Trip CreateTrip(string code, TerminalInfo departure, TerminalInfo arrival, int capacity, decimal cost)
    {
        var trip = new Trip
        {
            Code = code,
            DepartureTerminalCode = departure.Code,
            DepartureTerminalName = departure.Name,
            ArrivalTerminalCode = arrival.Code,
            ArrivalTerminalName = arrival.Name,
            Capacity = capacity,
            Cost = cost
        };

        trip.InitializeSeats();
        return trip;
    }

    public void SaveTerminal(TerminalInfo terminal)
    {
        lock (_sync)
        {
            var existing = Terminals.FirstOrDefault(t => t.Code.Equals(terminal.Code, StringComparison.OrdinalIgnoreCase));
            if (existing is null)
            {
                Terminals.Add(terminal);
                return;
            }

            existing.Name = terminal.Name;
        }
    }

    public void SaveTrip(Trip trip)
    {
        lock (_sync)
        {
            var existing = Trips.FirstOrDefault(t => t.Code.Equals(trip.Code, StringComparison.OrdinalIgnoreCase));
            if (existing is null)
            {
                trip.InitializeSeats();
                Trips.Add(trip);
                return;
            }

            existing.DepartureTerminalCode = trip.DepartureTerminalCode;
            existing.DepartureTerminalName = trip.DepartureTerminalName;
            existing.ArrivalTerminalCode = trip.ArrivalTerminalCode;
            existing.ArrivalTerminalName = trip.ArrivalTerminalName;
            existing.Capacity = trip.Capacity;
            existing.Cost = trip.Cost;
            existing.InitializeSeats();
        }
    }

    public PurchaseResponse ProcessFrame(string frame)
    {
        if (!PurchaseRequest.TryParse(frame, out var request))
        {
            return InvalidResponse("Formato invalido.");
        }

        return SellTickets(request!);
    }

    public PurchaseResponse SellTickets(PurchaseRequest request)
    {
        lock (_sync)
        {
            var trip = Trips.FirstOrDefault(t => t.Code.Equals(request.TripCode, StringComparison.OrdinalIgnoreCase));
            if (trip is null)
            {
                return new PurchaseResponse
                {
                    StatusCode = "4",
                    TripCode = request.TripCode,
                    Message = "Codigo de viaje no existe."
                };
            }

            if (request.Quantity is < 1 or > 5)
            {
                return new PurchaseResponse
                {
                    StatusCode = "3",
                    TripCode = trip.Code,
                    AvailableSeats = trip.AvailableCapacity,
                    Message = "La venta maxima por cliente es de 5 boletos."
                };
            }

            if (trip.AvailableCapacity < request.Quantity)
            {
                return new PurchaseResponse
                {
                    StatusCode = "0",
                    TripCode = trip.Code,
                    AvailableSeats = trip.AvailableCapacity,
                    Message = "No hay asientos disponibles."
                };
            }

            var allocations = trip.ReserveSeats(request.Quantity);
            if (allocations.Count == 0)
            {
                return new PurchaseResponse
                {
                    StatusCode = "0",
                    TripCode = trip.Code,
                    AvailableSeats = trip.AvailableCapacity,
                    Message = "No se pudieron asignar los asientos."
                };
            }

            return new PurchaseResponse
            {
                StatusCode = "1",
                TripCode = trip.Code,
                FirstAllocation = allocations.ElementAtOrDefault(0),
                SecondAllocation = allocations.ElementAtOrDefault(1),
                TransactionAmount = trip.Cost * request.Quantity,
                AvailableSeats = trip.AvailableCapacity,
                Message = "Transaccion exitosa."
            };
        }
    }

    private static PurchaseResponse InvalidResponse(string message)
    {
        return new PurchaseResponse
        {
            StatusCode = "5",
            Message = message
        };
    }
}
