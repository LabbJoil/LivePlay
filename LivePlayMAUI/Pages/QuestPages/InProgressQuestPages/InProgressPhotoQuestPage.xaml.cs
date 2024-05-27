
using LivePlayMAUI.Models.ViewModels;

namespace LivePlayMAUI.Pages;

public partial class InProgressPhotoQuestPage : ContentPage
{
	public InProgressPhotoQuestPage(BaseQuestPageViewModel inProgressPhotoPVM)
	{
		InitializeComponent();
        BindingContext = inProgressPhotoPVM;
    }
}