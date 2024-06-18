
using AutoMapper;
using LivePlay.Server.Application.CustomExceptions;
using LivePlay.Server.Core.Enums;
using LivePlay.Server.Core.Interfaces;
using LivePlay.Server.Core.Models;
using LivePlay.Server.Persistence.EntityModels.Base;
using Microsoft.EntityFrameworkCore;
using Npgsql.Replication.PgOutput.Messages;

namespace LivePlay.Server.Persistence.Repositories;

public class UserRepository(LivePlayDbContext dbContext, IMapper mapper) : IUserRepository
{
    private readonly LivePlayDbContext _dbContext = dbContext;
    private readonly IMapper _mapper = mapper;

    public async Task<bool> CheckUserByEmail(string email)
    {
        var user = await _dbContext.Users.AsNoTracking().FirstOrDefaultAsync(u => u.Email == email);
        if (user != null)
            return true;
        else 
            return false;
    }

    public async Task<User> GetUserById(Guid id)
    {
        var userEntity = await _dbContext.Users.AsNoTracking().FirstOrDefaultAsync(u => u.Id == id) ??
            throw new RequestException(ErrorCode.DbGetError, $"The user could not be found", $"Not found user with id - {id}");
        return _mapper.Map<User>(userEntity);
    }
    
    public async Task<User> GetUserByEmail(string email)
    {
        var userEntity = await _dbContext.Users.AsNoTracking().FirstOrDefaultAsync(u => u.Email == email) ??
            throw new RequestException(ErrorCode.DbGetError, $"No user with email: {email}", $"Not found user with email - {email}");
        return _mapper.Map<User>(userEntity);
    }

    public async Task<Guid> AddUser(User user)
    {
        var role = await _dbContext.Roles.FirstOrDefaultAsync(r => r.Id == (int)Role.User) ??
            throw new ServerException(ErrorCode.DbAddError, $"No found role for user");

        user.Email = "88";
        var userEntity = _mapper.Map<UserEntityModel>(user);
        userEntity.Roles = [role];

        _dbContext.Users.Add(userEntity);
        await _dbContext.SaveChangesAsync();
        return userEntity.Id;
    }

    public async Task DeleteUser(Guid idUser)
    {
        UserEntityModel user = await _dbContext.Users.FindAsync(idUser) ??
            throw new ServerException(ErrorCode.DbDeleteError, $"Not found user with id - {idUser} to delete");
        _dbContext.Users.Remove(user);
        await _dbContext.SaveChangesAsync();
    }

    public async Task EditUser(Guid idUser, User newUser)
    {
        UserEntityModel user = await _dbContext.Users.FindAsync(idUser) ??
            throw new ServerException(ErrorCode.DbDeleteError, $"Not found user with id - {idUser} to delete");
        string hash = user.PasswordHash;
        user = _mapper.Map<UserEntityModel>(newUser);
        user.PasswordHash = hash;
        await _dbContext.SaveChangesAsync();
    }
}
