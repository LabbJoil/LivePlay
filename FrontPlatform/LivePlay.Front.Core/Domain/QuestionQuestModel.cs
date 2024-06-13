
namespace LivePlay.Front.Core.Models.Domain;

public class QuestionQuestModel
{
    public QuestItem NowItem { get; set; }
    public string Question { get; set; }
    public string Answer1 { get; set; }
    public string Answer2 { get; set; }
    public string Answer3 { get; set; }
    public string Answer4 { get; set; }
    public int RightAnswer { get; set; }
    public string ImagePath { get; set; }
}
