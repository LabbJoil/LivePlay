
namespace LivePlay.Server.Core.Enums;

public enum ErrorCode
{
    ServerError,
    RequestError,
    RegistrationError,
    VerifyEmailError,

    DbCheckError,
    DbPostError,
    DbGetError,
    DbAddError,
    DbDeleteError,

    LoginUser,
    ClaimsParse,
    QRProviderError,
    InternalError,
    PermitionError,
    UserPoints
}
