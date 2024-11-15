using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EcoCharge.domain.model;

[Table("GS_CHARGING_POST")]
public class ChargingPost
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; init; }
    [Required]
    public string Name { get; set; }
    public float Latitude { get; set; }
    public float Longitude { get; set; }
    public string Address { get; set; }
    public string OpenHours { get; set; }
    public string PaymentMethods { get; set; }
    public float AvarageRating { get; set; }
    
    public ICollection<Evaluation> Evaluations { get; set; }
    public ICollection<ChargingPoint> ChargingPoints { get; set; }

    public ChargingPost(string name, float latitude, float longitude, string address, string openHours, string paymentMethods, float avarageRating)
    {
        Name = name;
        Latitude = latitude;
        Longitude = longitude;
        Address = address;
        OpenHours = openHours;
        PaymentMethods = paymentMethods;
        AvarageRating = avarageRating;
    }
}