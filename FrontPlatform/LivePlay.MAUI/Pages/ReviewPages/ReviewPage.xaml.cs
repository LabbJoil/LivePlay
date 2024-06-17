
using LivePlay.Front.MAUI.DeviceSettings;
using LivePlay.Front.Core.Enums;
using LivePlay.Front.MAUI.ViewModels.ReviewViewModels;

namespace LivePlay.Front.MAUI.Pages.ReviewPages;

public partial class ReviewPage : ContentPage
{
	private readonly ReviewPageViewModel ReviewVM;

    public ReviewPage(ReviewPageViewModel reviewViewModel)
	{
		InitializeComponent();
        BindingContext = reviewViewModel;
        ReviewVM = reviewViewModel;
    }

    private void ContentPage_Appearing(object sender, EventArgs e)
    {
        ReviewVM.ChangeColorBars(MainGrid.BackgroundColor, StatusBarColor.BarWhite, null);
        AppDesign.OpacityAnimation(this, ShadowRectangle, 20, 500, 0);
        //await QuestTapePageVM.GetQuestItems();    //получение новых данных
    }

    private void ContentPage_Disappearing(object sender, EventArgs e)
    {
        var mgc = MainGrid.BackgroundColor;
        ReviewVM.ChangeColorBars(new Color(mgc.Red, mgc.Green, mgc.Blue, (float)0.5), StatusBarColor.BarWhite, null);
        AppDesign.OpacityAnimation(this, ShadowRectangle, 20, 500, 0.5);
    }
}