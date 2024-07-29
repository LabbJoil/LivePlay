
using AutoMapper;
using LivePlay.Server.Core.Models;
using LivePlay.Server.Persistence.EntityModels.Base;

namespace LivePlay.Server.Persistence.Mappings;

public class QuestMapping : Profile
{
    public QuestMapping()
    {
        CreateMap<QuestEntityModel, Quest>()
            .ReverseMap();
    }
}
