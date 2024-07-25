
using AutoMapper;
using LivePlay.Server.Core.CustomExceptions;
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

    public async Task<User> GetById(Guid id)
    {
        var userEntity = await GetEntryById(id);
        User user = _mapper.Map<User>(userEntity);
        return user;
    }

    internal async Task<UserEntityModel> GetEntryById(Guid id)
    {
        var userEntity = await _dbContext.Users
            .AsNoTracking()
            .Include(u => u.Roles)
            .FirstOrDefaultAsync(u => u.Id == id)
            ?? throw new RequestException(ErrorCode.DbGetError, $"The user could not be found", $"Not found user with id - {id}");
        return userEntity;
    }

    public async Task<User> GetByEmail(string email)
    {
        var userEntity = await _dbContext.Users
            .AsNoTracking()
            .Include(u => u.Roles)
            .FirstOrDefaultAsync(u => u.Email == email)
            ?? throw new RequestException(ErrorCode.DbGetError, $"No user with email: {email}", $"Not found user with email - {email}");
        var roles = userEntity.Roles.ToArray();
        var user = _mapper.Map<User>(userEntity);
        return user;
    }

    public async Task<Guid> Add(User user)
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

    public async Task Delete(Guid id)
    {
        UserEntityModel userEntity = await _dbContext.Users
            .FindAsync(id)
            ?? throw new ServerException(ErrorCode.DbDeleteError, $"Not found user with id - {id} to delete");
        _dbContext.Users.Remove(userEntity);
        await _dbContext.SaveChangesAsync();
    }

    public async Task Edit(Guid id, User newUser)
    {
        UserEntityModel userEntity = await _dbContext.Users
            .FindAsync(id)
            ?? throw new ServerException(ErrorCode.DbDeleteError, $"Not found user with id - {id} to delete");
        string hash = userEntity.PasswordHash;
        userEntity = _mapper.Map<UserEntityModel>(newUser);
        userEntity.PasswordHash = hash;
        await _dbContext.SaveChangesAsync();
    }

    public async Task<int> IncreasePoints(Guid userId, int newCountPoints)
    {
        var userEntity = await _dbContext.Users
            .FirstOrDefaultAsync(u => u.Id == userId)
            ?? throw new RequestException(ErrorCode.DbGetError, $"No user with id: {userId}", $"Not found user with id - {userId}");

        var newUserPoints = userEntity.Points + newCountPoints;
        if (newUserPoints < 0)
            throw new RequestException(ErrorCode.UserPoints, "Insufficient funds");
        userEntity.Points= newUserPoints;
        await _dbContext.SaveChangesAsync();
        return userEntity.Points;
    }

    internal async Task<UserEntityModel> GetOpenEntityById(Guid id)
    {
        var userEntity = await _dbContext.Users
            .FindAsync(id)
            ?? throw new RequestException(ErrorCode.RequestError, "Сouldn't find the user", $"User with id {id} not found");
        return userEntity;
    }
}
