using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EcoCharge.domain.model;

[Table("GS_VEHICLE")]
public class Vehicle
{
    [Key]
    public string Id { get; set; }
    [Required]
    public string UserId { get; set; }
    [Required]
    public string Brand { get; set; }
    [Required]
    public string Model { get; set; }
    public string VehicleYear { get; set; }
    public string Autonomy { get; set; }
    public string ConnectorType { get; set; }

    public Vehicle()
    {
        Id = Guid.NewGuid().ToString();
    }

    public Vehicle(string userId, string brand, string model, string vehicleYear, string autonomy, string connectorType)
    {
        Id = Guid.NewGuid().ToString();
        UserId = userId;
        Brand = brand;
        Model = model;
        VehicleYear = vehicleYear;
        Autonomy = autonomy;
        ConnectorType = connectorType;
    }
}

