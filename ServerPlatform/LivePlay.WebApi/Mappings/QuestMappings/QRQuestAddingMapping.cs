
using AutoMapper;
using LivePlay.Server.Core.Models;
using LivePlay.Server.WebApi.Contracts.Requests.QuestRequests.Add;

namespace LivePlay.Server.WebApi.Mappings.QuestMappings;

public class QRQuestAddingMapping : Profile
{
    public QRQuestAddingMapping()
    {
        CreateMap<AddingQRQuestContract, QRQuest>();
    }
}
