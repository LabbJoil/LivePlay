
using LivePlay.Server.WebApi.Contracts.Requests.QuestRequests.Add;

namespace LivePlay.Server.WebApi.Contracts.Requests.QuestRequests.Add;

public class AddingCreativeQuestRequest
{
    public required AddingQuestContract BaseQuest { get; set; }
}
