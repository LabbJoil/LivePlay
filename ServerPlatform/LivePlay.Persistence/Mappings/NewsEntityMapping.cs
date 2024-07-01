
using AutoMapper;
using LivePlay.Server.Core.Models;
using LivePlay.Server.Persistence.EntityModels.Base;

namespace LivePlay.Server.Persistence.Mappings;

public class NewsEntityMapping : Profile
{
    public NewsEntityMapping()
    {
        CreateMap<NewsEntityModel, News>()
            .ReverseMap();
    }
}
