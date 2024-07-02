
using LivePlay.Server.Core.Options;
using LivePlay.Server.Persistence;
using Microsoft.EntityFrameworkCore;

namespace LivePlay.Server.WebApi.ProgramExtentions;

public static class ConfigurationRegistrar
{
    public static void RegisterDb(this WebApplicationBuilder builder)
    {
        builder.Services.AddDbContext<LivePlayDbContext>(options =>
        {
            options.UseNpgsql(builder.Configuration.GetConnectionString(nameof(LivePlayDbContext)));
        });
    }

    public static void RegisterConfigurations(this WebApplicationBuilder builder)
    {
        builder.Services.Configure<RolePermissionOptions>(builder.Configuration.GetSection(nameof(RolePermissionOptions)));
        builder.Services.Configure<JwtOptions>(builder.Configuration.GetSection(nameof(JwtOptions)));
        builder.Services.Configure<SmtpClientOptions>(builder.Configuration.GetSection(nameof(SmtpClientOptions)));
        builder.Services.Configure<QROptions>(builder.Configuration.GetSection(nameof(QROptions)));
    }
}
