
using AutoMapper;
using LivePlay.Front.Core.Models.QuestModels;
using LivePlay.Front.Infrastructure.Contracts.Base.QuestContracts;
using LivePlay.Front.Infrastructure.Contracts.Requests.QuestRequests.Add;
using LivePlay.Front.Infrastructure.Contracts.Responses;

namespace LivePlay.Front.Infrastructure.Mappings;

public class QuestMapping : Profile
{
    public QuestMapping()
    {
        CreateMap<QuestResponse, Quest>();
        CreateMap<AddingQuestContract, Quest>()
            .ReverseMap(); ;
        CreateMap<QuestContract, Quest>()
            .ReverseMap();
    }
}
