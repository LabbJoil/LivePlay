
namespace LivePlay.Front.Core.Models;

public class QuestionQuestModel
{
    public QuestItem NowItem { get; set; } = new ();
    public string Question { get; set; } = string.Empty;
    public string Answer1 { get; set; } = string.Empty;
    public string Answer2 { get; set; } = string.Empty;
    public string Answer3 { get; set; } = string.Empty;
    public string Answer4 { get; set; } = string.Empty;
    public int RightAnswer { get; set; }
    public string ImagePath { get; set; } = string.Empty;

    public QuestionQuestModel() { }

    public QuestionQuestModel(QuestionQuestModel questionQuestModel)
    {
        NowItem = questionQuestModel.NowItem;
        Question = questionQuestModel.Question;
        Answer1 = questionQuestModel.Answer1;
        Answer2 = questionQuestModel.Answer2;
        Answer3 = questionQuestModel.Answer3;
        Answer4 = questionQuestModel.Answer4;
        RightAnswer = questionQuestModel.RightAnswer;
        ImagePath = questionQuestModel.ImagePath;
    }
}
