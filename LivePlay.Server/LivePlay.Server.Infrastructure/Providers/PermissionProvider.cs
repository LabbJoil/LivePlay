﻿
using LivePlay.Server.Core.CustomExceptions;
using LivePlay.Server.Core.Enums;
using Microsoft.AspNetCore.Authorization;

namespace LivePlay.Server.Infrastructure.Providers;

public class PermissionProvider(Politic needPolitic) : IAuthorizationRequirement
{
    public Politic RequirePolitic { get; } = needPolitic;

    public Permission[] GetNeedPermissions()
    {
        return RequirePolitic switch
        {
            Politic.EditQuest => [Permission.ReadQuest, Permission.CreateQuest, Permission.UpdateQuest, Permission.DeleteQuest],
            Politic.EditCoupon => [Permission.ReadCoupon, Permission.CreateCoupon, Permission.UpdateCoupon, Permission.DeleteCoupon],
            Politic.PersonalInfo => [Permission.GetSelf, Permission.UpdateSelf, Permission.DeleteSelf],
            Politic.GetActions => [Permission.ReadQuest, Permission.ReadCoupon],
            _ => throw new ServerException(ErrorCode.PermitionError, $"Couldn't find permissions for the policy {RequirePolitic}"),
        };
    }
}
