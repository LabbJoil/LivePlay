
using LivePlayMAUI.Enum;
using LivePlayMAUI.Models.ViewModels.NewsViewModels;

namespace LivePlayMAUI.Pages;

public partial class TapeNewsPage : ContentPage
{
    private readonly TapeNewsViewModel NewsTapeVM;

    public TapeNewsPage(TapeNewsViewModel newsTapeViewModel)
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