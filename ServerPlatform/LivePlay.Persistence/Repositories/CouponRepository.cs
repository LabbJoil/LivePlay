
using AutoMapper;

namespace LivePlay.Server.Persistence.Repositories;

public class CouponRepository(LivePlayDbContext dbContext, IMapper mapper)
{
    private readonly LivePlayDbContext _dbContext = dbContext;
    private readonly IMapper _mapper = mapper;

}
