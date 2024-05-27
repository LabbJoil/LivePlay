
using LivePlayMAUI.Models.ViewModels;

namespace LivePlayMAUI.Pages;

public partial class InProgressQRQuestPage : ContentPage
{
	public InProgressQRQuestPage(BaseQuestPageViewModel inProgressPhotoPVM)
	{
		InitializeComponent();
        BindingContext = inProgressPhotoPVM;
    }
}