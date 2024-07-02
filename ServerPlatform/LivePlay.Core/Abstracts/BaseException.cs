
using LivePlay.Server.Core.Enums;
using System.Net;

namespace LivePlay.Server.Core.Abstracts;

public abstract class BaseException(ErrorCode error, string message, string details) : Exception(message)
{
    public abstract HttpStatusCode StatusCode { get; }
    public ErrorCode Error { get; } = error;
    public string Details { get; } = details;
}
