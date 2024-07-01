
using LivePlay.Server.Application.Interfaces;
using LivePlay.Server.Core.CustomExceptions;
using LivePlay.Server.Core.Enums;
using LivePlay.Server.Core.Interfaces;
using LivePlay.Server.Core.Models;
using System.Security.Claims;

namespace LivePlay.Server.Application.Services;

public class CouponService(ICouponRepository couponRepository, IUserRepository userRepository, IJwtProvider jwtProvider)
{
    private readonly ICouponRepository _couponRepository = couponRepository;
    private readonly IUserRepository _userRepository = userRepository;
    private readonly IJwtProvider _jwtProvider = jwtProvider;

    public async Task<Coupon[]> GetAllCoupons()
    {
        var coupons = await _couponRepository.GetAll();
        return coupons;
    }

    public void AddCoupon(Coupon coupon)
    {
        _couponRepository.Create(coupon);
    }

    public async Task<int> BuyCoupon(ClaimsPrincipal claimsPrincipal, int couponId)
    {
        var userId = _jwtProvider.GetUserId(claimsPrincipal);
        var completeCoupon = await _couponRepository.GetByIdAndUserId(couponId, userId);
        if (completeCoupon != null)
            throw new RequestException(ErrorCode.RequestError, $"Coupon {couponId} has already have user {userId}");
        var coupon = await _couponRepository.GetById(couponId);
        var userPoints = await _userRepository.IncreasePoints(userId, coupon.Cost);
        _couponRepository.LinkedUser(couponId, userId);
        return userPoints;
    }
}
