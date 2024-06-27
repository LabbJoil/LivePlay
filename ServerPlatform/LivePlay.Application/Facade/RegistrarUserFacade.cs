
using LivePlay.Server.Core.Models;

namespace LivePlay.Server.Application.Facade;

public class RegistrarUserFacade
{
    public Action<uint, string>? CheckCodeRegistrationUser;
    public Func<string, uint>? AddNewRegistrationUser;
    public Func<uint, string>? GetRegistrationUser;
}
