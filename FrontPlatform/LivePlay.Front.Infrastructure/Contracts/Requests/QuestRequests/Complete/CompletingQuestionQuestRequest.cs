
namespace LivePlay.Front.Infrastructure.Contracts.Requests.QuestRequests.Complete;

public class CompletingQuestionQuestRequest
{
    public required int QuestId { get; set; }
    public required Dictionary<int, int> AnswerQuestions { get; set; }
}
