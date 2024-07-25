
using LivePlay.Server.Core.Abstracts;
using LivePlay.Server.Core.Enums;
using System.Net;

namespace LivePlay.Server.Core.CustomExceptions;

public class ServerException : BaseException
{
    public override HttpStatusCode StatusCode { get; } = HttpStatusCode.Forbidden;

    private const string DefaultMessage = "Server error, please try late";

    public ServerException(ErrorCode error, string details) : base(error, DefaultMessage, details) { }

    public ServerException(ErrorCode error, string message, HttpStatusCode statusCode, string details) : base(error, message, details)
    {
        StatusCode = statusCode;
    }
}
