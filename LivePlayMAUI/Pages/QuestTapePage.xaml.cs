
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
    }

    private void ContentPage_Appearing(object sender, EventArgs e)
    {
        AppSettings.OpacityAnimation(this, ShadowRectangle, 20, 500, 0);
        AppSettings.ChangeColorStatusBars?.Invoke(MainGrid.BackgroundColor, StatusBarColor.BarWhite, null);
    }

    private void ContentPage_Disappearing(object sender, EventArgs e)
    {
        AppSettings.OpacityAnimation(this, ShadowRectangle, 20, 500, 0.5);
        AppSettings.ChangeColorStatusBars?.Invoke(((SolidColorBrush)ShadowRectangle.Fill).Color, StatusBarColor.BarWhite, null);
    }

    private void ListView_ItemTapped(object sender, ItemTappedEventArgs e)
    {
        var index = e.Item as QuestItem;
        PopupAction.DisplayPopup(new CurrentQuestPage(index ?? new()));
    }
}
