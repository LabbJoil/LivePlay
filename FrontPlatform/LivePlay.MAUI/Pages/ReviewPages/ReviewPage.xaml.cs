
using LivePlayMAUI.Enum;
using LivePlayMAUI.Models.ViewModels.ReviewViewModels;
using LivePlayMAUI.Services;

namespace LivePlayMAUI.Pages.ReviewPages;

public partial class ReviewPage : ContentPage
{
	private readonly ReviewViewModel ReviewVM;

    public ReviewPage(ReviewViewModel reviewViewModel)
	{
		InitializeComponent();
        BindingContext = reviewViewModel;
        ReviewVM = reviewViewModel;
    }

    private void ContentPage_Appearing(object sender, EventArgs e)
    {
        ReviewVM.ChangeColorBars(MainGrid.BackgroundColor, StatusBarColor.BarWhite, null);
        DeviceDesignSettings.OpacityAnimation(this, ShadowRectangle, 20, 500, 0);
        //await QuestTapePageVM.GetQuestItems();    //получение новых данных
    }

    private void ContentPage_Disappearing(object sender, EventArgs e)
    {
        var mgc = MainGrid.BackgroundColor;
        ReviewVM.ChangeColorBars(new Color(mgc.Red, mgc.Green, mgc.Blue, (float)0.5), StatusBarColor.BarWhite, null);
        DeviceDesignSettings.OpacityAnimation(this, ShadowRectangle, 20, 500, 0.5);
    }
}