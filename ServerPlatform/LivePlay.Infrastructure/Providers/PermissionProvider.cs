
using Microsoft.AspNetCore.Authorization;
using LivePlay.Server.Core.Enums;

namespace LivePlay.Server.Infrastructure.Providers;

public class PermissionProvider(Politic needPolitic) : IAuthorizationRequirement
{
    public Politic RequirePolitic { get; } = needPolitic;

    public Permission[] GetNeedPermitions()
    {
        return RequirePolitic switch
        {
            Politic.EditQuest => [Permission.ReadQuest, Permission.CreateQuest, Permission.UpdateSelf, Permission.DeleteQuest],
            Politic.EditCoupon => [Permission.ReadCoupon, Permission.CreateCoupon, Permission.UpdateCoupon, Permission.DeleteCoupon],
            Politic.EditPersonalInfo => [Permission.UpdateSelf, Permission.DeleteSelf],
            _ => throw new NotImplementedException(),
        };
    }
}
