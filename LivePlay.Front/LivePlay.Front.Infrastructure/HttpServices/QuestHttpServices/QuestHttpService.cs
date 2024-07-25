
using LivePlay.Front.Core.Models;
using LivePlay.Front.Core.Models.QuestModels;
using LivePlay.Front.Infrastructure.Abstracts;
using LivePlay.Front.Infrastructure.Contracts.Responses;

namespace LivePlay.Front.Infrastructure.HttpServices.QuestHttpServices;

public class QuestHttpService(IServiceScopeFactory serviceScopeFactory) : BaseHttpServise(serviceScopeFactory)
{
    protected override string BaseRoute => "Quest";

    public async Task<DisplayError?> TakePart(int idQuest)
    {
        const string route = "/takePart";
        (string, string)[] sendParams = [(nameof(idQuest), idQuest.ToString())];

        var response = await _httpProvider.Get(BaseRoute + route, sendParams);
        if (response.IsSuccess)
            return null;
        else
            return ParseError(response.ResponseData, response.Error);
    }

    public async Task<(Quest[], DisplayError?)> GetAllQuests()
    {
        const string route = "/getAll";
        var response = await _httpProvider.Get(BaseRoute + route);
        if (response.IsSuccess)
        {
            var (questsResponse, error) = ParseResponse<QuestResponse[]>(response);
            if (questsResponse != null)
            {
                var quests = _mapper.Map<Quest[]>(questsResponse);
                return (quests, null);
            }
            return ([], error);
        }
        else
            return ([], ParseError(response.ResponseData, response.Error));
    }
}
