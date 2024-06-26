
using AutoMapper;
using LivePlay.Server.Application.Services;
using LivePlay.Server.Core.Models;
using LivePlay.Server.WebApi.Contracts.Requests.Coupons;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LivePlay.Server.WebApi.Controllers;

[Route("[controller]/")]
[ApiController]
public class CouponController(CouponService couponService, IMapper mapper) : Controller
{
    private readonly CouponService _couponService = couponService;
    private readonly IMapper _mapper = mapper;

    [HttpGet("/getcoupons")]
    //[Authorize(Policy = nameof(Politic.EditQuest))]
    public async Task<IActionResult> GetAllCoupons()
    {
        var coupons = await _couponService.GetAllCoupons();
        return Ok(coupons);
    }

    [HttpPost("/addcoupon")]
    //[Authorize(Policy = nameof(Politic.EditQuest))]
    public IActionResult AddCoupon([FromBody] AddingCouponRequest couponRequest)
    {
        var coupon = _mapper.Map<Coupon>(couponRequest);
        _couponService.AddCoupon(coupon);
        return NoContent();
    }

    [HttpPost("/buycoupon/{id}")]
    //[Authorize(Policy = nameof(Politic.EditQuest))]
    public async Task<IActionResult> BuyCoupon(int id)
    {
        var award = await _couponService.BuyCoupon(HttpContext.User, id);
        return Ok(award);
    }
}
