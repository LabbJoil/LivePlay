
using LivePlayMAUI.Models.Enum;
using LivePlayMAUI.Services;

namespace LivePlayMAUI.Pages;

public partial class SettingsPage : ContentPage
{
	public SettingsPage()
	{
		InitializeComponent();
        Settings.ChangeColorStatusBars?.Invoke(TT.BackgroundColor, StatusBarColor.BarWhite, null);
    }
}