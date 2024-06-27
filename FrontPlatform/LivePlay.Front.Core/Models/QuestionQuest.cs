
namespace LivePlay.Front.Core.Models;

public class QuestionQuest
{
    public string Question { get; set; } = string.Empty;
    public string Answer1 { get; set; } = string.Empty;
    public string Answer2 { get; set; } = string.Empty;
    public string Answer3 { get; set; } = string.Empty;
    public string Answer4 { get; set; } = string.Empty;
    public int RightAnswer { get; set; }
    public byte[] Image { get; set; } = [];
}
