
using LivePlay.Front.Infrastructure.Contracts.Base.QuestContracts;

namespace LivePlay.Front.Infrastructure.Contracts.Requests.QuestRequests.Edit;

public class EditingQRQuestRequest
{
    public required QuestContract BaseQuest { get; set; }
    public required QRQuestContract QrQuest { get; set; }
}
