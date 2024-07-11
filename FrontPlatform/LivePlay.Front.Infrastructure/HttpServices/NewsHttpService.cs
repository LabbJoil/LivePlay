
using LivePlay.Front.Core.Models;
using LivePlay.Front.Infrastructure.Abstracts;
using LivePlay.Front.Infrastructure.Contracts.Responses;

namespace LivePlay.Front.Infrastructure.HttpServices;

public class NewsHttpService(IServiceScopeFactory serviceScopeFactory) : BaseHttpServise(serviceScopeFactory)
{
    protected override string BaseRoute => "news";

    public async Task<(News[]?, DisplayError?)> GetLastNews()
    {
        const string route = "/getLastNews";
        var response = await _httpProvider.Get(BaseRoute + route);
        if (response.IsSuccess)
        {
            var (newsResponse, error) = ParseResponse<NewsResponse[]>(response);
            if (newsResponse != default)
            {
                var news = _mapper.Map<News[]>(newsResponse);
                return (news, null);
            }
            return (null, error);
        }
        else
            return (default, ParseError(response.ResponseData, response.Error));
    }
}
