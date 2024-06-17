
using LivePlay.Server.WebApi.Extentions;
using LivePlay.Server.WebApi.Middlewares;
using LivePlay.Server.WebApi.ProgramExtentions;
using Microsoft.AspNetCore.CookiePolicy;

var builder = WebApplication.CreateBuilder(args);
var services = builder.Services;
var configuration = builder.Configuration;

builder.RegisterDb();
builder.RegisterConfigurations();

services.RegisterAppServices();
services.RegisterRepositories();
services.RegisterInfrastructure();
services.RegisterBackgrounds();

services.AddApiAuthentication(configuration);
services.AddApiPolitics();

services.AddControllers();
services.AddSwaggerGen();

var app = builder.Build();

app.UseMiddleware<ExceptionMiddlewareHandler>();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCookiePolicy(new CookiePolicyOptions
{
    MinimumSameSitePolicy = SameSiteMode.Strict,
    HttpOnly = HttpOnlyPolicy.Always,
    Secure = CookieSecurePolicy.Always
});

app.UseAuthentication();
app.UseAuthorization();
app.UseHttpsRedirection();
app.MapControllers();
app.Run();
