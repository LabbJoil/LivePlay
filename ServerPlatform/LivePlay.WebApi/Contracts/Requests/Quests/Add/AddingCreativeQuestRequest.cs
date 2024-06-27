
using LivePlay.Server.WebApi.Contracts.Requests.Quest.Add;

namespace LivePlay.Server.WebApi.Contracts.Requests.Quests.Add;

public class AddingCreativeQuestRequest
{
    public required AddingQuestContract BaseQuest { get; set; }
}
