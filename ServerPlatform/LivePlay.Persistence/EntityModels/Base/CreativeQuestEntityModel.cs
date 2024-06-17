using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LivePlay.Server.Persistence.EntityModels.Base;

[Table("CreativeQuest")]
public class CreativeQuestEntityModel
{
    [Key, Required]
    public int Id { get; set; }
    [Required]
    public int QuestId { get; set; }
    [Required]
    public byte[] PictureInfo { get; set; }

    public required QuestEntityModel Quest { get; set; }
}
