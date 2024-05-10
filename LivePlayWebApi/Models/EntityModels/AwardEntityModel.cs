
using LivePlayWebApi.Models.Enums;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LivePlayWebApi.Models.EntityModels;

[Table("Award")]
public class AwardEntityModel
{
    [Key, Required]
    public int Id { get; set; }
    [Required]
    public required string Title { get; set; }
    [Required]
    public required string Description { get; set; }
    [Required]
    public byte[]? Image { get; set; }
    [Required]
    public int Cost { get; set; }
    [Required]
    public required string Coupon { get; set; }
    [Required]
    public DateTime? CreatedDate { get; set; }
    [Required]
    public DateTime? FinalDate { get; set; }
}
