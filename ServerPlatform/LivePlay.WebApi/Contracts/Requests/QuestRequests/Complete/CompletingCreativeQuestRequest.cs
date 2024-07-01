
using LivePlay.Server.WebApi.Contracts.Base.QuestContracts;

namespace LivePlay.Server.WebApi.Contracts.Requests.QuestRequests.Complete;

public class CompletingCreativeQuestRequest
{
    public int QuestId { get; set; }
    public required CreativeQuestContract PictureInfo { get; set; }
}
