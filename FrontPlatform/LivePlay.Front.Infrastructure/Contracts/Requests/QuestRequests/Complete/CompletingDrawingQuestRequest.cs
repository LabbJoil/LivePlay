namespace LivePlay.Front.Infrastructure.Contracts.Requests.QuestRequests.Complete;

public class CompletingDrawingQuestRequest
{
    public required int QuestId { get; set; }
    public byte[] PictureInfo { get; set; } = [];
}
