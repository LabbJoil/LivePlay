
using LivePlayMAUI.Models.Domain;
using LivePlayMAUI.Models.ViewModels;
using MauiPopup.Views;

namespace LivePlayMAUI.Pages;


[QueryProperty(nameof(QuestionQuestModelProperty), nameof(QuestionQuestModelProperty))]
public partial class NotStartedQuestPage : BasePopupPage
{
    public QuestionQuestModel QuestionQuestModelProperty
    {
        set => BaseQuestVM.CurrentQuestItem = value;
    }
    private readonly BaseQuestViewModel BaseQuestVM;

    public NotStartedQuestPage(BaseQuestViewModel baseQuestVM)
	{
		InitializeComponent();
		BindingContext = baseQuestVM;
        BaseQuestVM = baseQuestVM;
        //Settings.ChangeColorStatusBars?.Invoke(MainScrollView.BackgroundColor, StatusBarColor.BarWhite, null);
    }

    private void Button_Clicked(object sender, EventArgs e)
    {

    }
}