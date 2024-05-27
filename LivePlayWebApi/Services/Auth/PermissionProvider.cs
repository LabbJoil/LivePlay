using LivePlayWebApi.Enums;
using Microsoft.AspNetCore.Authorization;

namespace LivePlayWebApi.Services.Auth;

public class PermissionProvider(Politic needPolitic) : IAuthorizationRequirement
{
    public Politic RequirePolitic { get; } = needPolitic;

    public Permission[] GetNeedPermitions()
    {
        return RequirePolitic switch
        {
            Politic.OnlyRead => [Permission.Read],
            Politic.Edit => [Permission.Update, Permission.Read, Permission.Create, Permission.Delete],
            _ => throw new NotImplementedException(),
        };
    }
}
