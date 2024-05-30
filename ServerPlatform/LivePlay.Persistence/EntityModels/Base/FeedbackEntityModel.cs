
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LivePlay.Persistence.EntityModels.Base;

[Table("Feedback")]
public class FeedbackEntityModel
{
    [Key, Required]
    public int Id { get; set; }
    [Required]
    public required Guid UserId { get; set; }
    [Required]
    public required string Text { get; set; }
    [Required]
    public byte[]? Image { get; set; }
    [Required]
    public byte Rate { get; set; }
    [Required]
    public DateTime CreateDate { get; set; } = DateTime.Now;

    public required UserEntityModel User { get; set; }
}
