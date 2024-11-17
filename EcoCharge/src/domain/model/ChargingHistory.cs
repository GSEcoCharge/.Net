using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EcoCharge.domain.model;

[Table("GS_CHARGING_HISTORY")]
public class ChargingHistory
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; init; }
    [Required]
    public string UserId { get; set; }
    [Required]
    public string ChargingPointId { get; set; }
    public string Date { get; set; }
    public string ConsumedEnergy { get; set; }
    public string AvoidedEmissions { get; set; }
    
    public ChargingHistory(){}

    public ChargingHistory(string userId, string chargingPointId, string date, string consumedEnergy, string avoidedEmissions)
    {
        UserId = userId;
        ChargingPointId = chargingPointId;
        Date = date;
        ConsumedEnergy = consumedEnergy;
        AvoidedEmissions = avoidedEmissions;
    }
}