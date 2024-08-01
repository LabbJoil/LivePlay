
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
        ProfileVM.ChangeColorBars(MainGrid.BackgroundColor, Colors.White);
    }
}