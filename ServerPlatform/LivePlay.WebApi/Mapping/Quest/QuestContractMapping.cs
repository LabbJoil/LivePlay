
using AutoMapper;
using LivePlay.Server.Core.Models;
using LivePlay.Server.WebApi.Contracts.Base.Quest;

namespace LivePlay.Server.WebApi.Mapping.Quests;

public class QuestContractMapping : Profile
{
    public QuestContractMapping()
    {
        CreateMap<QuestContract, Quest>()
            .ReverseMap();
    }
}
