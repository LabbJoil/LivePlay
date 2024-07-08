
using AutoMapper;
using LivePlay.Front.Infrastructure.Contracts.Requests;
using LivePlay.Server.Core.Models;

namespace LivePlay.Front.Infrastructure.Mappings;

public class DrawingQuestMapping : Profile
{
    public DrawingQuestMapping()
    {
        CreateMap<DrawingQuest, CompletingDrawingQuestRequest>()
            .ReverseMap();
    }
}
