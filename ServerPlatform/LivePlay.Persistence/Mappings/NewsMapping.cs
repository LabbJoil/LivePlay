
using AutoMapper;
using LivePlay.Server.Core.Models;
using LivePlay.Server.Persistence.EntityModels.Base;

namespace LivePlay.Server.Persistence.Mappings;

public class NewsMapping : Profile
{
    public NewsMapping()
    {
        CreateMap<NewsEntityModel, News>()
            .ReverseMap();
    }
}
