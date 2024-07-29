
using AutoMapper;
using LivePlay.Server.Core.Models;
using LivePlay.Server.Persistence.EntityModels.Base;

namespace LivePlay.Server.Persistence.Mappings;

public class CouponMapping : Profile
{
    public CouponMapping()
    {
        CreateMap<CouponEntityModel, Coupon>()
            .ReverseMap();
    }
}
