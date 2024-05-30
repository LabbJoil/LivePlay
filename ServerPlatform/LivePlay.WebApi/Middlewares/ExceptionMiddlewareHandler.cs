namespace LivePlayApplication.Services.MidllWare;

public class ExceptionMiddlewareHandler(RequestDelegate next, ILogger<ExceptionMiddlewareHandler> logger)
{
    private readonly RequestDelegate Next = next;
    private readonly ILogger Logger = logger;


}
