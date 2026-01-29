using AirlineBooking.Api.Data;
using AirlineBooking.Api.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AirlineBooking.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class FlightsController : ControllerBase
{
    private readonly AppDbContext _db;

    public FlightsController(AppDbContext db)
    {
        _db = db;
    }

    // GET: /api/flights
    // Returns the list of available flights.
    [HttpGet]
    public async Task<ActionResult<IEnumerable<Flight>>> GetFlights()
    {
        var flights = await _db.Flights.AsNoTracking().ToListAsync();
        return Ok(flights);
    }
}
