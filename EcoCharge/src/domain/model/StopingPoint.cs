using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EcoCharge.domain.model;

[Table("GS_STOPING_POINT")]
public class StopingPoint
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; init; }
    [Required]
    public string TravelId { get; set; }
    [Required]
    public string ChargingPointId { get; set; }
    public string Order { get; set; }
    
    public StopingPoint() { }

    public StopingPoint(string travelId, string chargingPointId, string order)
    {
        TravelId = travelId;
        ChargingPointId = chargingPointId;
        Order = order;
    }
}