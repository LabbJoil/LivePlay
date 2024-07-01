
using LivePlay.Server.WebApi.Contracts.Base.QuestContracts;

namespace LivePlay.Server.WebApi.Contracts.Requests.QuestRequests.Edit;

public class EditingQRQuestRequest
{
    public required QuestContract BaseQuest { get; set; }
    public required QRQuestContract QrQuest { get; set; }
}
