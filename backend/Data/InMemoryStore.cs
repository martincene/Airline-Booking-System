using AirlineBooking.Api.Models;

namespace AirlineBooking.Api.Data;

public static class InMemoryStore
{
    public static List<Flight> Flights { get; } = new()
    {
        new Flight
        {
            FlightId = 1,
            FlightNumber = "AL101",
            Origin = "Tirana (TIA)",
            Destination = "Rome (FCO)",
            DepartureTime = DateTime.Today.AddHours(8).AddMinutes(30),
            SeatsAvailable = 12,
        },
        new Flight
        {
            FlightId = 2,
            FlightNumber = "AL202",
            Origin = "Tirana (TIA)",
            Destination = "Vienna (VIE)",
            DepartureTime = DateTime.Today.AddHours(11).AddMinutes(15),
            SeatsAvailable = 5,
        },
        new Flight
        {
            FlightId = 3,
            FlightNumber = "AL303",
            Origin = "Tirana (TIA)",
            Destination = "Istanbul (IST)",
            DepartureTime = DateTime.Today.AddHours(15).AddMinutes(45),
            SeatsAvailable = 20,
        },
    };

    public static List<Booking> Bookings { get; } = new()
    {
        new Booking
        {
            BookingId = 1,
            FlightId = 1,
            PassengerName = "Alex Johnson",
            Email = "alex@email.com",
            SeatNumber = "12A",
            BookingDate = DateTime.Today,
        },
        new Booking
        {
            BookingId = 2,
            FlightId = 2,
            PassengerName = "Riley Chen",
            Email = "riley@email.com",
            SeatNumber = "7C",
            BookingDate = DateTime.Today,
        },
    };

    private static int _nextBookingId = 3;

    public static int GetNextBookingId()
    {
        return _nextBookingId++;
    }
}
