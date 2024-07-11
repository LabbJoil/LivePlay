
using AutoMapper;
using LivePlay.Front.Core.Models.QuestModels;
using LivePlay.Front.Infrastructure.Contracts.Requests.QuestRequests.Add;

namespace LivePlay.Front.Infrastructure.Mappings;

public class QuestionQuestMapping : Profile
{
    public QuestionQuestMapping()
    {
        CreateMap<AddingQuestionQuestContract, QuestionQuest>()
            .ReverseMap();
    }
}
