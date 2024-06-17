
using LivePlay.Front.Application.Contracts.ResponseModel;
using LivePlay.Front.Application.Interfaces;
using LivePlay.Front.Application.Models.ResponseModel;
using LivePlay.Front.Core.Options;
using Microsoft.Extensions.Options;
using System.Data;
using System.Net;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;
using System.Web;

namespace LivePlay.Front.Application.HttpServices;

public class HttpProvider(IOptions<HttpProviderOptions> httpProviderOptions) : IHttpProvider
{
    private readonly static HttpClient HttpClient = 
        new(
            new HttpClientHandler()
            {
                ServerCertificateCustomValidationCallback = delegate { return true; }
            })
        {
            Timeout = TimeSpan.FromSeconds(10)
        };

    private HttpProviderOptions ProviderOptions { get; } = httpProviderOptions.Value;

    private string? Token { get; set; }

    private void SetToken(string token)
    {
        Token = token;
        HttpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
    }

    private static string GetRequestMessage(HttpResponseMessage? response, string? exceptionMessage)
    {
        string message = exceptionMessage ?? "Сообщения нет";
        if (response == null)
            return message;
        else
        {
            byte[] buffer = new byte[2048];
            int bytesRead = response.Content.ReadAsStream().Read(buffer);
            message = bytesRead == 0 ? "Сообщения нет" : Encoding.UTF8.GetString(buffer, 0, bytesRead);
        }
        return message;
    }

    private static async Task<BaseResponse<T>> CreateRequest<T>(Func<Task<HttpResponseMessage>> requestFunc)
    {
        try
        {
            HttpResponseMessage? response = await requestFunc();
            string responseBody = await response.Content.ReadAsStringAsync();

            switch (response.StatusCode)
            {
                case HttpStatusCode.OK:
                    T okBody = JsonSerializer.Deserialize<T>(responseBody)
                        ?? throw new Exception("Не удалось преобразовать полученный от сервера ответ");
                    return new ()
                    {
                        IsSuccess = true,
                        Data = okBody
                    };

                case HttpStatusCode.NoContent:
                    return new();

                default:
                    ErrorResponse errorBody = JsonSerializer.Deserialize<ErrorResponse>(responseBody)
                        ?? throw new Exception("Не удалось преобразовать полученный от сервера ответ");
                    return new()
                    {
                        IsSuccess = false,
                        Error = errorBody
                    };
            }
        }
        catch (Exception ex)
        {
            return new()
            {
                IsSuccess = false,
                Error = new ErrorResponse
                {
                    ErrorCode = "Not parse body",
                    Message = ex.Message
                }
            };
        }
    }

    private UriBuilder CreateUri(string route, params (string, string)[] requestParams)
    {
        UriBuilder uriBuilder = new ($"https://{ProviderOptions.Ip}:{ProviderOptions.Port}/{route}");

        var query = HttpUtility.ParseQueryString(uriBuilder.Query);
        foreach (var param in requestParams)
            query[param.Item1] = param.Item2;

        uriBuilder.Query = query.ToString();
        return uriBuilder;
    }

    public async Task<BaseResponse<T>> Get<T>(string route, params (string, string)[] requestParams)
    {
        var uriBuilder = CreateUri(route, requestParams);
        async Task<HttpResponseMessage> requestFunc() => await HttpClient.GetAsync(uriBuilder.Uri);
        return await CreateRequest<T>(requestFunc);
    }

    public async Task<BaseResponse<T>> Post<T, R>(string route, R jsonRequest, params (string, string)[] requestParams)
    {
        var uriBuilder = CreateUri(route, requestParams);
        string jsonRequestString = JsonSerializer.Serialize(jsonRequest);
        async Task<HttpResponseMessage> requestFunc() => await HttpClient.PostAsync(uriBuilder.Uri, new StringContent(jsonRequestString, Encoding.UTF8, "application/json"));
        return await CreateRequest<T>(requestFunc);
    }

    public async Task<BaseResponse<T>> Put<T, R>(string route, R jsonRequest, params (string, string)[] requestParams)
    {
        var uriBuilder = CreateUri(route, requestParams);
        string jsonRequestString = JsonSerializer.Serialize(jsonRequest);
        async Task<HttpResponseMessage> requestFunc() => await HttpClient.PutAsync(uriBuilder.Uri, new StringContent(jsonRequestString, Encoding.UTF8, "application/json"));
        return await CreateRequest<T>(requestFunc);
    }

    public async Task<BaseResponse<T>> Delete<T>(string route, params (string, string)[] requestParams)
    {
        var uriBuilder = CreateUri(route, requestParams);
        async Task<HttpResponseMessage> requestFunc() => await HttpClient.GetAsync(uriBuilder.Uri);
        return await CreateRequest<T>(requestFunc);
    }
}
