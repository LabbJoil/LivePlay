
using LivePlay.Server.Persistence;
using Microsoft.EntityFrameworkCore;

namespace LivePlay.Server.WebApi.ProgramExtentions;

public static class MigrationExtension
{
    public static void ApplyMigrations(this IApplicationBuilder app)
    {
        using IServiceScope scope = app.ApplicationServices.CreateScope();
        using LivePlayDbContext dbContext = scope.ServiceProvider.GetRequiredService<LivePlayDbContext>();
        dbContext.Database.Migrate();
    }
}
