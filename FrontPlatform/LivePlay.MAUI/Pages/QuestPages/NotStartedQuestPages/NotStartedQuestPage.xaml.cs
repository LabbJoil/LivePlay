
using LivePlay.Front.Core.Models;
using LivePlay.Front.MAUI.ViewModels.QuestViewModels;
using MauiPopup.Views;

namespace LivePlay.Front.MAUI.Pages;


//[QueryProperty(nameof(QuestionQuestModelProperty), nameof(QuestionQuestModelProperty))]
public partial class NotStartedQuestPage : BasePopupPage
{
    private readonly BaseQuestViewModel BaseQuestVM;
    public QuestionQuestModel QuestionQuestModelProperty
    {
        set => BaseQuestVM.CurrentQuestItem = value;
    }

    public NotStartedQuestPage(BaseQuestViewModel baseQuestVM, QuestionQuestModel questionQuestModel)
	{
        Shell.Current.DisplayAlert("111", "111", "ok");
        InitializeComponent();
		BindingContext = baseQuestVM;
        BaseQuestVM = baseQuestVM;
        baseQuestVM.CurrentQuestItem = questionQuestModel;
        //Settings.ChangeColorStatusBars?.Invoke(MainScrollView.BackgroundColor, StatusBarColor.BarWhite, null);
    }

    private async void Button_Clicked(object sender, EventArgs e)
    {
        var shellParameters = new ShellNavigationQueryParameters { { $"{nameof(QuestionQuestModel)}Property", BaseQuestVM.CurrentQuestItem } };
        await Shell.Current.GoToAsync($"{nameof(InProgressQuizQuestPage)}", shellParameters);
    }
}