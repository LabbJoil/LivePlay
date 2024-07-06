
using LivePlay.Front.Core.Models;
using LivePlay.Server.Core.Models;

namespace LivePlay.Front.Application.HttpServices.QuestHttpServices;

public class DrawingQuestHttpService(IServiceScopeFactory serviceScopeFactory) : BaseHttpServise(serviceScopeFactory, "creativequest")
{
    public async Task<DisplayError?> CompeteQuest(DrawingQuest drawingQuest, int questId)
    {
        const string route = "/complete";
        var response = await _httpProvider.Post(_baseRoute + route, drawingQuest, (nameof(questId), questId.ToString()));
        return ParseError(response.ResponseData, response.Error);
    }
}
