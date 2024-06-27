
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LivePlay.Server.Persistence.EntityModels.Base;

[Table("News")]
public class NewsEntityModel
{
    [Key, Required]
    public int Id { get; set; }
    [Required]
    public required string Name { get; set; }
    [Required]
    public required string Description { get; set; }
    [Required]
    public byte[]? Image { get; set; }
    [Required]
    private DateTime? FinalDate { get; set; }
}
