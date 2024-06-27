
using AutoMapper;
using LivePlay.Server.Core.Models;
using LivePlay.Server.WebApi.Contracts.Requests.Quest.Add;

namespace LivePlay.Server.WebApi.Mapping.Quests;

public class QRQuestAddingMapping : Profile
{
    public QRQuestAddingMapping()
    {
        CreateMap<AddingQRQuestContract, QRQuest>();
    }
}
