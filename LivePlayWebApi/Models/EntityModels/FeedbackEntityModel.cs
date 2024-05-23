
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LivePlayWebApi.Models.EntityModels;

[Table("Feedback")]
public class FeedbackEntityModel
{
    [Key, Required]
    public int Id { get; set; }
    [Required]
    public Guid? UserId { get; set; }
    public UserEntityModel? Users { get; set; }
    [Required]
    public string? Title { get; set; }
    [Required]
    public string? Text { get; set; }
    [Required]
    public byte[]? Image { get; set; }
    [Required]
    public byte Rate { get; set; }
    [Required]
    public DateTime CreateDate { get; set; } = DateTime.UtcNow;
}
