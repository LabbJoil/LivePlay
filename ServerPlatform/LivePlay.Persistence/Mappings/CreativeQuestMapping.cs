
using AutoMapper;
using LivePlay.Server.Core.Models;
using LivePlay.Server.Persistence.EntityModels.Base;

namespace LivePlay.Server.Persistence.Mappings;

public class CreativeQuestMapping : Profile
{
    public CreativeQuestMapping()
    {
        CreateMap<CreativeQuestEntityModel, CreativeQuest>()
            .ReverseMap();
    }
}
