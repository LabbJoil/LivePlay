
using LivePlay.Front.Infrastructure.Contracts.Base.QuestContracts;

namespace LivePlay.Front.Infrastructure.Contracts.Requests.QuestRequests.Edit;

public class EditingQuestionQuestRequest
{
    public required QuestContract BaseQuest { get; set; }
    public required QuestionQuestContract[] Questions { get; set; }
}
