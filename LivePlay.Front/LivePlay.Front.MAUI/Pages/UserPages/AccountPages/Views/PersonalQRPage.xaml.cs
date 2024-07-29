using LivePlay.Front.MAUI.Pages.UserPages.AccountPages.ViewModels;
using The49.Maui.BottomSheet;

namespace LivePlay.Front.MAUI.Pages.UserPages.AccountPages.Views;

public partial class PersonalQRPage : BottomSheet
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
		PersonalQRVM.FirstLoadQRData([QRcode, DateUpdateLabel]);
	}
}