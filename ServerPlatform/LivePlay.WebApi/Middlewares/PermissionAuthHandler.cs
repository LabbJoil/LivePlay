
using LivePlay.Server.Application.Interfaces;
using LivePlay.Server.Infrastructure.Providers;
using LivePlay.Server.Persistence.Repositories;
using Microsoft.AspNetCore.Authorization;

namespace LivePlay.Server.WebApi.Middlewares;
public class PermissionAuthHandler(IServiceScopeFactory serviceScopeFactory, IJwtProvider jwtProvider) : AuthorizationHandler<PermissionProvider>
{
    private readonly IServiceScopeFactory _serviceScopeFactory = serviceScopeFactory;
    private readonly IJwtProvider _jwtProvider = jwtProvider;
        
    protected override async Task HandleRequirementAsync(AuthorizationHandlerContext context, PermissionProvider permissionRequirement)
    {
        var userId = _jwtProvider.GetUserId(context.User);

        using var scope = _serviceScopeFactory.CreateScope();
        var permissionService = scope.ServiceProvider.GetRequiredService<PermissionRepository>();   // TODO: заслать в конструктор?

        var userPermissions = await permissionService.GetUserPermissions(userId);
        var needPoliticPermissions = permissionRequirement.GetNeedPermissions();
        if (needPoliticPermissions.All(userPermissions.Contains))
            context.Succeed(permissionRequirement);
    }
}
