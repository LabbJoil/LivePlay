#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
USER app
WORKDIR /app
EXPOSE 8080
EXPOSE 8081

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["ServerPlatform/LivePlay.WebApi/LivePlay.Server.WebApi.csproj", "ServerPlatform/LivePlay.WebApi/"]
COPY ["ServerPlatform/LivePlay.Application/LivePlay.Server.Application.csproj", "ServerPlatform/LivePlay.Application/"]
COPY ["ServerPlatform/LivePlay.Core/LivePlay.Server.Core.csproj", "ServerPlatform/LivePlay.Core/"]
COPY ["ServerPlatform/LivePlay.Infrastructure/LivePlay.Server.Infrastructure.csproj", "ServerPlatform/LivePlay.Infrastructure/"]
COPY ["ServerPlatform/LivePlay.Persistence/LivePlay.Server.Persistence.csproj", "ServerPlatform/LivePlay.Persistence/"]
RUN dotnet restore "./ServerPlatform/LivePlay.WebApi/LivePlay.Server.WebApi.csproj"
COPY . .
WORKDIR "/src/ServerPlatform/LivePlay.WebApi"
RUN dotnet build "./LivePlay.Server.WebApi.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./LivePlay.Server.WebApi.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "LivePlay.Server.WebApi.dll"]