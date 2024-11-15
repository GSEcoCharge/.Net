using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EcoCharge.domain.model;

[Table("GS_BOOKING")]
public class Booking
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; init; }
    [Required]
    public string UserId { get; set; }
    [Required]
    public string ChargingPointId { get; set; }
    public string Date { get; set; }
    public string Status { get; set; }

    public Booking(string userId, string chargingPointId, string date, string status)
    {
        UserId = userId;
        ChargingPointId = chargingPointId;
        Date = date;
        Status = status;
    }
}