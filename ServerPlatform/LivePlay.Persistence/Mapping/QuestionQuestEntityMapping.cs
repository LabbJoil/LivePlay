
using AutoMapper;
using LivePlay.Server.Core.Models;
using LivePlay.Server.Persistence.EntityModels.Base;

namespace LivePlay.Server.Persistence.Mapping;

public class QuestionQuestEntityMapping : Profile
{
    public QuestionQuestEntityMapping()
    {
        CreateMap<QuestionQuestEntityModel, QuestionQuest>()
            .ReverseMap();
    }
}
