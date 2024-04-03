
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LivePlayWebApi.Models.EntityModels;

[Table("Feedback")]
public class FeedbackEntityModel
{
    [Key, Required]
    public int Id { get; set; }
    [Required]
    public int UserId { get; set; }
    [Required]
    public string? Title { get; set; }
    [Required]
    public string? Text { get; set; }
    [Required]
    public byte[]? Image { get; set; }
    [Required]
    public byte Rate { get; set; }
}
