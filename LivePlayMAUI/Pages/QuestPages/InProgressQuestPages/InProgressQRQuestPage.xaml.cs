
using LivePlayMAUI.Models.ViewModels;
using LivePlayMAUI.Models.ViewModels.QuestViewModels;

namespace LivePlayMAUI.Pages;

public partial class InProgressQRQuestPage : ContentPage
{
	public InProgressQRQuestPage(InProgressPhotoPageViewModel inProgressPhotoPVM)
	{
		InitializeComponent();
        BindingContext = inProgressPhotoPVM;
    }
}