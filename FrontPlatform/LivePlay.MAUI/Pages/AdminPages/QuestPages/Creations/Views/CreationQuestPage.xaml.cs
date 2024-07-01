
using LivePlay.Front.MAUI.Pages.AdminPages.QuestPages.Creations.ViewModels;

namespace LivePlay.Front.MAUI.Pages.AdminPages.QuestPages.Creations.Views;

public partial class CreationQuestPage : ContentPage
{
    public CreationQuestPage(CreationQuestViewModel mainCreationQuestPageViewModel)
	{
		InitializeComponent();
		BindingContext = mainCreationQuestPageViewModel;
	}
}