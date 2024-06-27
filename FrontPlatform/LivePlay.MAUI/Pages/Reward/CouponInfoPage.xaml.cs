
using LivePlay.Front.MAUI.ViewModels.Reward;
using The49.Maui.BottomSheet;

namespace LivePlay.Front.MAUI.Pages.Reward;

public partial class CouponInfoPage : ContentPage
{
	public CouponInfoPage(CouponInfoPageViewModel couponInfoPageViewModel)
	{
		InitializeComponent();
		BindingContext = couponInfoPageViewModel;
	}
}