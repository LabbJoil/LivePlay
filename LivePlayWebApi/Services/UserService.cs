using LivePlayWebApi.Interfaces;
using LivePlayWebApi.Models.CoreModels;
using LivePlayWebApi.Models.EntityModels;
using LivePlayWebApi.Services.Entities;
using Npgsql.Replication.PgOutput.Messages;

namespace LivePlayWebApi.Services;

public class UserService(ContextDB contextDB, IJwtProvider jwtProvider)
{
    private readonly ContextDB Database = contextDB;
    private readonly IJwtProvider JwtProvider = jwtProvider;

    public async Task<string> Register(string email, string password)
    {
        if (Database.Users.FirstOrDefault(u => u.Email == email) != null)
            throw new Exception($"Пользователь с email - {email} уже существует");
            //throw new ExceptionHelper(new LoggingHelper(TypeMessage.Problem, DangerLevel.Wanted, $"User with Email ({email}) already exists"));
        
        var userEntity = UserEntityModel.Create(email, password);
        Database.Users.Add(userEntity);
        await Database.SaveChangesAsync();
        userEntity.PasswordHash = "";

        var userClaims = JwtProvider.SetUser(userEntity);
        return JwtProvider.GenerateNewToken(userClaims);
    }
}
