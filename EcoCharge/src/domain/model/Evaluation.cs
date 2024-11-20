using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EcoCharge.domain.model;

[Table("GS_EVALUATION")]
public class Evaluation
{
    [Key]
    public string Id { get; set; }
    [Required]
    public string UserId { get; set; }
    [Required]
    public string ChargingPostId { get; set; }
    public string Rating { get; set; }
    public string EvaluationComment { get; set; }
    public string RatingDate { get; set; }

    public Evaluation()
    {
        Id = Guid.NewGuid().ToString();
    }
    
    public Evaluation(string userId, string chargingPostId, string rating, string evaluationComment, string ratingDate)
    {
        Id = Guid.NewGuid().ToString();
        UserId = userId;
        ChargingPostId = chargingPostId;
        Rating = rating;
        EvaluationComment = evaluationComment;
        RatingDate = ratingDate;
    }
}