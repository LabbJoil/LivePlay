
using AutoMapper;
using LivePlay.Server.Core.Models;
using LivePlay.Server.WebApi.Contracts.Base.QuestContracts;
using LivePlay.Server.WebApi.Contracts.Requests.QuestRequests.Add;

namespace LivePlay.Server.WebApi.Mappings.QuestMappings;

public class QuestionQuestMapping : Profile
{
    public QuestionQuestMapping()
    {
        CreateMap<QuestionQuestContract, QuestionQuest>()
            .ReverseMap();

        CreateMap<AddingQuestionQuestContract, QuestionQuest>();
    }
}
