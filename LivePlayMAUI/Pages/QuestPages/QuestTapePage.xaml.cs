
using LivePlayMAUI.Models.Domain;
using LivePlayMAUI.Models.Enum;
using LivePlayMAUI.Models.ViewModels;
using LivePlayMAUI.Services;
using MauiPopup;

namespace LivePlayMAUI.Pages;

public partial class QuestTapePage : ContentPage
{
    private readonly QuestTapePageViewModel QuestTapePageVM;
    public QuestTapePage(QuestTapePageViewModel questTapePageViewModel)
	{
		InitializeComponent();
        BindingContext = questTapePageViewModel;
        QuestTapePageVM = questTapePageViewModel;
    }

    private void ContentPage_Appearing(object sender, EventArgs e)
    {
        QuestTapePageVM.ChangeColorBars(MainGrid.BackgroundColor, StatusBarColor.BarWhite, null);
        AppSettings.OpacityAnimation(this, ShadowRectangle, 20, 500, 0);
    }

    private void ContentPage_Disappearing(object sender, EventArgs e)
    {
        var mgc = MainGrid.BackgroundColor;
        QuestTapePageVM.ChangeColorBars(new Color(mgc.Red, mgc.Green, mgc.Blue, (float)0.5), StatusBarColor.BarWhite, null);
        AppSettings.OpacityAnimation(this, ShadowRectangle, 20, 500, 0.5);
    }


}
