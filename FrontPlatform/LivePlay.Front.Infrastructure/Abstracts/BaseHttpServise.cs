
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
    protected readonly HttpProvider _httpProvider;
    protected readonly IMapper _mapper;
    private readonly DisplayError _defaultError = new()
    {
        Title = "Request error",
        Message = "Не удалось преобразовать полученный от сервера ответ"
    };

    protected abstract string BaseRoute { get; }

    public BaseHttpServise(IServiceScopeFactory serviceScopeFactory)
    {
        using var scope = serviceScopeFactory.CreateScope();
        _mapper = scope.ServiceProvider.GetRequiredService<IMapper>();
        _httpProvider = scope.ServiceProvider.GetRequiredService<HttpProvider>();
    }

    protected (T?, DisplayError?) ParseResponse<T>(BaseResponse response)
    {
        if (response.IsSuccess)
        {
            T? body = JsonSerializer.Deserialize<T>(response.ResponseData);
            return (body, null);
        }
        else
            return (default, ParseError(response.ResponseData, response.Error));
    }

    protected DisplayError ParseError(string errorBody, string? errorRequest)
    {
        ErrorResponse? errorResponse = JsonSerializer.Deserialize<ErrorResponse>(errorBody);
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
}
