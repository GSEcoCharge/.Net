using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Reflection.Metadata;
using System.Runtime.InteropServices.JavaScript;

namespace EcoCharge.domain.model;

[Table("GS_TRAVEL")]
public class Travel
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; init; }
    [Required]
    public int UserId { get; set; }
    public string StartPoint { get; set; }
    public string EndPoint { get; set; }
    public int RemainingAutonomy { get; set; }
    public string CreatedAt { get; set; }
    
    public ICollection<StopingPoint> StopingPoints { get; set; }

    public Travel(int userId, string startPoint, string endPoint, int remainingAutonomy, string createdAt)
    {
        UserId = userId;
        StartPoint = startPoint;
        EndPoint = endPoint;
        RemainingAutonomy = remainingAutonomy;
        CreatedAt = createdAt;
    }
}