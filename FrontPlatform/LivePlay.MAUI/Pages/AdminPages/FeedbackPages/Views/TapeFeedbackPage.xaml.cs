
using LivePlay.Front.MAUI.Models.ViewModels;

namespace LivePlay.Front.MAUI.Pages.AdminPages.FeedbackPages.Views;

public partial class TapeFeedbackPage : ContentPage
{
	public TapeFeedbackPage(TapeFeedbackPageViewModel tapeFeedbackViewModel)
	{
		InitializeComponent();
		BindingContext = tapeFeedbackViewModel;
	}
}