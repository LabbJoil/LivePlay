
using LivePlay.Front.Core.Enums;
using LivePlay.Front.MAUI.Models.ViewModels.NewsViewModels;

namespace LivePlay.Front.MAUI.Pages.UserPages.MainPages.Views;

public partial class MainPage : ContentPage
{
    private readonly MainViewModel MainVM;

    public MainPage(MainViewModel mainViewModel)
	{
		InitializeComponent();
        BindingContext = mainViewModel;
        MainVM = mainViewModel;

        mappy.Pins.Add(new Microsoft.Maui.Controls.Maps.Pin
        {
            Label = "Palace Bridge Hotel",
            Address = "Биржевой пер., 2-4, Санкт-Петербург",
            Location = new Location(59.9444783, 30.29377298232645),
        });
        mappy.Pins.Add(new Microsoft.Maui.Controls.Maps.Pin
        {
            Label = "Cosmos Olympia Garden Hotel",
            Address = "Батайский пер., 3А, Санкт-Петербург",
            Location = new Location(59.91351201634585, 30.320205688476566),
        }); 
        mappy.Pins.Add(new Microsoft.Maui.Controls.Maps.Pin
        {
            Label = "Vasilievsky Hotel",
            Address = "8-я линия В.О., 11-13, Санкт-Петербург",
            Location = new Location(59.9374408, 30.2822576),
        });
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