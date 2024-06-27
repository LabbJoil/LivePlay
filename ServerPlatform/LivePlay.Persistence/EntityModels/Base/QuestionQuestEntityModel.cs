
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LivePlay.Server.Persistence.EntityModels.Base;

[Table("QuestionQuest")]
public class QuestionQuestEntityModel
{
    [Key, Required]
    public int Id { get; set; }
    [Required]
    public int QuestId { get; set; }
    [Required]
    public required string Question { get; set; }
    [Required]
    public required string FirstAnswer { get; set; }
    [Required]
    public required string SecondAnswer { get; set; }
    [Required]
    public required string ThirdAnswer { get; set; }
    [Required]
    public required string FourthAnswer { get; set; }
    [Required]
    public required int RightAnswer { get; set; }

    public required QuestEntityModel Quest { get; set; }
}
