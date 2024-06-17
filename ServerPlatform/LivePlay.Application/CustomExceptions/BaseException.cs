
using System.Net;

namespace LivePlay.Server.Application.CustomExceptions;

public class BaseException(string message, string details, HttpStatusCode statusCode) : Exception(message)
{
    public HttpStatusCode StatusCode { get; } = statusCode;
    public string Details { get; } = details;
}
