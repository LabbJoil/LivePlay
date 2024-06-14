
using LivePlay.Front.MAUI.Pages.QuestPages.CreationQuestPages;

namespace LivePlay.Front.MAUI.Pages.AdminPages;

public partial class ManageQuestPage : ContentPage
{
	public ManageQuestPage()
	{
		InitializeComponent();
	}

    private void Button_Clicked(object sender, EventArgs e)
    {
		Navigation.PushAsync(new MainCreationQuestPage());
    }
}