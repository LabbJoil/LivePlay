
namespace LivePlay.Server.WebApi.Contracts.Base.QuestContracts;

public class QuestionQuestContract
{
    public int Id { get; set; }
    public required string Question { get; set; }
    public required string FirstAnswer { get; set; }
    public required string SecondAnswer { get; set; }
    public required string ThirdAnswer { get; set; }
    public required string FourthAnswer { get; set; }
    public required int RightAnswer { get; set; }
}
