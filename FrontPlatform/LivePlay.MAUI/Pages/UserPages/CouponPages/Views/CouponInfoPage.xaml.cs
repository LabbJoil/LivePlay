
using LivePlay.Front.MAUI.Pages.UserPages.CouponPages.ViewModels;

namespace LivePlay.Front.MAUI.Pages.UserPages.CouponPages.Views;

public partial class CouponInfoPage : ContentPage
{
	public CouponInfoPage(CouponInfoPageViewModel couponInfoPageViewModel)
	{
		InitializeComponent();
		BindingContext = couponInfoPageViewModel;
	}
}