using LivePlayMAUI.Models.Domain;
using LivePlayMAUI.Models.Enum;
using LivePlayMAUI.Services;
using MauiPopup.Views;
using LivePlayMAUI.Models.ViewModels;

namespace LivePlayMAUI.Pages;

public partial class CurrentNewsPage : ContentPage
{
	public CurrentNewsPage(CurrentNewsPageViewModel curentNewsPageViewModel)
    {
		InitializeComponent();
		BindingContext = curentNewsPageViewModel;
        curentNewsPageViewModel.ChangeColorBars(BackgroundColor, StatusBarColor.BarReplay, null);
    }
}