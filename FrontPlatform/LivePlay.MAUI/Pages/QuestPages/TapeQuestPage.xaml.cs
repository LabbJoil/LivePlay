
using LivePlay.Front.MAUI.Enum;
using LivePlay.Front.MAUI.Models.ViewModels;
using LivePlay.Front.MAUI.Services;

namespace LivePlay.Front.MAUI.Pages;

public partial class TapeQuestPage : ContentPage
{
    private readonly TapeQuestViewModel QuestTapePageVM;
    public TapeQuestPage(TapeQuestViewModel questTapePageViewModel)
    {
        InitializeComponent();
        BindingContext = questTapePageViewModel;
        QuestTapePageVM = questTapePageViewModel;
    }

    private void ContentPage_Appearing(object sender, EventArgs e)
    {
        QuestTapePageVM.ChangeColorBars(MainGrid.BackgroundColor, StatusBarColor.BarWhite, null);
        DeviceDesignSettings.OpacityAnimation(this, ShadowRectangle, 20, 500, 0);
        //await QuestTapePageVM.GetQuestItems();    //получение новых данных
    }

    private void ContentPage_Disappearing(object sender, EventArgs e)
    {
        var mgc = MainGrid.BackgroundColor;
        QuestTapePageVM.ChangeColorBars(new Color(mgc.Red, mgc.Green, mgc.Blue, (float)0.5), StatusBarColor.BarWhite, null);
        DeviceDesignSettings.OpacityAnimation(this, ShadowRectangle, 20, 500, 0.5);
    }
}
