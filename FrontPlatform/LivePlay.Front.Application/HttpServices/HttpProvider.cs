
using LivePlay.Front.Application.Models.ResponseModel;
using System.Net;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;

namespace LivePlay.Front.Application.HttpServices;

internal class HttpProvider
{
    protected readonly static HttpClient HttpClient = new(
        new HttpClientHandler()
        {
            ServerCertificateCustomValidationCallback = delegate { return true; }
        })
    {
        Timeout = TimeSpan.FromSeconds(200)
    };

    public string? IP { get; private set; }
    public string? Port { get; private set; }
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

    private async Task<(T?, ErrorResponse?)> CreateRequest<T>(Func<Task<HttpResponseMessage>> requestFunc)
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
                    return (okBody, null);

                case HttpStatusCode.NoContent:
                    return (default, null);

                default:
                    ErrorResponse errorBody = JsonSerializer.Deserialize<ErrorResponse>(responseBody)
                        ?? throw new Exception("Не удалось преобразовать полученный от сервера ответ");
                    return (default, errorBody);
            }
        }
        catch (Exception ex)
        {
            return (default, new ErrorResponse
            {
                ErrorCode = "Not parse body",
                Message = ex.Message,
                Details = ex.Message
            });
        }
    }

    protected async Task<(T?, ErrorResponse?)> GetRequest<T>(string requestURI)
    {
        async Task<HttpResponseMessage> requestFunc() => await HttpClient.GetAsync(requestURI);
        return await CreateRequest<T>(requestFunc);
    }

    protected async Task<(T?, ErrorResponse?)> PostRequest<T, R>(string requestURI, R jsonRequest)
    {
        string jsonRequestString = JsonSerializer.Serialize(jsonRequest);
        async Task<HttpResponseMessage> requestFunc() => await HttpClient.PostAsync(requestURI, new StringContent(jsonRequestString, Encoding.UTF8, "application/json"));
        return await CreateRequest<T>(requestFunc);
    }
}
