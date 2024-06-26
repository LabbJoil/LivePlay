
using AutoMapper;
using LivePlay.Server.Core.Models;
using LivePlay.Server.WebApi.Contracts.Requests.Quest.Add;

namespace LivePlay.Server.WebApi.Mapping.Quests;

public class QuestAddingMapping : Profile
{
    public QuestAddingMapping()
    {
        CreateMap<AddingQuestContract, Quest>();
    }
}
