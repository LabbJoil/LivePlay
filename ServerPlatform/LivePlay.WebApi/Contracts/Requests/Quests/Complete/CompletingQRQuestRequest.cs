
namespace LivePlay.Server.WebApi.Contracts.Requests.Quests.Complete;

public class CompletingQRQuestRequest
{
    public required int QuestId { get; set; }
    public required string QRData { get; set; }
}
