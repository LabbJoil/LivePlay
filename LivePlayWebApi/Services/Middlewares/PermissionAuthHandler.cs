
using LivePlayWebApi.Interfaces;
using LivePlayWebApi.Services.Auth;
using LivePlayWebApi.Services.Authorization;
using LivePlayWebApi.Services.Repositories;
using Microsoft.AspNetCore.Authorization;

namespace LivePlayWebApi.Services.Middlewares;
public class PermissionAuthHandler(IServiceScopeFactory serviceScopeFactory, IJwtProvider jwtProvider) : AuthorizationHandler<PermissionProvider>
{
    private readonly IServiceScopeFactory _serviceScopeFactory = serviceScopeFactory;
    private readonly IJwtProvider _jwtProvider = jwtProvider;
        
    protected override async Task HandleRequirementAsync(AuthorizationHandlerContext context, PermissionProvider permissionRequirement)
    {
        var userId = _jwtProvider.GetUserId(context.User);

        using var scope = _serviceScopeFactory.CreateScope();
        var permissionService = scope.ServiceProvider.GetRequiredService<UserService>();

        var userPermissions = await permissionService.GetUserPermissions(userId);
        var needPoliticPermissions = permissionRequirement.GetNeedPermitions();
        if (needPoliticPermissions.All(userPermissions.Contains))
            context.Succeed(permissionRequirement);
    }
}
