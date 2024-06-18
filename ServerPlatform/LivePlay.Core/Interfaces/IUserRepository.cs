using LivePlay.Server.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LivePlay.Server.Core.Interfaces;

public interface IUserRepository
{
    public Task<Guid> AddUser(User user);
    public Task<bool> CheckUserByEmail(string email);
    public Task<User> GetUserById(Guid id);
    public Task<User> GetUserByEmail(string email);
    public Task DeleteUser(Guid idUser);
    public Task EditUser(Guid idUser, User newUser);
}
