
using LivePlay.Front.MAUI.Pages.AdminPages.FeedbackPages.ViewModels;

namespace LivePlay.Front.MAUI.Pages.AdminPages.FeedbackPages.Views;

public partial class TapeFeedbackPage : ContentPage
{
	public TapeFeedbackPage(TapeFeedbackViewModel tapeFeedbackViewModel)
	{
		InitializeComponent();
		BindingContext = tapeFeedbackViewModel;
	}
}