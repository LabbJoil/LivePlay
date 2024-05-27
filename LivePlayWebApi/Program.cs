
using LivePlayWebApi.Interfaces;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.CookiePolicy;
using LivePlayWebApi.Data;
using LivePlayWebApi.Services.Repositories;
using LivePlayWebApi.Services.ConfigurationOptions;
using LivePlayWebApi.Services.Authorization;
using LivePlayWebApi.Services.MidllWare;
using LivePlayWebApi.Services.Auth;
using LivePlayWebApi.Extentions;
using Microsoft.Extensions.DependencyInjection;

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

services.AddScoped<UserService>();
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
