
using LivePlayWebApi.Models.Enums;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LivePlayWebApi.Models.EntityModels;

[Table("Quest")]
public class QuestEntityModel
{
    [Key, Required]
    public int Id { get; set; }
    [Required]
    public string? Title { get; set; }
    [Required]
    public string? Description { get; set; }
    [Required]
    public TypeQuest Type { get; set; }
    public string? Tip { get; set; }
    [Required]
    public int Bonus { get; set; }
    [Required]
    public DateTime? CreatedDate { get; set; }
}
