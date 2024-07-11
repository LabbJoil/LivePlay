
namespace LivePlay.Front.Infrastructure.Contracts.Requests.QuestRequests.Complete;

public class CompletingQRQuestRequest
{
    public required int QuestId { get; set; }
    public required byte[] QRData { get; set; }
}
