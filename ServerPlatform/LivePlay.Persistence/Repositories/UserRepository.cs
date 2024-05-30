
using LivePlay.Application.Interfaces;
using LivePlay.Core.Enums;
using LivePlay.Persistence.EntityModels.Base;
using Microsoft.EntityFrameworkCore;

namespace LivePlay.Persistence.Repositories;

public class UserRepository(LivePlayDbContext dbContext, IJwtProvider jwtProvider)
{
    private readonly LivePlayDbContext DbContext = dbContext;
    private readonly IJwtProvider JwtProvider = jwtProvider;

    public async Task<string> RegisterUser(string email, string password, string firstName)
    {
        if (DbContext.Users.FirstOrDefault(u => u.Email == email) != null)
            throw new Exception($"Пользователь с email - {email} уже существует");
        //throw new ExceptionHelper(new LoggingHelper(TypeMessage.Problem, DangerLevel.Wanted, $"User with Email ({email}) already exists"));

        var role = await DbContext.Roles.FirstOrDefaultAsync(r => r.Id == (int)Role.User) ??
            throw new Exception("Not found role");

        var userEntity = new UserEntityModel
        {
            Email = email,
            PasswordHash = password,
            FirstName = firstName,
            Roles = [role]
        };

        DbContext.Users.Add(userEntity);
        await DbContext.SaveChangesAsync();
        userEntity.PasswordHash = "";

        var userClaims = JwtProvider.SetUserId(userEntity.Id.ToString());
        return JwtProvider.GenerateNewToken(userClaims);
    }

    public async Task<string> RegisterAdmin(string email, string password, string firstName)
    {
        if (DbContext.Users.FirstOrDefault(u => u.Email == email) != null)
            throw new Exception($"Пользователь с email - {email} уже существует");

        var role = await DbContext.Roles.FirstOrDefaultAsync(r => r.Id == (int)Role.Admin) ??
            throw new Exception("Not found role");

        var userEntity = new UserEntityModel
        {
            Email = email,
            PasswordHash = password,
            FirstName = firstName,
            Roles = [role]
        };

        DbContext.Users.Add(userEntity);
        await DbContext.SaveChangesAsync();
        userEntity.PasswordHash = "";

        var userClaims = JwtProvider.SetUserId(userEntity.Id.ToString());
        return JwtProvider.GenerateNewToken(userClaims);
    }

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
