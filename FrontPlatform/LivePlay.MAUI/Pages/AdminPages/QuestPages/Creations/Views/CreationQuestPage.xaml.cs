
using LivePlay.Front.Core.Enums;
using LivePlay.Front.Core.Models;
using LivePlay.Front.MAUI.ViewModels.QuestViewModels;

namespace LivePlay.Front.MAUI.Pages.AdminPages.QuestPages.Creations.Views;

public partial class CreationQuestPage : ContentPage
{
    public CreationQuestPage(CreationQuestPageViewModel mainCreationQuestPageViewModel)
	{
		InitializeComponent();
		BindingContext = mainCreationQuestPageViewModel;
	}
}