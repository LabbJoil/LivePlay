
using AutoMapper;
using LivePlay.Server.Core.Interfaces;
using LivePlay.Server.Core.Models;
using Microsoft.EntityFrameworkCore;

namespace LivePlay.Server.Persistence.Repositories;

public class NewsRepository(LivePlayDbContext dbContext, IMapper mapper) : INewsRepository
{
    private readonly LivePlayDbContext _dbContext = dbContext;
    private readonly IMapper _mapper = mapper;

    public News[] GetLastNews()
    {
        var newsEntities = _dbContext.News.AsNoTracking()
            .OrderByDescending(n => n.Name)         //TODO: работа с датой
            .Take(4)
            .ToArray();
        var news = _mapper.Map<News[]>(newsEntities);
        return news;
    }
}
