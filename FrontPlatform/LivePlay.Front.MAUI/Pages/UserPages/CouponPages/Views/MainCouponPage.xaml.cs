
using LivePlay.Front.MAUI.Pages.UserPages.CouponPages.ViewModels;

namespace LivePlay.Front.MAUI.Pages.UserPages.CouponPages.Views;

public partial class MainCouponPage : ContentPage
{
    public MainCouponPage(MainRewardViewModel mainRewardPageViewModel)
	{
		InitializeComponent();
        BindingContext = mainRewardPageViewModel;
        CoinsLabel.Text = mainRewardPageViewModel.DesignSettings.GetCountCoins().ToString();
    }

    //private void ContentPage_Disappearing(object sender, EventArgs e)
    //{
    //    MainVM.ChangeColorBars(MainGrid.BackgroundColor, StatusBarColor.BarWhite);
    //}

    //private void ContentPage_Appearing(object sender, EventArgs e)
    //{
    //    MainVM.ChangeColorBars(MainGrid.BackgroundColor, StatusBarColor.BarWhite);
    //}
}