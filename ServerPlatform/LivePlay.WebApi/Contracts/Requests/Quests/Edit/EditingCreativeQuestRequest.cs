
using LivePlay.Server.WebApi.Contracts.Base.Quest;

namespace LivePlay.Server.WebApi.Contracts.Requests.Quest.Edit;

public class EditingCreativeQuestRequest
{
    public required QuestContract BaseQuest { get; set; }
}
