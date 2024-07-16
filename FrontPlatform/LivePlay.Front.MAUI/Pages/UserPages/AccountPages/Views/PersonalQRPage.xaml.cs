using LivePlay.Front.MAUI.Pages.UserPages.AccountPages.ViewModels;

namespace LivePlay.Front.MAUI.Pages.UserPages.AccountPages.Views;

public partial class PersonalQRPage : ContentPage
{
	private PersonalQRViewModel PersonalQRVM;

	public PersonalQRPage(PersonalQRViewModel personalQRVM)
	{
		PersonalQRVM = personalQRVM;
		InitializeComponent();
		BindingContext = personalQRVM;
    }

	private void ContentPage_Loaded(object sender, EventArgs e)
	{
		PersonalQRVM.FirstLoadQRData(this);
	}
}