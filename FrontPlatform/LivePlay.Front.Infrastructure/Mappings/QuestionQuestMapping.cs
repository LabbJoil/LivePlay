
using AutoMapper;
using LivePlay.Front.Core.Models.QuestModels;
using LivePlay.Front.Infrastructure.Contracts.Requests.QuestRequests.Add;
using LivePlay.Front.Infrastructure.Contracts.Responses;

namespace LivePlay.Front.Infrastructure.Mappings;

public class QuestionQuestMapping : Profile
{
    public QuestionQuestMapping()
    {
        CreateMap<QuestionQuestResponse, QuestionQuest>()
            .ReverseMap();
        CreateMap<AddingQuestionQuestContract, QuestionQuest>()
            .ReverseMap();
    }
}
