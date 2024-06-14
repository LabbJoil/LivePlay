
using LivePlay.Front.Core.Models;
using LivePlay.Front.MAUI.ViewModels.QuestViewModels;

namespace LivePlay.Front.MAUI.Pages;

[QueryProperty(nameof(QuestionQuestModelProperty), nameof(QuestionQuestModelProperty))]
public partial class InProgressQuizQuestPage : ContentPage
{
    public QuestionQuestModel QuestionQuestModelProperty
    {
        set => BaseQuestVM.CurrentQuestItem = value;
    }
    private readonly BaseQuestPageViewModel BaseQuestVM;

    public InProgressQuizQuestPage(BaseQuestPageViewModel inProgressPhotoVM)
	{
		InitializeComponent();
        BindingContext = inProgressPhotoVM;
        BaseQuestVM = inProgressPhotoVM;
    }

    private void Button_Clicked(object sender, EventArgs e)
    {
        Check(0);
    }

    private void Button_Clicked_1(object sender, EventArgs e)
    {
        Check(1);
    }

    private void Button_Clicked_2(object sender, EventArgs e)
    {
        Check(2);
    }

    private void Button_Clicked_3(object sender, EventArgs e)
    {
        Check(3);
    }

    private async void Check(int i)
    {
        await Task.Delay(600);
        if (i == BaseQuestVM.CurrentQuestItem.RightAnswer)
        {
            await Shell.Current.DisplayAlert("Правильно", "Вы правильно ответили на вопрос", "ok");
        }
    }
}