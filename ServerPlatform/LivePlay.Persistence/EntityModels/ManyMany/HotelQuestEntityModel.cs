
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LivePlay.Persistence.EntityModels.ManyMany;

[Table("HotelQuest")]
public class HotelQuestEntityModel
{
    [Required]
    public int QuestId { get; set; }
    [Required]
    public int HotelId { get; set; }
}