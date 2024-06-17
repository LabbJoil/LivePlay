using System.Net;

namespace LivePlay.Server.Application.CustomExceptions;

public class ServerException(string message, string details) : BaseException(message, details, HttpStatusCode.Forbidden)
{
}
