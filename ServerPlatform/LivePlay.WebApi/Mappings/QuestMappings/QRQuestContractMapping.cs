
using AutoMapper;
using LivePlay.Server.Core.Models;
using LivePlay.Server.WebApi.Contracts.Base.QuestContracts;

namespace LivePlay.Server.WebApi.Mappings.QuestMappings;

public class QRQuestContractMapping : Profile
{
    public QRQuestContractMapping()
    {
        CreateMap<QRQuestContract, QRQuest>()
            .ReverseMap();
    }
}
