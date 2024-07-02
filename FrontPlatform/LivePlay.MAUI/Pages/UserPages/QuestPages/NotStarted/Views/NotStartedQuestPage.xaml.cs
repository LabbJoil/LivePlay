
using LivePlay.Front.Core.Models;
using LivePlay.Front.MAUI.Abstracts;
using LivePlay.Front.MAUI.Pages.UserPages.QuestPages.InProgress.Views;
using LivePlay.Front.MAUI.Pages.UserPages.QuestPages.NotStarted.ViewModels;

namespace LivePlay.Front.MAUI.Pages.UserPages.QuestPages.NotStarted.Views;

[QueryProperty(nameof(QuestProperty), nameof(QuestProperty))]
public partial class NotStartedQuestPage : ContentPage
{
    private readonly NotStartedQuestViewModel _baseQuestPVM;

    public Quest QuestProperty
    {
        set => _baseQuestPVM.CurrentQuestItem = value;
    }

    public NotStartedQuestPage(NotStartedQuestViewModel baseQuestPVM)
	{
        InitializeComponent();
		BindingContext = baseQuestPVM;
        _baseQuestPVM = baseQuestPVM;
        //baseQuestPVM.CurrentQuestItem = questionQuestModel;
        //Settings.ChangeColorStatusBars?.Invoke(MainScrollView.BackgroundColor, StatusBarColor.BarWhite, null);
    }

    private async void ClosePopup(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync($"..");
    }

    private async void Button_Clicked(object sender, EventArgs e)
    {
        var shellParameters = new ShellNavigationQueryParameters { { $"{nameof(Quest)}Property", _baseQuestPVM.CurrentQuestItem } };
        await Shell.Current.GoToAsync($"{nameof(InProgressQuestionQuestPage)}", shellParameters);
    }
}