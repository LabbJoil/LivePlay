
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LivePlayWebApi.Models.EntityModels;

[Table("UserCoupon")]
public class UserCouponEntityModel
{
    [Required]
    public Guid UserId { get; set; }
    [Required]
    public int CouponId  { get; set; }
    [Required]
    public DateTime GetDate { get; set; } = DateTime.UtcNow;
}
