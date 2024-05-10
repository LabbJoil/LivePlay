
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LivePlayWebApi.Models.EntityModels;

[Table("DoneQuest")]
public class DoneQuestEntityModel
{
    [Key, Required]
    public int Id { get; set; }
    [Required]
    public int UserId { get; set; }
    [Required]
    public int QuestId { get; set; }
}
