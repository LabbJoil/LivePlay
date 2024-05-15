
using LivePlayMAUI.Models.Domain;
using LivePlayMAUI.Models.Enum;
using LivePlayMAUI.Models.ViewModels;
using LivePlayMAUI.Services;

namespace LivePlayMAUI.Pages;

public partial class NewsTapePage : ContentPage
{
	public NewsTapePage()
	{
		InitializeComponent();
        BindingContext = new NewsTapeViewModel();
    }

    private void ContentPage_Disappearing(object sender, EventArgs e)
    {
        AppSettings.ChangeColorStatusBars?.Invoke(MainGrid.BackgroundColor, StatusBarColor.BarWhite, null);
    }

    private void ContentPage_Appearing(object sender, EventArgs e)
    {
        AppSettings.ChangeColorStatusBars?.Invoke(MainGrid.BackgroundColor, StatusBarColor.BarWhite, null);
    }
}