
using LivePlayMAUI.Models.ViewModels;
using LivePlayMAUI.Models.ViewModels.QuestViewModels;

namespace LivePlayMAUI.Pages;

public partial class InProgressPhotoQuestPage : ContentPage
{
	public InProgressPhotoQuestPage(InProgressPhotoPageViewModel inProgressPhotoPVM)
	{
		InitializeComponent();
        BindingContext = inProgressPhotoPVM;
    }
}