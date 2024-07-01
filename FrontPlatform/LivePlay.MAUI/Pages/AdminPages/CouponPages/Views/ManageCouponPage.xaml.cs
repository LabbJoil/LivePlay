
namespace LivePlay.Front.MAUI.Pages.AdminPages;

public partial class ManageRewardPage : ContentPage
{
	public ManageRewardPage()
	{
		InitializeComponent();
	}

    private void Button_Clicked(object sender, EventArgs e)
    {
		Navigation.PushAsync(new MainCreationRewardPage());
    }
}