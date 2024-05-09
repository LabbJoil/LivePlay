using LivePlayMAUI.Models.Domain;
using LivePlayMAUI.Models.Enum;
using LivePlayMAUI.Services;
using MauiPopup.Views;

namespace LivePlayMAUI.Pages;

public partial class CurrentQuestPage : BasePopupPage
{
	public CurrentQuestPage(QuestItem questItem)
	{
		InitializeComponent();
		BindingContext = questItem;
        //Settings.ChangeColorStatusBars?.Invoke(MainScrollView.BackgroundColor, StatusBarColor.BarWhite, null);
    }
}