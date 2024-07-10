
using LivePlay.Server.Application.Interfaces;
using LivePlay.Server.Core.CustomExceptions;
using LivePlay.Server.Core.Enums;

namespace LivePlay.Server.Application.Facade;

public class BackgroundFacade
{

    private IRegistrarUserBackground? _registrarUserBackground { get; set; }

    public IRegistrarUserBackground RegistrarUserBackground
    {
        get => _registrarUserBackground ??
            throw new ServerException(ErrorCode.ServerError, $"The value of the {nameof(RegistrarUserBackground)} field in {nameof(BackgroundFacade)}not found");
        set => _registrarUserBackground ??= value ??
            throw new ServerException(ErrorCode.ServerError, $"Re-assigning an field {nameof(RegistrarUserBackground)} in {nameof(BackgroundFacade)}");
    }
}
