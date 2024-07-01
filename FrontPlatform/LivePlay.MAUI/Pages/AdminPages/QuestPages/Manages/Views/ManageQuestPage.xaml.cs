
using LivePlay.Front.MAUI.Pages.QuestPages.CreationQuestPages;
using LivePlay.Front.MAUI.ViewModels.QuestViewModels;

namespace LivePlay.Front.MAUI.Pages.AdminPages;

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