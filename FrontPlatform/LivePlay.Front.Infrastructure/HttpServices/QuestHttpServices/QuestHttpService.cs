
using LivePlay.Front.Core.Models;
using LivePlay.Front.Infrastructure.Abstracts;

namespace LivePlay.Front.Infrastructure.HttpServices.QuestHttpServices;

public class QuestHttpService(IServiceScopeFactory serviceScopeFactory) : BaseHttpServise(serviceScopeFactory)
{
    protected override string BaseRoute => "quest";

    public async Task<DisplayError?> TakePart(int idQuest)
    {
        const string route = "/takepart";
        (string, string)[] sendParams = [(nameof(idQuest), idQuest.ToString())];

        var response = await HttpProvider.Get(BaseRoute + route, sendParams);
        if (response.IsSuccess)
            return null;
        else
            return ParseError(response.ResponseData, response.Error);
    }
}
