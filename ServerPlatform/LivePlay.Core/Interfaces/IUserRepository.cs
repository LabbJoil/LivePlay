using LivePlay.Server.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LivePlay.Server.Core.Interfaces;

public interface IUserRepository
{
    public Task<Guid> Add(User user);
    public Task<bool> CheckUserByEmail(string email);
    public Task<User> GetById(Guid id);
    public Task<User> GetByEmail(string email);
    public Task Delete(Guid idUser);
    public Task Edit(Guid idUser, User newUser);
    public Task<int> IncreasePoints(Guid userId, int newCountPoints);
}
