using LivePlayMAUI.Models.Domain;
using LivePlayMAUI.Models.Enum;
using LivePlayMAUI.Services;
using MauiPopup.Views;

namespace LivePlayMAUI.Pages;

public partial class CurrentNewsPage : BasePopupPage
{
	public CurrentNewsPage(NewsItem questItem)
	{
		InitializeComponent();
		BindingContext = questItem;
        //AppSettings.ChangeColorStatusBars?.Invoke(BackgroundColor, StatusBarColor.BarReplay, null);
    }
}