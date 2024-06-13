
using LivePlay.Server.Application.Interfaces;
using LivePlay.Server.Persistence.Repositories;
using LivePlay.Server.Infrastructure.Authorization;
using LivePlay.Server.Infrastructure;
using LivePlay.Server.Persistence;
using LivePlay.Server.WebApi.Extentions;
using Microsoft.AspNetCore.CookiePolicy;
using Microsoft.EntityFrameworkCore;
using LivePlay.Server.Infrastructure.Other;
using LivePlay.Server.WebApi.ProgramExtentions;

var builder = WebApplication.CreateBuilder(args);
var services = builder.Services;
var configuration = builder.Configuration;

services.AddDbContext<LivePlayDbContext>(options =>
{
    options.UseNpgsql(configuration.GetConnectionString(nameof(LivePlayDbContext)));
});

builder.GetConfigurations();

services.RegistryAppServices();
services.RegistryRepositories();
services.RegistryInfrastructure();
services.RegistryBackgrounds();

services.AddApiAuthentication(configuration);
services.AddApiPolitics();

services.AddControllers();
services.AddSwaggerGen();

var app = builder.Build();

//app.UseMiddleware<ExceptionMiddlewareHandler>();

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
