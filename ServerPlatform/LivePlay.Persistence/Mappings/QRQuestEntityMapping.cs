
using AutoMapper;
using LivePlay.Server.Core.Models;
using LivePlay.Server.Persistence.EntityModels.Base;

namespace LivePlay.Server.Persistence.Mappings;

public class QRQuestEntityMapping : Profile
{
    public QRQuestEntityMapping()
    {
        CreateMap<QRQuestEntityModel, QRQuest>()
            .ReverseMap();
    }
}
