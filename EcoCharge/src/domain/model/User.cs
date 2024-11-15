using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Reflection.Metadata;

namespace EcoCharge.domain.model;

[Table("GS_USER")]
public class User
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; init; }
    [Required]
    public string Name { get; set; }
    [Required]
    public string Email { get; set; }
    [Required]
    public string Password { get; set; }
    public Blob ProfileImage { get; set; }
    public string CreatedAt { get; set; }
    public string LastLocation { get; set; }
    
    public ICollection<Vehicle> Vehicles { get; set; }
    public ICollection<Travel> Travels { get; set; }
    public ICollection<Evaluation> Evaluations { get; set; }
    public ICollection<ChargingHistory> ChargingHistories { get; set; }
    public ICollection<Booking> Bookings { get; set; }
    
    public User(string name, string email, string password, Blob profileImage, string createdAt, string lastLocation)
    {
        Name = name;
        Email = email;
        Password = password;
        ProfileImage = profileImage;
        CreatedAt = createdAt;
        LastLocation = lastLocation;
    }
}