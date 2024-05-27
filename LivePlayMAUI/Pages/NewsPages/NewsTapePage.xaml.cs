
using LivePlayMAUI.Models.Domain;
using LivePlayMAUI.Models.Enum;
using LivePlayMAUI.Models.ViewModels;
using LivePlayMAUI.Services;

namespace LivePlayMAUI.Pages;

public partial class NewsTapePage : ContentPage
{
    private readonly NewsTapePageViewModel NewsTapeVM;

    public NewsTapePage(NewsTapePageViewModel newsTapeViewModel)
	{
		InitializeComponent();
        BindingContext = newsTapeViewModel;
        NewsTapeVM = newsTapeViewModel;
    }

    private void ContentPage_Disappearing(object sender, EventArgs e)
    {
        NewsTapeVM.ChangeColorBars(MainGrid.BackgroundColor, StatusBarColor.BarWhite);
    }

    private void ContentPage_Appearing(object sender, EventArgs e)
    {
        NewsTapeVM.ChangeColorBars(MainGrid.BackgroundColor, StatusBarColor.BarWhite);
    }
}