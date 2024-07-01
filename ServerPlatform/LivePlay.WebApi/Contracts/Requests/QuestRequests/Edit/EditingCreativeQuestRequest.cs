
using LivePlay.Server.WebApi.Contracts.Base.QuestContracts;

namespace LivePlay.Server.WebApi.Contracts.Requests.QuestRequests.Edit;

public class EditingCreativeQuestRequest
{
    public required QuestContract BaseQuest { get; set; }
}
