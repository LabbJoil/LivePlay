
using LivePlay.Application.Interfaces;
using LivePlay.Persistence.Repositories;
using LivePlay.Infrastructure.Authorization;
using LivePlay.Infrastructure;
using LivePlay.Persistence;
using LivePlayApplication.Extentions;
using Microsoft.AspNetCore.CookiePolicy;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
var services = builder.Services;
var configuration = builder.Configuration;

services.AddDbContext<LivePlayDbContext>(options =>
{
    options.UseNpgsql(configuration.GetConnectionString(nameof(LivePlayDbContext)));
});

services.Configure<RolePermissionOptions>(configuration.GetSection(nameof(RolePermissionOptions)));
services.Configure<JwtOptions>(configuration.GetSection(nameof(JwtOptions)));

services.AddControllers();
services.AddSwaggerGen();

services.AddScoped<UserRepository>();
services.AddSingleton<IJwtProvider, JwtProvider>();

services.AddApiAuthentication(configuration);
services.AddApiPolitics();

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
