
using LivePlay.Front.Core.Models;

namespace LivePlay.Front.Application.HttpServices.QuestHttpServices;

public class QuestHttpService(IServiceScopeFactory serviceScopeFactory) : BaseHttpServise(serviceScopeFactory, "user")
{
    public async Task<DisplayError?> TakePart(int idQuest)
    {
        const string route = "/takepart";
        (string, string)[] sendParams = [(nameof(idQuest), idQuest.ToString())];

        var response = await _httpProvider.Get(_baseRoute + route, sendParams);
        if (response.IsSuccess)
            return null;
        else
            return ParseError(response.ResponseData, response.Error);
    }
}
