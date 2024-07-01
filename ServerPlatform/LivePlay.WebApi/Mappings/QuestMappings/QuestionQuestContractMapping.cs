
using AutoMapper;
using LivePlay.Server.Core.Models;
using LivePlay.Server.WebApi.Contracts.Base.QuestContracts;

namespace LivePlay.Server.WebApi.Mappings.QuestMappings;

public class QuestionQuestContractMapping : Profile
{
    public QuestionQuestContractMapping()
    {
        CreateMap<QuestionQuestContract, QuestionQuest>()
            .ReverseMap();
    }
}
