
using LivePlayWebApi.Interfaces;
using LivePlayWebApi.Services;
using LivePlayWebApi.Services.Entities;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
var services = builder.Services;
var configuration = builder.Configuration;

services.AddControllers();
services.AddEndpointsApiExplorer();
services.AddAuthorization();
services.AddSwaggerGen();

services.Configure<JwtOptions>(configuration.GetSection(nameof(JwtOptions)));

services.AddDbContext<ContextDB>(options =>
{
    options.UseNpgsql(configuration.GetConnectionString(nameof(ContextDB)));
});

services.AddScoped<UserService>();

services.AddScoped<IJwtProvider, JwtProvider>();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthentication();
app.UseAuthorization();
app.UseHttpsRedirection();
app.MapControllers();
app.Run();
