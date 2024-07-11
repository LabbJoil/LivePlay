
namespace LivePlay.Front.Core.Models.QuestModels;

public class QuestionQuest
{
    public int Id { get; set; }
    public string Question { get; set; } = string.Empty;
    public string FirstAnswer { get; set; } = string.Empty;
    public string SecondAnswer { get; set; } = string.Empty;
    public string ThirdAnswer { get; set; } = string.Empty;
    public string FourthAnswer { get; set; } = string.Empty;
    public int RightAnswer { get; set; }
    public byte[] Image { get; set; } = [];
}
