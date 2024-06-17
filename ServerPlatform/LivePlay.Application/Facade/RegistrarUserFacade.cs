
using LivePlay.Server.Core.Models;

namespace LivePlay.Server.Application.Facade;

public class RegistrarUserFacade
{
    public Func<uint, string, bool>? CheckCodeRegistrationUser;
    public Func<User, uint>? AddNewRegistrationUser;
}
