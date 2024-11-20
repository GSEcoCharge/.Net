using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Reflection.Metadata;

namespace EcoCharge.domain.model;

[Table("GS_USER")]
public class User
{
    [Key]
    public string Id { get; set; }
    [Required]
    public string Name { get; set; }
    [Required]
    public string Email { get; set; }
    [Required]
    public string Password { get; set; }
    public string ProfileImage { get; set; }
    public string CreatedAt { get; set; }
    public string LastLocation { get; set; }
    
    public class SentimentData
    {
        public string Text { get; set; }
    }

    public class SentimentPrediction
    {
        public bool Prediction { get; set; }
        public float Probability { get; set; }
    }

    public class ChargingHistoryData
    {
        public float Distance { get; set; }
        public float BatteryLevel { get; set; }
    }

    public class ChargingRecommendation
    {
        public string StationId { get; set; }
        public float Score { get; set; }
    }

    public User()
    {
        Id = Guid.NewGuid().ToString();
    }
    
    public User(string name, string email, string password, string profileImage, string createdAt, string lastLocation)
    {
        Id = Guid.NewGuid().ToString();
        Name = name;
        Email = email;
        Password = password;
        ProfileImage = profileImage;
        CreatedAt = createdAt;
        LastLocation = lastLocation;
    }
}