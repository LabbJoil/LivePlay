
using AutoMapper;
using LivePlay.Server.Core.Models;
using LivePlay.Server.Persistence.EntityModels.Base;

namespace LivePlay.Server.Persistence.Mappings;

public class QuestionQuestMapping : Profile
{
    public QuestionQuestMapping()
    {
        CreateMap<QuestionQuestEntityModel, QuestionQuest>()
            .ReverseMap();
    }
}
