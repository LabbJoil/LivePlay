
using LivePlay.Front.Core.Enums;
using System.Text.Json.Serialization;

namespace LivePlay.Front.Infrastructure.Contracts.Responses;

//TODO: Устаревший
public class QuestResponse()
{
    [JsonPropertyName("id")]
    public int Id { get; set; }
    [JsonPropertyName("title")]
    public string Title { get; set; } = string.Empty;
    [JsonPropertyName("descriptionMini")]
    public string DescriptionMini { get; set; } = string.Empty;
    [JsonPropertyName("descriptionFull")]
    public string DescriptionFull { get; set; } = string.Empty;
    [JsonPropertyName("image")]
    public byte[] Image { get; set; } = [];

    public TypeQuest Type { get; set; }
    public QuestStatus Status { get; set; }

    [JsonPropertyName("finalDate")]
    public DateTime FinalDate { get; set; } = DateTime.Now;
    public string FinalDateView { get => FinalDate.ToString("dd.MM.yyyy"); }
    public int Reward { get; set; }
}
