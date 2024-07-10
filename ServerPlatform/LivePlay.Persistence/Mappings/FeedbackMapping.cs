
using AutoMapper;
using LivePlay.Server.Core.Models;
using LivePlay.Server.Persistence.EntityModels.Base;

namespace LivePlay.Server.Persistence.Mappings;

public class FeedbackMapping : Profile
{
    public FeedbackMapping()
    {
        CreateMap<FeedbackEntityModel, Feedback>()
            .ReverseMap();
    }
}
