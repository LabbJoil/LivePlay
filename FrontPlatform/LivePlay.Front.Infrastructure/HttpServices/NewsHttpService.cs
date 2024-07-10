
using LivePlay.Front.Core.Models;
using LivePlay.Front.Infrastructure.Abstracts;

namespace LivePlay.Front.Infrastructure.HttpServices;

public class NewsHttpService(IServiceScopeFactory serviceScopeFactory) : BaseHttpServise(serviceScopeFactory)
{
    protected override string BaseRoute => "news";

    public async Task<(News[]?, DisplayError?)> GetLastNews()
    {
        const string route = "/getLastNews";
        var response = await HttpProvider.Get(BaseRoute + route);
        if (response.IsSuccess)
            return ParseResponse<News[]>(response);
        else
            return (default, ParseError(response.ResponseData, response.Error));
    }
}
