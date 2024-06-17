
using LivePlay.Server.Core.Enums;
using LivePlay.Server.Persistence.EntityModels.Base;
using Microsoft.EntityFrameworkCore;

namespace LivePlay.Server.Persistence.Repositories;

public class UserRepository(LivePlayDbContext dbContext)
{
    private readonly LivePlayDbContext DbContext = dbContext;

    public async Task<UserEntityModel> RegisterUser(string email, string password, string firstName)
    {
        if (DbContext.Users.FirstOrDefault(u => u.Email == email) != null)
            throw new Exception($"Пользователь с email - {email} уже существует");

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
        return userEntity;
        //var userClaims = JwtProvider.SetUserId(userEntity.Id.ToString());
        //return JwtProvider.GenerateNewToken(userClaims);
    }

    public async Task<UserEntityModel> RegisterAdmin(string email, string password, string firstName)
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

        return userEntity;
        //var userClaims = JwtProvider.SetUserId(userEntity.Id.ToString());
        //return JwtProvider.GenerateNewToken(userClaims);
    }
}
