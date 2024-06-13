
using LivePlay.Front.MAUI.Enum;
using LivePlay.Front.MAUI.Models.ViewModels.NewsViewModels;

namespace LivePlay.Front.MAUI.Pages;

public partial class MainPage : ContentPage
{
    private readonly MainViewModel MainVM;

    public MainPage(MainViewModel mainViewModel)
	{
		InitializeComponent();
        BindingContext = mainViewModel;
        MainVM = mainViewModel;
    }

    private void ContentPage_Disappearing(object sender, EventArgs e)
    {
        MainVM.ChangeColorBars(MainGrid.BackgroundColor, StatusBarColor.BarWhite);
    }

    private void ContentPage_Appearing(object sender, EventArgs e)
    {
        MainVM.ChangeColorBars(MainGrid.BackgroundColor, StatusBarColor.BarWhite);
    }
}