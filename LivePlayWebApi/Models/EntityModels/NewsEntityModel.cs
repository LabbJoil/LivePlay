
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LivePlayWebApi.Models.EntityModels;

[Table("News")]
public class NewsEntityModel
{
    [Key, Required]
    public int Id { get; set; }
    [Required]
    public string? Name { get; set; }
    [Required]
    public string? Description { get; set; }
    [Required]
    public byte[]? Image { get; set; }
    [Required]
    private DateTime? FinalDate { get; set; }
}
