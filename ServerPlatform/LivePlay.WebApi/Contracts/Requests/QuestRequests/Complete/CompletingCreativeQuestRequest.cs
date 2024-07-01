
using LivePlay.Server.WebApi.Contracts.Base.Quest;

namespace LivePlay.Server.WebApi.Contracts.Requests.Quests.Complete;

public class CompletingCreativeQuestRequest
{
    public int QuestId { get; set; }
    public required CreativeQuestContract PictureInfo { get; set; }
}
