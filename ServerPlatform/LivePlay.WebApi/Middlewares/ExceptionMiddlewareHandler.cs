
using LivePlay.Server.Application.CustomExceptions;
using LivePlay.Server.WebApi.Contracts;
using System.Net;
using System.Text.Json;

namespace LivePlay.Server.WebApi.Middlewares;

public class ExceptionMiddlewareHandler(RequestDelegate next, ILogger<ExceptionMiddlewareHandler> logger)
{
    private readonly RequestDelegate _next = next;
    private readonly ILogger _logger = logger;
    public async Task InvokeAsync(HttpContext httpContext)
    {
        try
        {
            await _next(httpContext);
        }
        catch (BaseException ex)
        {
            await HandleExceptionAsync(httpContext, ex.Message, ex.Details, ex.StatusCode);
        }
    }

    private async Task HandleExceptionAsync(HttpContext context, string message, string details, HttpStatusCode httpStatusCode)
    {
        _logger.LogError($"Message: {message}\nDetails: {details}");
        HttpResponse response = context.Response;
        response.ContentType = "application/json"; response.StatusCode = (int)httpStatusCode;
        ErrorResponse errorResponse = new()
        {
            ErrorCode = "",
            Message = message
        };
        var body = JsonSerializer.Serialize(errorResponse);
        await response.WriteAsJsonAsync(body);
    }
}
