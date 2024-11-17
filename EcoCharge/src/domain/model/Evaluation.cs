using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EcoCharge.domain.model;

[Table("GS_EVALUATION")]
public class Evaluation
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; init; }
    [Required]
    public string UserId { get; set; }
    [Required]
    public string ChargingPostId { get; set; }
    public string Rating { get; set; }
    public string Comment { get; set; }
    public string RatingDate { get; set; }

    public Evaluation(){}
    
    public Evaluation(string userId, string chargingPostId, string rating, string comment, string ratingDate)
    {
        UserId = userId;
        ChargingPostId = chargingPostId;
        Rating = rating;
        Comment = comment;
        RatingDate = ratingDate;
    }
}