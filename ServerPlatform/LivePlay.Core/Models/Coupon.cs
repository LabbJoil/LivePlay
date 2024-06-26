
namespace LivePlay.Server.Core.Models;

public class Coupon
{
    public int Id { get; set; }
    public required string Title { get; set; }
    public required string Description { get; set; }
    public byte[]? Image { get; set; }
    public int Cost { get; set; }
    public required string CouponData { get; set; }
}
