using AirlineBooking.Api.Data;
using AirlineBooking.Api.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AirlineBooking.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class BookingsController : ControllerBase
{
    private readonly AppDbContext _db;

    public BookingsController(AppDbContext db)
    {
        _db = db;
    }

    // GET: /api/bookings
    // Returns the list of current bookings.
    [HttpGet]
    public async Task<ActionResult<IEnumerable<Booking>>> GetBookings()
    {
        var bookings = await _db.Bookings.AsNoTracking().ToListAsync();
        return Ok(bookings);
    }

    // POST: /api/bookings
    // Creates a new booking from the request body.
    [HttpPost]
    public async Task<ActionResult<Booking>> CreateBooking([FromBody] BookingCreateRequest request)
    {
        var flightExists = await _db.Flights.AnyAsync(f => f.FlightId == request.FlightId);
        if (!flightExists)
        {
            return BadRequest("Flight not found.");
        }

        var booking = new Booking
        {
            FlightId = request.FlightId,
            PassengerName = request.PassengerName,
            Email = request.Email,
            SeatNumber = request.SeatNumber,
            BookingDate = DateTime.UtcNow,
        };

        _db.Bookings.Add(booking);
        await _db.SaveChangesAsync();

        return CreatedAtAction(nameof(GetBookings), new { id = booking.BookingId }, booking);
    }

    // PUT: /api/bookings/{id}
    // Updates an existing booking using the request body.
    [HttpPut("{id:int}")]
    public async Task<ActionResult<Booking>> UpdateBooking(int id, [FromBody] BookingUpdateRequest request)
    {
        var booking = await _db.Bookings.FirstOrDefaultAsync(b => b.BookingId == id);
        if (booking is null)
        {
            return NotFound();
        }

        booking.PassengerName = request.PassengerName;
        booking.Email = request.Email;
        booking.SeatNumber = request.SeatNumber;

        await _db.SaveChangesAsync();

        return Ok(booking);
    }

    // DELETE: /api/bookings/{id}
    // Cancels a booking by removing it from the database.
    [HttpDelete("{id:int}")]
    public async Task<IActionResult> DeleteBooking(int id)
    {
        var booking = await _db.Bookings.FirstOrDefaultAsync(b => b.BookingId == id);
        if (booking is null)
        {
            return NotFound();
        }

        _db.Bookings.Remove(booking);
        await _db.SaveChangesAsync();
        return NoContent();
    }
}

public record BookingCreateRequest(
    int FlightId,
    string PassengerName,
    string Email,
    string SeatNumber
);

public record BookingUpdateRequest(
    string PassengerName,
    string Email,
    string SeatNumber
);
