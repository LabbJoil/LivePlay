
using LivePlay.Front.Core.Models;
using LivePlay.Front.MAUI.ViewModels.QuestViewModels;

namespace LivePlay.Front.MAUI.Pages;

[QueryProperty(nameof(QuestionQuestModelProperty), nameof(QuestionQuestModelProperty))]
public partial class NotStartedQuestPage : ContentPage
{
    private readonly BaseQuestPageViewModel BaseQuestPVM;
    public QuestionQuestModel QuestionQuestModelProperty
    {
        set => BaseQuestPVM.CurrentQuestItem = value;
    }

    public NotStartedQuestPage(BaseQuestPageViewModel baseQuestPVM)
	{
        InitializeComponent();
		BindingContext = baseQuestPVM;
        BaseQuestPVM = baseQuestPVM;
        //baseQuestPVM.CurrentQuestItem = questionQuestModel;
        //Settings.ChangeColorStatusBars?.Invoke(MainScrollView.BackgroundColor, StatusBarColor.BarWhite, null);
    }

    private async void ClosePopup(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync($"..");
    }

    private async void Button_Clicked(object sender, EventArgs e)
    {
        var shellParameters = new ShellNavigationQueryParameters { { $"{nameof(QuestionQuestModel)}Property", BaseQuestPVM.CurrentQuestItem } };
        await Shell.Current.GoToAsync($"{nameof(InProgressQuizQuestPage)}", shellParameters);
    }
}