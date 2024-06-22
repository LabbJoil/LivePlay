
using AutoMapper;
using LivePlay.Server.Core.Models;
using LivePlay.Server.Persistence.EntityModels.Base;

namespace LivePlay.Server.Persistence.Mapping;

public class QRQuestEntityMapping : Profile
{
    public QRQuestEntityMapping()
    {
        CreateMap<QRQuestEntityModel, QRQuest>()
            .ReverseMap();
    }
}
