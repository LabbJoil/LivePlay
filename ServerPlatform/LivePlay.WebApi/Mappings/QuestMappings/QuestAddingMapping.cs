
using AutoMapper;
using LivePlay.Server.Core.Models;
using LivePlay.Server.WebApi.Contracts.Requests.QuestRequests.Add;

namespace LivePlay.Server.WebApi.Mappings.QuestMappings;

public class QuestAddingMapping : Profile
{
    public QuestAddingMapping()
    {
        CreateMap<AddingQuestContract, Quest>();
    }
}
