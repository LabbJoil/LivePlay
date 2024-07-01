
namespace LivePlay.Server.WebApi.Contracts.Requests.Quest.Add;

public class AddingQuestionQuestRequest
{
    public required AddingQuestContract BaseQuest { get; set; }
    public required AddingQuestionQuestContract[] Questions { get; set; }
}

public class AddingQuestionQuestContract
{
    public required string Question { get; set; }
    public required string FirstAnswer { get; set; }
    public required string SecondAnswer { get; set; }
    public required string ThirdAnswer { get; set; }
    public required string FourthAnswer { get; set; }
    public required int RightAnswer { get; set; }
}
