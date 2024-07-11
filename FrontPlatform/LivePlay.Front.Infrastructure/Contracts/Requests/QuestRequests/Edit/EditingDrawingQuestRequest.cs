
using LivePlay.Front.Infrastructure.Contracts.Base.QuestContracts;

namespace LivePlay.Front.Infrastructure.Contracts.Requests.QuestRequests.Edit;

public class EditingDrawingQuestRequest
{
    public required QuestContract BaseQuest { get; set; }
}
