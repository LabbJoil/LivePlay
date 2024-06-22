
using AutoMapper;

namespace LivePlay.Server.Persistence.Repositories;

public class NewsRepository(LivePlayDbContext dbContext, IMapper mapper)
{
    private readonly LivePlayDbContext _dbContext = dbContext;
    private readonly IMapper _mapper = mapper;

}
