
using LivePlay.Front.MAUI.Models.Domain;
using LivePlay.Front.MAUI.Models.ViewModels;

namespace LivePlay.Front.MAUI.Pages.AdminPages;

public partial class TapeFeedbackPage : ContentPage
{
	public TapeFeedbackPage(TapeFeedbackViewModel tapeFeedbackViewModel)
	{
		InitializeComponent();
		BindingContext = tapeFeedbackViewModel;
	}
}