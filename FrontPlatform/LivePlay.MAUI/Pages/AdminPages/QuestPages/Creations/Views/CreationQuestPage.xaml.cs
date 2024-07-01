
using LivePlay.Front.Core.Enums;
using LivePlay.Front.Core.Models;
using LivePlay.Front.MAUI.ViewModels.QuestViewModels;

namespace LivePlay.Front.MAUI.Pages.QuestPages.CreationQuestPages;

public partial class CreationQuestPage : ContentPage
{
    public CreationQuestPage(CreationQuestPageViewModel mainCreationQuestPageViewModel)
	{
		InitializeComponent();
		BindingContext = mainCreationQuestPageViewModel;
	}
}