
using LivePlay.Front.MAUI.Pages.QuestPages.CreationQuestPages;
using LivePlay.Front.MAUI.ViewModels.QuestViewModels;

namespace LivePlay.Front.MAUI.Pages.AdminPages;

public partial class ManageQuestPage : ContentPage
{
	private ManageQuestPageViewModel _manageQuestPageViewModel;

    public ManageQuestPage(ManageQuestPageViewModel manageQuestPageViewModel)
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