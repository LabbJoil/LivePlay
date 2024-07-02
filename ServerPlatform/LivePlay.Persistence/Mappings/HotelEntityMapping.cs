
using AutoMapper;
using LivePlay.Server.Core.Models;
using LivePlay.Server.Persistence.EntityModels.Base;

namespace LivePlay.Server.Persistence.Mappings;

public class HotelEntityMapping : Profile
{
    public HotelEntityMapping()
    {
        CreateMap<HotelEntityModel, Hotel>()
            .ReverseMap();
    }
}
