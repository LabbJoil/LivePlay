using LivePlayMAUI.Models.Domain;
using LivePlayMAUI.Models.Enum;
using LivePlayMAUI.Models.ViewModels;
using LivePlayMAUI.Services;
using MauiPopup.Views;

namespace LivePlayMAUI.Pages;

public partial class NotStartedQuestPage : BasePopupPage
{
	public NotStartedQuestPage(BaseQuestPageViewModel notStartedQuestPVM)
	{
		InitializeComponent();
		BindingContext = notStartedQuestPVM;
        //Settings.ChangeColorStatusBars?.Invoke(MainScrollView.BackgroundColor, StatusBarColor.BarWhite, null);
    }
}