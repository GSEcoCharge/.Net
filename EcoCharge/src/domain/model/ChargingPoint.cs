using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EcoCharge.domain.model;

[Table("GS_CHARGING_POINT")]
public class ChargingPoint
{
    [Key]
    public string Id { get; set; }
    [Required]
    public string ChargingStationId { get; set; }
    public string ConnectorType { get; set; }
    public int ChargingSpeed { get; set; }
    public string Availability { get; set; }
    public int Reservable { get; set; }

    public ChargingPoint()
    {
        Id = Guid.NewGuid().ToString();
    }
    
    public ChargingPoint(string chargingStationId, string connectorType, int chargingSpeed, string availability, int reservable)
    {
        Id = Guid.NewGuid().ToString();
        ChargingStationId = chargingStationId;
        ConnectorType = connectorType;
        ChargingSpeed = chargingSpeed;
        Availability = availability;
        Reservable = reservable;
    }
}