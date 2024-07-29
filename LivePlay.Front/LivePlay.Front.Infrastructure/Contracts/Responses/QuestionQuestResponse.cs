
using System.Text.Json.Serialization;

namespace LivePlay.Front.Infrastructure.Contracts.Responses;

public class QuestionQuestResponse
{
    [JsonPropertyName("id")]
    public int Id { get; set; }
    [JsonPropertyName("question")]
    public string Question { get; set; } = string.Empty;
    [JsonPropertyName("firstAnswer")]
    public string FirstAnswer { get; set; } = string.Empty;
    [JsonPropertyName("secondAnswer")]
    public string SecondAnswer { get; set; } = string.Empty;
    [JsonPropertyName("thirdAnswer")]
    public string ThirdAnswer { get; set; } = string.Empty;
    [JsonPropertyName("fourthAnswer")]
    public string FourthAnswer { get; set; } = string.Empty;
    [JsonPropertyName("rightAnswer")]
    public int RightAnswer { get; set; }
    [JsonPropertyName("image")]
    public byte[] Image { get; set; } = [];
}
