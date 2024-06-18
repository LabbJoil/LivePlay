
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LivePlay.Server.Persistence.EntityModels.Base;

[Table("Hotel")]
public class HotelEntityModel
{
    [Key, Required]
    public int Id { get; set; }
    [Required]
    public required string Name { get; set; }
    [Required]
    public required string Address { get; set; }
    public string? PhoneNumber { get; set; }

    public ICollection<QuestEntityModel> Quests { get; set; } = [];
}
