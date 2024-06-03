
using LivePlayMAUI.Models.Domain;
using LivePlayMAUI.Models.ViewModels;
using MauiPopup.Views;

namespace LivePlayMAUI.Pages;


//[QueryProperty(nameof(QuestionQuestModelProperty), nameof(QuestionQuestModelProperty))]
public partial class NotStartedQuestPage : BasePopupPage
{
    public QuestionQuestModel QuestionQuestModelProperty
    {
        set => BaseQuestVM.CurrentQuestItem = value;
    }
    private readonly BaseQuestViewModel BaseQuestVM;

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