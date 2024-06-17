using System.Net;

namespace LivePlay.Server.Application.CustomExceptions;

public class RequestException(string message, string details) : BaseException(message, details, HttpStatusCode.BadRequest)
{
}
