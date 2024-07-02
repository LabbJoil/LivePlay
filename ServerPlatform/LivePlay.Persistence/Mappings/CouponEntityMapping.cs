
using AutoMapper;
using LivePlay.Server.Core.Models;
using LivePlay.Server.Persistence.EntityModels.Base;

namespace LivePlay.Server.Persistence.Mappings;

public class CouponEntityMapping : Profile
{
    public CouponEntityMapping()
    {
        CreateMap<CouponEntityModel, Coupon>()
            .ReverseMap();
    }
}
