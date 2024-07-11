
using System.Text.Json.Serialization;

namespace LivePlay.Front.Infrastructure.Contracts.Responses;

public class LoginResponse
{
    [JsonPropertyName("token")]
    public string Token { get; set; } = string.Empty;
    [JsonPropertyName("roles")]
    public string[] Roles { get; set; } = [];
}
