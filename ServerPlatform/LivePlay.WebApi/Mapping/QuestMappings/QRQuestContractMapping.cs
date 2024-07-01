
using AutoMapper;
using LivePlay.Server.Core.Models;
using LivePlay.Server.WebApi.Contracts.Base.Quest;

namespace LivePlay.Server.WebApi.Mapping.Quests;

public class QRQuestContractMapping : Profile
{
    public QRQuestContractMapping()
    {
        CreateMap<QRQuestContract, QRQuest>()
            .ReverseMap();
    }
}
