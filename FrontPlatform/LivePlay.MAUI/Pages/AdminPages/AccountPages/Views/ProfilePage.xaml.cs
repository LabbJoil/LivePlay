
using LivePlay.Front.MAUI.Pages.AccountPages.Views;

namespace LivePlay.Front.MAUI.Pages.AdminPages.AccountPages.Views;

public partial class ProfilePage : ContentPage
{
	//private readonly ProfileViewModel ProfileVM;
    public ProfilePage(/*ProfileViewModel profileViewModel*/)
	{
		InitializeComponent();
        //BindingContext = profileViewModel;
        //ProfileVM = profileViewModel;
    }

    private void Button_Clicked(object sender, EventArgs e)
    {
        Shell.Current.GoToAsync($"//{nameof(EnterPage)}");
    }

    //private void ContentPage_Appearing(object sender, EventArgs e)
    //{
    //    ProfileVM.ChangeColorBars(MainGrid.BackgroundColor, StatusBarColor.BarWhite, null);
    //    DeviceDesignSettings.OpacityAnimation(this, ShadowRectangle, 20, 500, 0);
    //    //await QuestTapePageVM.GetQuestItems();    //получение новых данных
    //}

    //private void ContentPage_Disappearing(object sender, EventArgs e)
    //{
    //    var mgc = MainGrid.BackgroundColor;
    //    ProfileVM.ChangeColorBars(new Color(mgc.Red, mgc.Green, mgc.Blue, (float)0.5), StatusBarColor.BarWhite, null);
    //    DeviceDesignSettings.OpacityAnimation(this, ShadowRectangle, 20, 500, 0.5);
    //}
}