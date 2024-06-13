
using LivePlay.Server.Application.Interfaces;
using LivePlay.Server.Application.Services.Auth;
using LivePlay.Server.Persistence.Repositories;
using Microsoft.AspNetCore.Authorization;

namespace LivePlay.Server.WebApi.Services.Middlewares;
public class PermissionAuthHandler(IServiceScopeFactory serviceScopeFactory, IJwtProvider jwtProvider) : AuthorizationHandler<PermissionProvider>
{
    private readonly IServiceScopeFactory _serviceScopeFactory = serviceScopeFactory;
    private readonly IJwtProvider _jwtProvider = jwtProvider;
        
    protected override async Task HandleRequirementAsync(AuthorizationHandlerContext context, PermissionProvider permissionRequirement)
    {
        var userId = _jwtProvider.GetUserId(context.User);

        using var scope = _serviceScopeFactory.CreateScope();
        var permissionService = scope.ServiceProvider.GetRequiredService<PermissionRepository>();

        var userPermissions = await permissionService.GetUserPermissions(userId);
        var needPoliticPermissions = permissionRequirement.GetNeedPermitions();
        if (needPoliticPermissions.All(userPermissions.Contains))
            context.Succeed(permissionRequirement);
    }
}
