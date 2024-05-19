
using LivePlayMAUI.Models.Domain;
using LivePlayMAUI.Models.Enum;
using LivePlayMAUI.Models.ViewModels;
using LivePlayMAUI.Services;
using MauiPopup;

namespace LivePlayMAUI.Pages;

public partial class QuestTapePage : ContentPage
{
    public QuestTapePage(AppSettings appSettings)
	{
		InitializeComponent();
        BindingContext = new QuestTapePageViewModel(appSettings);
    }

    private void ContentPage_Appearing(object sender, EventArgs e)
    {
        //AppSettings.ChangeColorStatusBars?.Invoke(MainGrid.BackgroundColor, StatusBarColor.BarWhite, null);
        AppSettings.OpacityAnimation(this, ShadowRectangle, 20, 500, 0);
    }

    private void ContentPage_Disappearing(object sender, EventArgs e)
    {
        var mgc = MainGrid.BackgroundColor;
        //AppSettings.ChangeColorStatusBars?.Invoke(new Color(mgc.Red, mgc.Green, mgc.Blue, (float)0.5), StatusBarColor.BarWhite, null);
        AppSettings.OpacityAnimation(this, ShadowRectangle, 20, 500, 0.5);
    }

    //private void ListView_ItemTapped(object sender, ItemTappedEventArgs e)
    //{
    //    var index = e.Item as QuestItem;
    //    PopupAction.DisplayPopup(new CurrentQuestPage(index ?? new()));
    //}

    private void CollectionView_SelectionChanged(object sender, SelectionChangedEventArgs e)
    {
        var index = e.CurrentSelection as QuestItem;
        PopupAction.DisplayPopup(new CurrentQuestPage(index ?? new()));
    }

    private void TapGestureRecognizer_Tapped(object sender, EventArgs e)
    {
        var index = sender as QuestItem;
        PopupAction.DisplayPopup(new CurrentQuestPage(index ?? new()));
    }
}
