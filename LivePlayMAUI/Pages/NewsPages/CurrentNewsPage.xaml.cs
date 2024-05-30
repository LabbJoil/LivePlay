
using LivePlayMAUI.Enum;
using LivePlayMAUI.Models.Domain;
using LivePlayMAUI.Models.ViewModels.NewsViewModels;

namespace LivePlayMAUI.Pages;

[QueryProperty(nameof(NewsItemProperty), nameof(NewsItemProperty))]
public partial class CurrentNewsPage : ContentPage
{
    public NewsItem NewsItemProperty
    {
        set => CurentNewsPageVM.CurrentNewsItem = value;
    }
    private readonly CurrentNewsViewModel CurentNewsPageVM;

    public CurrentNewsPage(CurrentNewsViewModel curentNewsPageVM)
    {
		InitializeComponent();
		BindingContext = curentNewsPageVM;
        CurentNewsPageVM = curentNewsPageVM;
    }

    private void ContentPage_Appearing(object sender, EventArgs e)
    {
        CurentNewsPageVM.ChangeColorBars(BackgroundColor, StatusBarColor.BarReplay, null);
    }
}