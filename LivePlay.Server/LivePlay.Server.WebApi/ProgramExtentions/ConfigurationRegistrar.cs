
using LivePlay.Server.Core.Options;
using LivePlay.Server.Persistence;
using Microsoft.EntityFrameworkCore;
using Npgsql;

namespace LivePlay.Server.WebApi.ProgramExtentions;

internal static class ConfigurationRegistrar
{
    public static void RegisterDb(this WebApplicationBuilder builder)
    {
        var connectionStrings = builder.Configuration.GetSection("ConnectionStrings").GetChildren();
        var connectionStringList = connectionStrings.Select(c => c.Value).ToList();

        foreach (var connectionString in connectionStringList)
        {
            try
            {
                using var connection = new NpgsqlConnection(connectionString);
                connection.Open();
                builder.Services.AddDbContext<LivePlayDbContext>(options =>
                {
                    options.UseNpgsql(connectionString);
                });
                return;
            }
            catch
            {
                continue;
            }
        }
        throw new Exception("Не удалось подключиться к ни одной из баз данных.");
    }

    public static void RegisterConfigurations(this WebApplicationBuilder builder)
    {
        builder.Services.Configure<RolePermissionOptions>(builder.Configuration.GetSection(nameof(RolePermissionOptions)));
        builder.Services.Configure<JwtOptions>(builder.Configuration.GetSection(nameof(JwtOptions)));
        builder.Services.Configure<SmtpClientOptions>(builder.Configuration.GetSection(nameof(SmtpClientOptions)));
        builder.Services.Configure<QROptions>(builder.Configuration.GetSection(nameof(QROptions)));
    }

    public static void ApplyMigrations(this WebApplication app)
    {
        using IServiceScope scope = app.Services.CreateScope();
        using LivePlayDbContext dbContext = scope.ServiceProvider.GetRequiredService<LivePlayDbContext>();
        dbContext.Database.Migrate();
    }
}
