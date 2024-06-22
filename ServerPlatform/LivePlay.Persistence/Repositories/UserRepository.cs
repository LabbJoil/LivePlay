
using AutoMapper;
using LivePlay.Server.Application.CustomExceptions;
using LivePlay.Server.Core.Enums;
using LivePlay.Server.Core.Interfaces;
using LivePlay.Server.Core.Models;
using LivePlay.Server.Persistence.EntityModels.Base;
using Microsoft.EntityFrameworkCore;

namespace LivePlay.Server.Persistence.Repositories;

public class UserRepository(LivePlayDbContext dbContext, IMapper mapper) : IUserRepository
{
    private readonly LivePlayDbContext _dbContext = dbContext;
    private readonly IMapper _mapper = mapper;

    public async Task<bool> CheckUserByEmail(string email)
    {
        var user = await _dbContext.Users
            .AsNoTracking()
            .FirstOrDefaultAsync(u => u.Email == email);
        if (user != null)
            return true;
        else 
            return false;
    }

    public async Task<User> GetUserById(Guid id)
    {
        var userEntity = await _dbContext.Users
            .AsNoTracking()
            .FirstOrDefaultAsync(u => u.Id == id)
            ?? throw new RequestException(ErrorCode.DbGetError, $"The user could not be found", $"Not found user with id - {id}");
        User user = _mapper.Map<User>(userEntity);
        return user;
    }
    
    public async Task<(User, Guid)> GetUserByEmail(string email)
    {
        var userEntity = await _dbContext.Users
            .AsNoTracking()
            .FirstOrDefaultAsync(u => u.Email == email)
            ?? throw new RequestException(ErrorCode.DbGetError, $"No user with email: {email}", $"Not found user with email - {email}");
        User user = _mapper.Map<User>(userEntity);
        return (user, userEntity.Id);
    }

    public async Task<Guid> AddUser(User user)
    {
        var role = await _dbContext.Roles
            .FirstOrDefaultAsync(r => r.Id == (int)Role.User)
            ?? throw new ServerException(ErrorCode.DbAddError, $"Don`t found role for user");

        var userEntity = _mapper.Map<UserEntityModel>(user);
        userEntity.Roles = [role];

        await _dbContext.Users.AddAsync(userEntity);
        await _dbContext.SaveChangesAsync();
        return userEntity.Id;
    }

    public async Task DeleteUser(Guid id)
    {
        UserEntityModel userEntity = await _dbContext.Users
            .FindAsync(id)
            ?? throw new ServerException(ErrorCode.DbDeleteError, $"Not found user with id - {id} to delete");
        _dbContext.Users.Remove(userEntity);
        await _dbContext.SaveChangesAsync();
    }

    public async Task EditUser(Guid id, User newUser)
    {
        UserEntityModel userEntity = await _dbContext.Users
            .FindAsync(id)
            ?? throw new ServerException(ErrorCode.DbDeleteError, $"Not found user with id - {id} to delete");
        string hash = userEntity.PasswordHash;
        userEntity = _mapper.Map<UserEntityModel>(newUser);
        userEntity.PasswordHash = hash;
        await _dbContext.SaveChangesAsync();
    }
}
