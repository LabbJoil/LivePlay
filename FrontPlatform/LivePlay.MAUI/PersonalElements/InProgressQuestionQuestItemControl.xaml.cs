using LivePlay.Front.Core.Models.QuestModels;

namespace LivePlay.Front.MAUI.PersonalElements;

public partial class InProgressQuestionQuestItem : ContentView
{
    public static readonly BindableProperty NowQuestionQuestProperty = BindableProperty.Create(
       propertyName: nameof(NowQuestionQuest),
       returnType: typeof(QuestionQuest),
       declaringType: typeof(QuestionQuestItemControl),
       defaultValue: null,
       defaultBindingMode: BindingMode.TwoWay);

    public QuestionQuest NowQuestionQuest
    {
        get => (QuestionQuest)GetValue(NowQuestionQuestProperty);
        set
        {
            SetValue(NowQuestionQuestProperty, value);
            NowQuestionQuest.RightAnswer = value.RightAnswer;
            ChangeColorButton(value.RightAnswer + 1);
        }
    }

    private Button? ChooseButton;
    private readonly Color ChooseColor = Color.FromRgb(34, 59, 86);
    private readonly Button[] ButtonAnswers;

    public InProgressQuestionQuestItem()
	{
		InitializeComponent();
        ButtonAnswers = [Answer1, Answer2, Answer3, Answer4];
    }

    private void Answer_1_Clicked(object sender, EventArgs e)
        => ChangeColorButton(0);

    private void Answer_2_Clicked(object sender, EventArgs e)
        => ChangeColorButton(1);

    private void Answer_3_Clicked(object sender, EventArgs e)
        => ChangeColorButton(2);

    private void Answer_4_Clicked(object sender, EventArgs e)
        => ChangeColorButton(3);

    private void ChangeColorButton(int numberAnswer)
    {
        if (numberAnswer == NowQuestionQuest.RightAnswer || numberAnswer < 0 || numberAnswer > 3)
            return;
        if (ChooseButton != null)
            ChooseButton.Background = ButtonAnswers[numberAnswer].Background;
        ButtonAnswers[numberAnswer].Background = ChooseColor;
        NowQuestionQuest.RightAnswer = numberAnswer+1;
        ChooseButton = ButtonAnswers[numberAnswer];
    }
}