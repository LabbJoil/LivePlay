using LivePlayMAUI.Models.Domain;

namespace LivePlayMAUI.Pages;

public partial class CurrentQuestPage : ContentPage
{
	public CurrentQuestPage(QuestItem questItem)
	{
		InitializeComponent();
		BindingContext = questItem;

    }
}