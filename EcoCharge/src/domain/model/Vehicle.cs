using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EcoCharge.domain.model;

[Table("GS_VEHICLE")]
public class Vehicle
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; init; }
    [Required]
    public int UserId { get; set; }
    [Required]
    public string Brand { get; set; }
    [Required]
    public string Model { get; set; }
    public string Year { get; set; }
    public string Autonomy { get; set; }
    public string ConnectorType { get; set; }

    public Vehicle(int userId, string brand, string model, string year, string autonomy, string connectorType)
    {
        UserId = userId;
        Brand = brand;
        Model = model;
        Year = year;
        Autonomy = autonomy;
        ConnectorType = connectorType;
    }
}

