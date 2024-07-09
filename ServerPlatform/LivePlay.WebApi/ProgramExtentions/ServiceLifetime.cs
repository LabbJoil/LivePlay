
using LivePlay.Server.Application.Interfaces;
using LivePlay.Server.Core.CustomExceptions;
using LivePlay.Server.Core.Enums;

namespace LivePlay.Server.WebApi.ProgramExtentions;

public static class ServiceLifetime
{
    public static void ControlAppLifetime(this WebApplication app)
    {
        app.Lifetime.ApplicationStopping.Register(app.OnApplicationStopping);
    }

    public static void OnApplicationStopping(this WebApplication app)
    {
        var emailProvider = app.Services.GetService<IEmailProvider>()
            ?? throw new ServerException(ErrorCode.ServerError, $"Service {nameof(IEmailProvider)} not found");
        emailProvider.Disconect();
        app.Logger.LogInformation("All services stoped");
    }
}
