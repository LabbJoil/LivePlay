using LivePlayMAUI.Models.Domain;
using LivePlayMAUI.Models.ViewModels;
using LivePlayMAUI.Pages.QuestPages.CreationQuestPages;

namespace LivePlayMAUI.Pages.AdminPages;

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