
using LivePlay.Server.Core.Abstract;
using LivePlay.Server.Core.Enums;
using LivePlay.Server.Core.Models;
using System.Net;

namespace LivePlay.Server.Application.CustomExceptions;

public class ServerException : BaseException
{
    public override HttpStatusCode StatusCode { get; } = HttpStatusCode.Forbidden;

    private const string DefaultMessage = "Server error, please try late";

    public ServerException(ErrorCode error, string details) : base(error, DefaultMessage, details)
    {
    }

    public ServerException(ErrorCode error, string message, HttpStatusCode statusCode, string details) : base(error, message, details)
    {
        StatusCode = statusCode;
    }
}
