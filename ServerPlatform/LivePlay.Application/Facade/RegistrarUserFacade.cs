
using LivePlay.Server.Core.CustomExceptions;
using LivePlay.Server.Core.Enums;

namespace LivePlay.Server.Application.Facade;

public class RegistrarUserFacade
{
    public Action<uint, string>? _checkEmailCode;
    public Func<string, uint>? _addNewEmailRegistration;
    public Func<uint, string>? _getRegistrationEmail;
    public Action<uint>? _sendCodeAgain;
    public Action<uint>? _popRegistrationEmail;

    public Action<uint, string>? CheckEmailCode
    {
        get => _checkEmailCode;
        set => _checkEmailCode ??= value ??
            throw new ServerException(ErrorCode.ServerError, $"Re-assigning an action {nameof(CheckEmailCode)} in RegistrarUserFacade");
    }
    public Func<string, uint>? AddNewEmailRegistration
    {
        get => _addNewEmailRegistration;
        set => _addNewEmailRegistration ??= value ??
            throw new ServerException(ErrorCode.ServerError, $"Re-assigning an action {nameof(AddNewEmailRegistration)} in RegistrarUserFacade");
    }
    public Func<uint, string>? GetRegistrationEmail
    {
        get => _getRegistrationEmail;
        set => _getRegistrationEmail ??= value ??
            throw new ServerException(ErrorCode.ServerError, $"Re-assigning an action {nameof(GetRegistrationEmail)} in RegistrarUserFacade");
    }
    public Action<uint>? SendCodeAgain
    {
        get => _sendCodeAgain;
        set => _sendCodeAgain ??= value ??
            throw new ServerException(ErrorCode.ServerError, $"Re-assigning an action {nameof(SendCodeAgain)} in RegistrarUserFacade");
    }
    public Action<uint>? PopRegistrationEmail
    {
        get => _popRegistrationEmail;
        set => _popRegistrationEmail ??= value ??
            throw new ServerException(ErrorCode.ServerError, $"Re-assigning an action {nameof(PopRegistrationEmail)} in RegistrarUserFacade");
    }
}
