using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EcoCharge.domain.model;

[Table("GS_CHARGING_POST")]
public class ChargingPost
{
    [Key]
    public string Id { get; set; }
    [Required]
    public string Name { get; set; }
    public float Latitude { get; set; }
    public float Longitude { get; set; }
    public string Address { get; set; }
    public string OpenHours { get; set; }
    public string PaymentMethods { get; set; }
    public float AvarageRating { get; set; }

    public ChargingPost()
    {
        Id = Guid.NewGuid().ToString();
    }
        
    public ChargingPost(string name, float latitude, float longitude, string address, string openHours, string paymentMethods, float avarageRating)
    {
        Id = Guid.NewGuid().ToString();
        Name = name;
        Latitude = latitude;
        Longitude = longitude;
        Address = address;
        OpenHours = openHours;
        PaymentMethods = paymentMethods;
        AvarageRating = avarageRating;
    }
}