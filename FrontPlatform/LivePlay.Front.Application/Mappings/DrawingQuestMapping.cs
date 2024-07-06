
using AutoMapper;
using LivePlay.Front.Application.Contracts.Requests;
using LivePlay.Server.Core.Models;

namespace LivePlay.Front.Application.Mappings;

public class DrawingQuestMapping : Profile
{
    public DrawingQuestMapping()
    {
        CreateMap<DrawingQuest, CompletingDrawingQuestRequest>()
            .ReverseMap();
    }
}
