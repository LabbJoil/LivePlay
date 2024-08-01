
using LivePlay.Front.MAUI.Pages.EnterPages.Views;
using LivePlay.Front.MAUI.Pages.AdminPages.AccountPages.ViewModels;

namespace LivePlay.Front.MAUI.Pages.AdminPages.AccountPages.Views;

public partial class ProfilePage : ContentPage
{
    private readonly ProfileViewModel ProfileVM;

    public ProfilePage(ProfileViewModel profileVM)
	{
		InitializeComponent();
        BindingContext = profileVM;
        ProfileVM = profileVM;
    }

    //private void ContentPage_Appearing(object sender, EventArgs e)
    //{
    //    ProfileVM.ChangeColorBars(MainGrid.BackgroundColor, StatusBarColor.BarWhite, null);
    //    DeviceDesignSettings.OpacityAnimation(this, ShadowRectangle, 20, 500, 0);
    //    //await QuestTapePageVM.GetQuestItems();    //получение новых данных
    //}
}