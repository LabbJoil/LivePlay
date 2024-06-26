
using AutoMapper;
using LivePlay.Server.Core.Models;
using LivePlay.Server.Persistence.EntityModels.Base;

namespace LivePlay.Server.Persistence.Mapping;

public class CreativeQuestEntityMapping : Profile
{
    public CreativeQuestEntityMapping()
    {
        CreateMap<CreativeQuestEntityModel, CreativeQuest>()
            .ReverseMap();
    }
}
