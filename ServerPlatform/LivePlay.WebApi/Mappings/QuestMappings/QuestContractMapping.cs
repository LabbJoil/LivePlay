
using AutoMapper;
using LivePlay.Server.Core.Models;
using LivePlay.Server.WebApi.Contracts.Base.QuestContracts;

namespace LivePlay.Server.WebApi.Mappings.QuestMappings;

public class QuestContractMapping : Profile
{
    public QuestContractMapping()
    {
        CreateMap<QuestContract, Quest>()
            .ReverseMap();
    }
}
