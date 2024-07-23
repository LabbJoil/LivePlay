
using AutoMapper;
using LivePlay.Server.Core.Models;
using LivePlay.Server.WebApi.Contracts.Base;

namespace LivePlay.Server.WebApi.Mappings;

public class NewsMapping : Profile
{
    public NewsMapping()
    {
        CreateMap<NewsContract, News>()
            .ReverseMap();
    }
}
