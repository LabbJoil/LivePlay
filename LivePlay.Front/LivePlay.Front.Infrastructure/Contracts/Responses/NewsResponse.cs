
using System.Text.Json.Serialization;

namespace LivePlay.Front.Infrastructure.Contracts.Responses;

public class NewsResponse
{
    [JsonPropertyName("id")]
    public int Id { get; set; }
    [JsonPropertyName("name")]
    public string Name { get; set; } = string.Empty;
    [JsonPropertyName("description")]
    public string Description { get; set; } = string.Empty;
    [JsonPropertyName("text")]
    public string Text { get; set; } = string.Empty;
    [JsonPropertyName("image")]
    public byte[] Image { get; set; } = [];
}
