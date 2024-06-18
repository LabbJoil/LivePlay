﻿
using LivePlay.Server.Application.CustomExceptions;
using LivePlay.Server.Core.Enums;
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
        const string messageLoger = "ErrorCode: {Error}\nMessage: {Message}\nDetails:{Details}";
        try
        {
            await _next(httpContext);
        }
        catch (ServerException ex)
        {
            _logger.LogError(messageLoger, ex.Error, ex.Message, ex.Details);
            await HandleExceptionAsync(httpContext, ex.Error, ex.Message, ex.StatusCode);
        }
        catch (RequestException ex)
        {
            string details = ex.Details + " || User: {UserId}";
            _logger.LogError(messageLoger, ex.Error, ex.Message, details);
            await HandleExceptionAsync(httpContext, ex.Error, ex.Message, ex.StatusCode);
        }
    }

    private async Task HandleExceptionAsync(HttpContext context, ErrorCode error, string message, HttpStatusCode statusCode)
    {
        
        HttpResponse response = context.Response;
        response.ContentType = "application/json"; response.StatusCode = (int)statusCode;
        ErrorResponse errorResponse = new()
        {
            ErrorCode = error,
            Message = message
        };
        var body = JsonSerializer.Serialize(errorResponse);
        await response.WriteAsJsonAsync(body);
    }
}
