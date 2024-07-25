
using AutoMapper;
using LivePlay.Server.Core.Models;
using LivePlay.Server.WebApi.Contracts.Base.QuestContracts;

namespace LivePlay.Server.WebApi.Mappings.QuestMappings;

public class CreativeQuestMapping : Profile
{
    public CreativeQuestMapping()
    {
        CreateMap<CreativeQuestContract, CreativeQuest>()
            .ReverseMap();
    }
}
