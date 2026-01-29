using System.ComponentModel.DataAnnotations;

namespace AirlineBooking.Api.Models;

public class Booking
{
    [Key]
    public int BookingId { get; set; }

    [Required]
    public int FlightId { get; set; }

    [Required]
    [MaxLength(120)]
    public string PassengerName { get; set; } = string.Empty;

    [Required]
    [MaxLength(120)]
    public string Email { get; set; } = string.Empty;

    [Required]
    [MaxLength(5)]
    public string SeatNumber { get; set; } = string.Empty;

    public DateTime BookingDate { get; set; }
}
