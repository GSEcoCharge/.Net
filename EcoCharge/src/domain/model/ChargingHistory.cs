using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EcoCharge.domain.model;

[Table("GS_CHARGING_HISTORY")]
public class ChargingHistory
{
    [Key]
    public string Id { get; set; }
    [Required]
    public string UserId { get; set; }
    [Required]
    public string ChargingPointId { get; set; }
    public string ChargingHistoryDate { get; set; }
    public string ConsumedEnergy { get; set; }
    public string AvoidedEmissions { get; set; }

    public ChargingHistory()
    {
        Id = Guid.NewGuid().ToString();
    }

    public ChargingHistory(string userId, string chargingPointId, string chargingHistoryDate, string consumedEnergy, string avoidedEmissions)
    {
        Id = Guid.NewGuid().ToString();
        UserId = userId;
        ChargingPointId = chargingPointId;
        ChargingHistoryDate = chargingHistoryDate;
        ConsumedEnergy = consumedEnergy;
        AvoidedEmissions = avoidedEmissions;
    }
}