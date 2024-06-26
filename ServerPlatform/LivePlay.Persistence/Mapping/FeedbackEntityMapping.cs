
using AutoMapper;
using LivePlay.Server.Core.Models;
using LivePlay.Server.Persistence.EntityModels.Base;

namespace LivePlay.Server.Persistence.Mapping;

public class FeedbackEntityMapping : Profile
{
    public FeedbackEntityMapping()
    {
        CreateMap<FeedbackEntityModel, Feedback>()
            .ReverseMap();
    }
}
