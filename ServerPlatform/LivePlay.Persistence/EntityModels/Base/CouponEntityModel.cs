
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LivePlay.Persistence.EntityModels.Base;

[Table("Coupon")]
public class CouponEntityModel
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
    public DateTime CreatedDate { get; set; } = DateTime.UtcNow;
    [Required]
    public DateTime? FinalDate { get; set; }
    public ICollection<UserEntityModel> Users { get; set; } = [];
}
