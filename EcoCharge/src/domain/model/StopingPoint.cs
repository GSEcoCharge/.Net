using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EcoCharge.domain.model;

[Table("GS_STOPING_POINT")]
public class StopingPoint
{
    [Key]
    public string Id { get; set; }
    [Required]
    public string TravelId { get; set; }
    [Required]
    public string ChargingPointId { get; set; }
    public string Order { get; set; }

    public StopingPoint()
    {
        Id = Guid.NewGuid().ToString();
    }

    public StopingPoint(string travelId, string chargingPointId, string order)
    {
        Id = Guid.NewGuid().ToString();
        TravelId = travelId;
        ChargingPointId = chargingPointId;
        Order = order;
    }
}