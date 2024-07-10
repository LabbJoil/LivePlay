
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


    protected HttpProvider HttpProvider { get; }
    protected IMapper Mapper { get; }
    protected abstract string BaseRoute { get; }

    public BaseHttpServise(IServiceScopeFactory serviceScopeFactory)
    {
        using var scope = serviceScopeFactory.CreateScope();
        Mapper = scope.ServiceProvider.GetRequiredService<IMapper>();
        HttpProvider = scope.ServiceProvider.GetRequiredService<HttpProvider>();
    }

    protected (T?, DisplayError?) ParseResponse<T>(BaseResponse response)
    {
        if (response.IsSuccess)
        {
            T? body = JsonSerializer.Deserialize<T>(response.ResponseData);
            if (body == null)
                return (default, ParseError(response.ResponseData, response.Error));
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
            errorDisplay = Mapper.Map<DisplayError>(errorResponse);
        return errorDisplay;
    }
}
