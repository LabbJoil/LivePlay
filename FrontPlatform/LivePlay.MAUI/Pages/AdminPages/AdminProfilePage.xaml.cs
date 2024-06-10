
using LivePlayMAUI.Enum;
using LivePlayMAUI.Models.ViewModels.AccountViewModels;
using LivePlayMAUI.Services;

namespace LivePlayMAUI.Pages.AdminPages;

public partial class AdminProfilePage : ContentPage
{
	//private readonly ProfileViewModel ProfileVM;
    public AdminProfilePage(/*ProfileViewModel profileViewModel*/)
	{
		InitializeComponent();
        //BindingContext = profileViewModel;
        //ProfileVM = profileViewModel;
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