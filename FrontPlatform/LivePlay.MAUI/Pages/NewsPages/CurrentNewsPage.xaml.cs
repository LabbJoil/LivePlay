
using LivePlay.Front.Core.Enums;
using LivePlay.Front.Core.Models.Domain;
using LivePlay.Front.MAUI.ViewModels.NewsViewModels;

namespace LivePlay.Front.MAUI.Pages;

[QueryProperty(nameof(NewsItemProperty), nameof(NewsItemProperty))]
public partial class CurrentNewsPage : ContentPage
{
    public NewsItem NewsItemProperty
    {
        set => CurentNewsVM.CurrentNewsItem = value;
    }
    private readonly CurrentNewsViewModel CurentNewsVM;

    public CurrentNewsPage(CurrentNewsViewModel curentNewsPageVM)
    {
		InitializeComponent();
		BindingContext = curentNewsPageVM;
        CurentNewsVM = curentNewsPageVM;
    }

    private void ContentPage_Appearing(object sender, EventArgs e)
    {
        CurentNewsVM.ChangeColorBars(BackgroundColor, StatusBarColor.BarReplay, null);
    }
}