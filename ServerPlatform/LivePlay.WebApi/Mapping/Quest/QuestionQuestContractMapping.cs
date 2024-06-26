
using AutoMapper;
using LivePlay.Server.Core.Models;
using LivePlay.Server.WebApi.Contracts.Base.Quest;

namespace LivePlay.Server.WebApi.Mapping.Quests;

public class QuestionQuestContractMapping : Profile
{
    public QuestionQuestContractMapping()
    {
        CreateMap<QuestionQuestContract, QuestionQuest>()
            .ReverseMap();
    }
}
