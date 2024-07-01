
namespace LivePlay.Server.WebApi.Contracts.Requests.CouponRequests;

public class AddingCouponRequest
{
    public required string Title { get; set; }
    public required string Description { get; set; }
    public byte[]? Image { get; set; }
    public int Cost { get; set; }
    public required string CouponData { get; set; }
}
