
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LivePlayWebApi.Models.EntityModels;

[Table("QuestUser")]
public class QuestUserEntityModel
{
    [Key, Required]
    public int Id { get; set; }
    [Required]
    public int UserId { get; set; }
    [Required]
    public int QuestId { get; set; }
    [Required]
    public DateTime? GetDate { get; set; }
}
