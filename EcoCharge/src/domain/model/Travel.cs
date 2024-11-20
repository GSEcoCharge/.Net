using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Reflection.Metadata;
using System.Runtime.InteropServices.JavaScript;

namespace EcoCharge.domain.model;

[Table("GS_TRAVEL")]
public class Travel
{
    [Key]
    public string Id { get; set; }
    [Required]
    public string UserId { get; set; }
    public string StartPoint { get; set; }
    public string EndPoint { get; set; }
    public int RemainingAutonomy { get; set; }
    public string CreatedAt { get; set; }

    public Travel()
    {
        Id = Guid.NewGuid().ToString();
    }
        
    public Travel(string userId, string startPoint, string endPoint, int remainingAutonomy, string createdAt)
    {
        Id = Guid.NewGuid().ToString();
        UserId = userId;
        StartPoint = startPoint;
        EndPoint = endPoint;
        RemainingAutonomy = remainingAutonomy;
        CreatedAt = createdAt;
    }
}