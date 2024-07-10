
using LivePlay.Server.Core.Interfaces;
using LivePlay.Server.Core.Models;

namespace LivePlay.Server.Application.Services;

public class NewsService(INewsRepository newsRepository)
{
    private readonly INewsRepository _newsRepository = newsRepository;

    public News[] GetLastNews()
    {
        var news = _newsRepository.GetLastNews();
        return news;
    }
}
