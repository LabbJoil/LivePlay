
namespace LivePlay.Server.Core.Enums;

public enum ErrorCode
{
    ServerError,
    RequestError,
    RegistrationError,

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
    UserPoints,
    FalseAnswer,
    Auth
}
