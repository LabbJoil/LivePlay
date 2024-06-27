
using LivePlay.Server.WebApi.Contracts.Base.Quest;

namespace LivePlay.Server.WebApi.Contracts.Requests.Quest.Edit;

public class EditingQuestionQuestRequest
{
    public required QuestContract BaseQuest { get; set; }
    public required QuestionQuestContract[] Questions { get; set; }
}
