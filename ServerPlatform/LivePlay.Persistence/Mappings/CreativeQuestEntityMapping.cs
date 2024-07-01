
using AutoMapper;
using LivePlay.Server.Core.Models;
using LivePlay.Server.Persistence.EntityModels.Base;

namespace LivePlay.Server.Persistence.Mappings;

public class CreativeQuestEntityMapping : Profile
{
    public CreativeQuestEntityMapping()
    {
        CreateMap<CreativeQuestEntityModel, CreativeQuest>()
            .ReverseMap();
    }
}
