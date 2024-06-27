
using LivePlay.Server.WebApi.Contracts.Base.Quest;

namespace LivePlay.Server.WebApi.Contracts.Requests.Quest.Edit;

public class EditingQRQuestRequest
{
    public required QuestContract BaseQuest { get; set; }
    public required QRQuestContract QrQuest { get; set; }
}
