
using AutoMapper;
using LivePlay.Front.Infrastructure.Contracts.Responses;
using LivePlay.Front.Infrastructure.Interfaces;
using LivePlay.Front.Infrastructure.Models.ResponseModel;
using LivePlay.Front.Core.Models;
using Microsoft.Extensions.DependencyInjection;
using System.Text.Json;

namespace LivePlay.Front.Infrastructure.Abstracts;

public abstract class BaseHttpServise
{
    private readonly DisplayError _defaultError = new()
    {
        Title = "Request error",
        Message = "Не удалось преобразовать полученный от сервера ответ"
    };
    protected readonly HttpProvider _httpProvider;
    protected readonly IMapper _mapper;

    protected abstract string BaseRoute { get; }

    public BaseHttpServise(IServiceScopeFactory serviceScopeFactory)
    {
        using var scope = serviceScopeFactory.CreateScope();
        _mapper = scope.ServiceProvider.GetRequiredService<IMapper>();
        _httpProvider = scope.ServiceProvider.GetRequiredService<HttpProvider>();
    }

    protected (T?, DisplayError?) ParseResponse<T>(BaseResponse response)
    {
        var body = Deserialize<T>(response.ResponseData);
        if (body == null)
            return (default, ParseError(response.ResponseData, response.Error));
        return (body, null);
    }

    protected DisplayError ParseError(string errorBody, string? errorRequest)
    {
        var errorResponse = Deserialize<ErrorResponse>(errorBody);
        DisplayError errorDisplay;
        if (errorResponse == null)
        {
            errorDisplay = errorRequest == null ? _defaultError : new()
            {
                Title = "Request error",
                Message = errorRequest
            };
        }
        else
            errorDisplay = _mapper.Map<DisplayError>(errorResponse);
        return errorDisplay;
    }

    private static T? Deserialize<T>(string body)
    {
        T? deserializeBody;
        try
        {
            deserializeBody = JsonSerializer.Deserialize<T>(body);
        }
        catch
        {
            deserializeBody = default;
        }
        return deserializeBody;
    }
}
