
using LivePlay.Front.MAUI.Pages.AdminPages.QuestPages.Manages.ViewModels;
using LivePlay.Front.MAUI.ViewModels.QuestViewModels;

namespace LivePlay.Front.MAUI.Pages.AdminPages.QuestPages.Manages.Views;

public partial class ManageQuestPage : ContentPage
{
	private ManageQuestViewModel _manageQuestPageViewModel;

    public ManageQuestPage(ManageQuestViewModel manageQuestPageViewModel)
	{
		InitializeComponent();
		BindingContext = manageQuestPageViewModel;
        _manageQuestPageViewModel = manageQuestPageViewModel;

    }

    private void PageAppearing(object sender, EventArgs e)
    {
        _manageQuestPageViewModel.GetQuestItems();
    }
}