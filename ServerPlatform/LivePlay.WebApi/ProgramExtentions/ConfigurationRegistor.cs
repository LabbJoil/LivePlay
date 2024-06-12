using LivePlay.Infrastructure;
using LivePlay.Persistence;

namespace LivePlay.WebApi.ProgramExtentions;

public static class ConfigurationRegistor
{
    public static void GetConfigurations(this WebApplicationBuilder builder)
    {
        builder.Services.Configure<RolePermissionOptions>(builder.Configuration.GetSection(nameof(RolePermissionOptions)));
        builder.Services.Configure<JwtOptions>(builder.Configuration.GetSection(nameof(JwtOptions)));
    }
}
