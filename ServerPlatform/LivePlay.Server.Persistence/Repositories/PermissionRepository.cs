
using LivePlay.Server.Core.Enums;
using Microsoft.EntityFrameworkCore;

namespace LivePlay.Server.Persistence.Repositories;

public class PermissionRepository(LivePlayDbContext dbContext)
{
    private readonly LivePlayDbContext DbContext = dbContext;

    public async Task<HashSet<Permission>> GetUserPermissions(Guid userId)
    {
        var roles = await DbContext.Users
            .AsNoTracking()
            .Include(u => u.Roles)
            .ThenInclude(r => r.Permissions)
            .Where(u => u.Id == userId).Select(u => u.Roles)
            .ToArrayAsync();

        return roles
            .SelectMany(r => r)
            .SelectMany(r => r.Permissions)
            .Select(p => (Permission)p.Id)
            .ToHashSet();
    }
}
