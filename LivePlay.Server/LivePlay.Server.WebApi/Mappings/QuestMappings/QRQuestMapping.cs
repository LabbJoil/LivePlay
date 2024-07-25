
using AutoMapper;
using LivePlay.Server.Core.Models;
using LivePlay.Server.WebApi.Contracts.Base.QuestContracts;
using LivePlay.Server.WebApi.Contracts.Requests.QuestRequests.Add;

namespace LivePlay.Server.WebApi.Mappings.QuestMappings;

public class QRQuestMapping : Profile
{
    public QRQuestMapping()
    {
        CreateMap<QRQuestContract, QRQuest>()
            .ReverseMap();

        CreateMap<AddingQRQuestContract, QRQuest>();
    }
}
