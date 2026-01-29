using System.ComponentModel.DataAnnotations;

namespace AirlineBooking.Api.Models;

public class Flight
{
    [Key]
    public int FlightId { get; set; }

    [Required]
    [MaxLength(10)]
    public string FlightNumber { get; set; } = string.Empty;

    [Required]
    [MaxLength(100)]
    public string Origin { get; set; } = string.Empty;

    [Required]
    [MaxLength(100)]
    public string Destination { get; set; } = string.Empty;

    public DateTime DepartureTime { get; set; }

    public int SeatsAvailable { get; set; }
}
