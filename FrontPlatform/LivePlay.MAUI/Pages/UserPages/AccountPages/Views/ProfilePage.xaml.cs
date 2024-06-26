
using LivePlay.Front.Core.Enums;
using LivePlay.Front.MAUI.DeviceSettings;
using LivePlay.Front.MAUI.Pages.UserPages.AccountPages.ViewModels;

namespace LivePlay.Front.MAUI.Pages.UserPages.AccountPages.Views;

public partial class ProfilePage : ContentPage
{
	private readonly ProfileViewModel ProfileVM;
    public ProfilePage(ProfileViewModel profileViewModel)
	{
		InitializeComponent();
        BindingContext = profileViewModel;
        ProfileVM = profileViewModel;
    }

    private void ContentPage_Appearing(object sender, EventArgs e)
    {
        ProfileVM.ChangeColorBars(MainGrid.BackgroundColor, StatusBarColor.BarWhite, null);
        AppDesign.OpacityAnimation(this, ShadowRectangle, 20, 500, 0);
        //await QuestTapePageVM.GetQuestItems();    //��������� ����� ������
    }

    private void ContentPage_Disappearing(object sender, EventArgs e)
    {
        var mgc = MainGrid.BackgroundColor;
        ProfileVM.ChangeColorBars(new Color(mgc.Red, mgc.Green, mgc.Blue, (float)0.5), StatusBarColor.BarWhite, null);
        AppDesign.OpacityAnimation(this, ShadowRectangle, 20, 500, 0.5);
    }
}