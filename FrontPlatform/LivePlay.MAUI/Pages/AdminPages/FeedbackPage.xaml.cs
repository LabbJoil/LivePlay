using LivePlayMAUI.Models.Domain;
using LivePlayMAUI.Models.ViewModels;

namespace LivePlayMAUI.Pages.AdminPages;

public partial class FeedbackPage : ContentPage
{
	public FeedbackPage(FeedbackViewModel feedbackViewModel)
	{
		InitializeComponent();
		BindingContext = feedbackViewModel;
	}
}