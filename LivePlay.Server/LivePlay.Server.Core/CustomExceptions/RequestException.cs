
using LivePlay.Server.Core.Abstracts;
using LivePlay.Server.Core.Enums;
using System.Net;

namespace LivePlay.Server.Core.CustomExceptions;

public class RequestException : BaseException
{
    public override HttpStatusCode StatusCode { get; } = HttpStatusCode.BadRequest;
    
    public Guid UserId { get; } = Guid.Empty;

    public RequestException(ErrorCode error, string messageAndDetails) : base(error, messageAndDetails, messageAndDetails)
    {
    }

    public RequestException(ErrorCode error, string message, string details) : base(error, message, details)
    {
    }

    public RequestException(ErrorCode error, string message, string details, HttpStatusCode statusCode) : base(error, message, details)
    {
        StatusCode = statusCode;
    }

    public RequestException(ErrorCode error, string message, string details, Guid userId) : base(error, message, details)
    {
        UserId = userId;
    }

    public RequestException(ErrorCode error, string message, string details, HttpStatusCode statusCode, Guid userId) : base(error, message, details)
    {
        UserId = userId;
        StatusCode = statusCode;
    }
}
