
using AutoMapper;
using LivePlay.Front.Core.Models;
using LivePlay.Server.Core.Models;
using LivePlay.Front.Infrastructure.Abstracts;
using LivePlay.Front.Infrastructure.Contracts.Requests.QuestRequests.Complete;
using LivePlay.Front.Core.Models.QuestModels;
using LivePlay.Front.Infrastructure.Contracts.Requests.QuestRequests.Add;

namespace LivePlay.Front.Infrastructure.HttpServices.QuestHttpServices;

public class DrawingQuestHttpService(IServiceScopeFactory serviceScopeFactory) : BaseHttpServise(serviceScopeFactory)
{
    protected override string BaseRoute => "CreativeQuest";

    public async Task<DisplayError?> AddQuest(Quest quest)
    {
        const string route = "/add";
        var addingDrawingQuest = new AddingDrawingQuestRequest
        {
            BaseQuest = _mapper.Map<AddingQuestContract>(quest)
        };
        var response = await _httpProvider.Post(BaseRoute + route, addingDrawingQuest);
        return ParseError(response.ResponseData, response.Error);
    }

    public async Task<DisplayError?> CompeteQuest(DrawingQuest drawingQuest, int questId)
    {
        const string route = "/complete";
        var completingQuest = _mapper.Map<CompletingDrawingQuestRequest>(drawingQuest);
        var response = await _httpProvider.Post(BaseRoute + route, completingQuest, (nameof(questId), questId.ToString()));
        return ParseError(response.ResponseData, response.Error);
    }
}
