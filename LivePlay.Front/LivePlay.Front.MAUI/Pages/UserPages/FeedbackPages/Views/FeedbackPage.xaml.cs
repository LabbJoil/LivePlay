
using LivePlay.Front.Core.Enums;
using LivePlay.Front.MAUI.DeviceSettings;
using LivePlay.Front.MAUI.Pages.UserPages.FeedbackPages.ViewModels;

namespace LivePlay.Front.MAUI.Pages.UserPages.FeedbackPages.Views;

public partial class FeedbackPage : ContentPage
{
	private readonly FeedbackViewModel ReviewVM;

    public FeedbackPage(FeedbackViewModel reviewViewModel)
	{
		InitializeComponent();
        BindingContext = reviewViewModel;
        ReviewVM = reviewViewModel;
    }

    private void ContentPage_Appearing(object sender, EventArgs e)
    {
        ReviewVM.ChangeColorBars(MainGrid.BackgroundColor, StatusBarColor.BarWhite, null);
    }

    private void ContentPage_Disappearing(object sender, EventArgs e)
    {
        var mgc = MainGrid.BackgroundColor;
        ReviewVM.ChangeColorBars(new Color(mgc.Red, mgc.Green, mgc.Blue, (float)0.5), StatusBarColor.BarWhite, null);
    }
}