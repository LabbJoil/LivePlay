
using AutoMapper;
using LivePlay.Front.Infrastructure.Contracts.Requests;
using LivePlay.Front.Core.Models;
using LivePlay.Server.Core.Models;
using LivePlay.Front.Infrastructure.Abstracts;

namespace LivePlay.Front.Infrastructure.HttpServices.QuestHttpServices;

public class DrawingQuestHttpService(IServiceScopeFactory serviceScopeFactory, IMapper mapper) : BaseHttpServise(serviceScopeFactory)
{
    protected override string BaseRoute => "creativequest";

    public async Task<DisplayError?> CompeteQuest(DrawingQuest drawingQuest, int questId)
    {
        const string route = "/complete";
        var completingQuest = Mapper.Map<CompletingDrawingQuestRequest>(drawingQuest);
        var response = await HttpProvider.Post(BaseRoute + route, completingQuest, (nameof(questId), questId.ToString()));
        return ParseError(response.ResponseData, response.Error);
    }


}
