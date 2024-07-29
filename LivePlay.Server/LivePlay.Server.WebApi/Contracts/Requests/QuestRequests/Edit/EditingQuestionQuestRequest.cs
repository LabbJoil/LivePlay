
using LivePlay.Server.WebApi.Contracts.Base.QuestContracts;

namespace LivePlay.Server.WebApi.Contracts.Requests.QuestRequests.Edit;

public class EditingQuestionQuestRequest
{
    public required QuestContract BaseQuest { get; set; }
    public required QuestionQuestContract[] Questions { get; set; }
}
