using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EcoCharge.domain.model;

[Table("GS_BOOKING")]
public class Booking
{
    [Key]
    public string Id { get; set; }
    [Required]
    public string UserId { get; set; }
    [Required]
    public string ChargingPointId { get; set; }
    public string BookingDate { get; set; }
    public string Status { get; set; }

    public Booking()
    {
        Id = Guid.NewGuid().ToString();
    }
    
    public Booking(string userId, string chargingPointId, string bookingDate, string status)
    {
        Id = Guid.NewGuid().ToString();
        UserId = userId;
        ChargingPointId = chargingPointId;
        BookingDate = bookingDate;
        Status = status;
    }
}