
using AutoMapper;
using LivePlay.Front.Core.Models;
using LivePlay.Front.Infrastructure.Contracts.Responses;

namespace LivePlay.Front.Infrastructure.Mappings;

public class NewsMapping : Profile
{
    public NewsMapping()
    {
        CreateMap<NewsResponse, News>();
    }
}
