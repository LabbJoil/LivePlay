
using AutoMapper;
using LivePlay.Server.Core.Models;
using LivePlay.Server.Persistence.EntityModels.Base;

namespace LivePlay.Server.Persistence.Mappings;

public class QRQuestMapping : Profile
{
    public QRQuestMapping()
    {
        CreateMap<QRQuestEntityModel, QRQuest>()
            .ReverseMap();
    }
}
