
using LivePlayWebApi.Models.Enums;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LivePlayWebApi.Models.EntityModels;

[Table("AwardUser")]
public class AwardUserEntityModel
{
    [Key, Required]
    public int Id { get; set; }
    [Required]
    public int UserId { get; set; }
    [Required]
    public int AwardId  { get; set; }
    [Required]
    public DateTime? GetDate { get; set; }
}
