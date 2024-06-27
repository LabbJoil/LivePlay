
using AutoMapper;
using LivePlay.Server.Core.Models;
using LivePlay.Server.Persistence.EntityModels.Base;

namespace LivePlay.Server.Persistence.Mapping;

public class QuestEntityMapping : Profile
{
    public QuestEntityMapping()
    {
        CreateMap<QuestEntityModel, Quest>()
            .ReverseMap();
    }
}
