
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LivePlayWebApi.Models.EntityModels;

[Table("UserQuest")]
public class UserQuestEntityModel
{
    [Required]
    public Guid UserId { get; set; }
    [Required]
    public int QuestId { get; set; }
    [Required]
    public DateTime GetDate { get; set; } = DateTime.UtcNow;
}
