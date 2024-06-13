
using LivePlay.Front.MAUI.Enum;
using LivePlay.Front.MAUI.Services;
using LivePlay.Front.MAUI.ViewModels.AccountViewModels;

namespace LivePlay.Front.MAUI.Pages;

public partial class MyCouponsPage : ContentPage
{
	private readonly ProfileViewModel ProfileVM;
    public MyCouponsPage(ProfileViewModel profileViewModel)
	{
		InitializeComponent();
        BindingContext = profileViewModel;
        ProfileVM = profileViewModel;
    }

    private void ContentPage_Appearing(object sender, EventArgs e)
    {
        //    ProfileVM.ChangeColorBars(MainGrid.BackgroundColor, StatusBarColor.BarWhite, null);
        //    DeviceDesignSettings.OpacityAnimation(this, ShadowRectangle, 20, 500, 0);
        //await QuestTapePageVM.GetQuestItems();    //получение новых данных
    }

    private void ContentPage_Disappearing(object sender, EventArgs e)
    {
        //var mgc = MainGrid.BackgroundColor;
        //ProfileVM.ChangeColorBars(new Color(mgc.Red, mgc.Green, mgc.Blue, (float)0.5), StatusBarColor.BarWhite, null);
        //DeviceDesignSettings.OpacityAnimation(this, ShadowRectangle, 20, 500, 0.5);
    }
}