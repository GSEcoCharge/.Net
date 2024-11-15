using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EcoCharge.domain.model;

[Table("GS_CHARGING_POINT")]
public class ChargingPoint
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; init; }
    [Required]
    public string ChargingStationId { get; set; }
    public string ConnectorType { get; set; }
    public int ChargingSpeed { get; set; }
    public string Availability { get; set; }
    public bool Reservable { get; set; }
    
    public ICollection<Booking> Bookings { get; set; }

    public ChargingPoint(string chargingStationId, string connectorType, int chargingSpeed, string availability, bool reservable)
    {
        ChargingStationId = chargingStationId;
        ConnectorType = connectorType;
        ChargingSpeed = chargingSpeed;
        Availability = availability;
        Reservable = reservable;
    }
}