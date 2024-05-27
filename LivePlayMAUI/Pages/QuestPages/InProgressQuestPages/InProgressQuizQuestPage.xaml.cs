
using LivePlayMAUI.Models.ViewModels;

namespace LivePlayMAUI.Pages;

public partial class InProgressQuizQuestPage : ContentPage
{
	public InProgressQuizQuestPage(BaseQuestPageViewModel inProgressPhotoPVM)
	{
		InitializeComponent();
        BindingContext = inProgressPhotoPVM;
    }
}