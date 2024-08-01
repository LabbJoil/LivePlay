
using LivePlay.Front.Core.Enums;
using LivePlay.Front.Core.Models;
using LivePlay.Front.MAUI.ViewModels.NewsViewModels;

namespace LivePlay.Front.MAUI.Pages.UserPages.NewsPages.Views;

[QueryProperty(nameof(NewsItemProperty), nameof(NewsItemProperty))]
public partial class CurrentNewsPage : ContentPage
{
    public News NewsItemProperty
    {
        set => CurentNewsVM.CurrentNewsItem = value;
    }
    private readonly CurrentNewsPageViewModel CurentNewsVM;

    public CurrentNewsPage(CurrentNewsPageViewModel curentNewsPageVM)
    {
		InitializeComponent();
		BindingContext = curentNewsPageVM;
        CurentNewsVM = curentNewsPageVM;
    }

    private void ContentPage_Appearing(object sender, EventArgs e)
    {
        CurentNewsVM.ChangeColorBars(BackgroundColor, barReplay: true);
    }
}