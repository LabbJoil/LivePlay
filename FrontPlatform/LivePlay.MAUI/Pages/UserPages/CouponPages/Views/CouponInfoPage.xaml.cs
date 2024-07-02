
using LivePlay.Front.MAUI.Pages.UserPages.CouponPages.ViewModels;

namespace LivePlay.Front.MAUI.Pages.UserPages.CouponPages.Views;

public partial class CouponInfoPage : ContentPage
{
	public CouponInfoPage(CouponInfoViewModel couponInfoPageViewModel)
	{
		InitializeComponent();
		BindingContext = couponInfoPageViewModel;
	}
}