
namespace LivePlay.Front.MAUI.Pages.AdminPages.CouponPages.Views;

public partial class ManageCouponPage : ContentPage
{
	public ManageCouponPage()
	{
		InitializeComponent();
	}

    private void Button_Clicked(object sender, EventArgs e)
    {
		Navigation.PushAsync(new CreationCouponPage());
    }
}