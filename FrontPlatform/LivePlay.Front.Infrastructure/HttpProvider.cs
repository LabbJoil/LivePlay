
using LivePlay.Front.Infrastructure.Contracts.Responses;
using LivePlay.Front.Infrastructure.Interfaces;
using LivePlay.Front.Core.Options;
using Microsoft.Extensions.Options;
using System.Net;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;
using System.Web;

namespace LivePlay.Front.Infrastructure;

public class HttpProvider(IOptions<HttpProviderOptions> httpProviderOptions)
{
    private readonly static HttpClient _httpClient = 
        new(
            new HttpClientHandler()
            {
                ServerCertificateCustomValidationCallback = delegate { return true; }
            })
        {
            Timeout = TimeSpan.FromSeconds(10)
        };

    private readonly HttpProviderOptions _providerOptions = httpProviderOptions.Value;

    private string? Token { get; set; }

    public void SetToken(string token)
    {
        Token = token;
        _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
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

    private static async Task<BaseResponse> CreateRequest(Func<Task<HttpResponseMessage>> requestFunc)
    {
        try
        {
            HttpResponseMessage? response = await requestFunc();
            string responseBody = await response.Content.ReadAsStringAsync();

            return response.StatusCode switch
            {
                HttpStatusCode.OK => new(responseBody),
                HttpStatusCode.NoContent => new(),
                _ => new()
                {
                    IsSuccess = false,
                    ResponseData = responseBody
                },
            };
        }
        catch (Exception ex)
        {
            return new()
            {
                IsSuccess = false,
                Error = ex.Message
            };
        }
    }

    private UriBuilder CreateUri(string route, params (string, string)[] requestParams)
    {
        UriBuilder uriBuilder = new ($"https://{_providerOptions.Ip}:{_providerOptions.Port}/{route}");

        var query = HttpUtility.ParseQueryString(uriBuilder.Query);
        foreach (var param in requestParams)
            query[param.Item1] = param.Item2;

        uriBuilder.Query = query.ToString();
        return uriBuilder;
    }

    public async Task<BaseResponse> Get(string route, params (string, string)[] requestParams)
    {
        var uriBuilder = CreateUri(route, requestParams);
        async Task<HttpResponseMessage> requestFunc() => await _httpClient.GetAsync(uriBuilder.Uri);
        return await CreateRequest(requestFunc);
    }

    public async Task<BaseResponse> Delete(string route, params (string, string)[] requestParams)
    {
        var uriBuilder = CreateUri(route, requestParams);
        async Task<HttpResponseMessage> requestFunc() => await _httpClient.GetAsync(uriBuilder.Uri);
        return await CreateRequest(requestFunc);
    }

    public async Task<BaseResponse> Post<R>(string route, R jsonRequest, params (string, string)[] requestParams)
    {
        var uriBuilder = CreateUri(route, requestParams);
        string jsonRequestString = JsonSerializer.Serialize(jsonRequest);
        async Task<HttpResponseMessage> requestFunc() => await _httpClient.PostAsync(uriBuilder.Uri, new StringContent(jsonRequestString, Encoding.UTF8, "application/json"));
        return await CreateRequest(requestFunc);
    }

    public async Task<BaseResponse> Put<R>(string route, R jsonRequest, params (string, string)[] requestParams)
    {
        var uriBuilder = CreateUri(route, requestParams);
        string jsonRequestString = JsonSerializer.Serialize(jsonRequest);
        async Task<HttpResponseMessage> requestFunc() => await _httpClient.PutAsync(uriBuilder.Uri, new StringContent(jsonRequestString, Encoding.UTF8, "application/json"));
        return await CreateRequest(requestFunc);
    }
}
