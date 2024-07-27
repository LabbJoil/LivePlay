
using System.Text.Json.Serialization;

namespace LivePlay.Front.Infrastructure.Models.ResponseModel;

public class ErrorResponse
{
    [JsonPropertyName("errorCode")]
    public required string ErrorCode { get; set; }
    [JsonPropertyName("message")]
    public required string Message { get; set; }
}
