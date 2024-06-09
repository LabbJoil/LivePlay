using LivePlayMAUI.Models.Domain;
using LivePlayMAUI.Models.ViewModels;

namespace LivePlayMAUI.Pages.AdminPages;

public partial class TapeFeedbackPage : ContentPage
{
	public TapeFeedbackPage(TapeFeedbackViewModel tapeFeedbackViewModel)
	{
		InitializeComponent();
		BindingContext = tapeFeedbackViewModel;
	}
}