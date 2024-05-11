
using LivePlayMAUI.Models.Domain;
using LivePlayMAUI.Models.Enum;
using LivePlayMAUI.Models.ViewModels;
using LivePlayMAUI.Services;
using MauiPopup;

namespace LivePlayMAUI.Pages;

public partial class QuestTapePage : ContentPage
{
    public QuestTapePage()
	{
		InitializeComponent();
        BindingContext = new QuestTapeViewModel();
        AppSettings.ChangeColorStatusBars?.Invoke(MainGrid.BackgroundColor, StatusBarColor.BarWhite, null);
    }

    private void GoBack(object sender, EventArgs e)
    {
		//Navigation.PopModalAsync();
    }

    private void ListView_ItemTapped(object sender, ItemTappedEventArgs e)
    {
        var index = e.Item as QuestItem;
        PopupAction.DisplayPopup(new CurrentQuestPage(index ?? new()));
        //Navigation.PushAsync(new CurrentQuestPage(index ?? new()));
    }
}
