using LivePlay.Server.Infrastructure;
using LivePlay.Server.Persistence;

namespace LivePlay.Server.WebApi.ProgramExtentions;

public static class ConfigurationRegistor
{
    public static void GetConfigurations(this WebApplicationBuilder builder)
    {
        builder.Services.Configure<RolePermissionOptions>(builder.Configuration.GetSection(nameof(RolePermissionOptions)));
        builder.Services.Configure<JwtOptions>(builder.Configuration.GetSection(nameof(JwtOptions)));
    }
}
