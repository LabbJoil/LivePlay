
using AutoMapper;
using LivePlay.Server.Core.Models;
using LivePlay.Server.WebApi.Contracts.Requests.QuestRequests.Add;

namespace LivePlay.Server.WebApi.Mappings.QuestMappings;

public class QuestionQuestAddingMapping : Profile
{
    public QuestionQuestAddingMapping()
    {
        CreateMap<AddingQuestionQuestContract, QuestionQuest>();
    }
}
