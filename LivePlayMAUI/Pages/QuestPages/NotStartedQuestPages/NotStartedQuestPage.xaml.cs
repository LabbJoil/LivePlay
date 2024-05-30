
using LivePlayMAUI.Models.Domain;
using LivePlayMAUI.Models.ViewModels;
using MauiPopup.Views;

namespace LivePlayMAUI.Pages;


[QueryProperty(nameof(QuestItemProperty), nameof(QuestItemProperty))]
public partial class NotStartedQuestPage : BasePopupPage
{
    public QuestItem QuestItemProperty
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
}