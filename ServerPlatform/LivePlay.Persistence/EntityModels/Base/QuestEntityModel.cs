
using LivePlay.Server.Core.Enums;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LivePlay.Server.Persistence.EntityModels.Base;

[Table("Quest")]
public class QuestEntityModel
{
    [Key, Required]
    public int Id { get; set; }
    [Required]
    public required string Title { get; set; }
    [Required]
    public required string DescriptionMini { get; set; }
    [Required]
    public string DescriptionFull { get; set; } = string.Empty;
    [Required]
    public byte[]? Image { get; set; }
    [Required]
    public TypeQuest Type { get; set; }
    [Required]
    public int Reward { get; set; }
    [Required]
    public DateTime CreatedDate { get; set; } = DateTime.UtcNow;
    [Required]
    public DateTime? FinalDate { get; set; }

    public required QuestionQuestEntityModel QuestionQuest { get; set; }
    public required QRQuestEntityModel QRQuest { get; set; }
    public required CreativeQuestEntityModel CreativeQuest { get; set; }

    public ICollection<UserEntityModel> Users { get; set; } = [];
    public ICollection<HotelEntityModel> Hotels { get; set; } = [];
}
