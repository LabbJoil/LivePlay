
using LivePlay.Front.Application.DeviceSettings;
using LivePlay.Front.Core.Enums;
using LivePlay.Front.MAUI.Models.ViewModels;

namespace LivePlay.Front.MAUI.Pages;

public partial class TapeQuestPage : ContentPage
{
    private readonly TapeQuestPageViewModel QuestTapePageVM;
    public TapeQuestPage(TapeQuestPageViewModel questTapePageViewModel)
    {
        InitializeComponent();
        BindingContext = questTapePageViewModel;
        QuestTapePageVM = questTapePageViewModel;
    }

    private void ContentPage_Appearing(object sender, EventArgs e)
    {
        QuestTapePageVM.ChangeColorBars(MainGrid.BackgroundColor, StatusBarColor.BarWhite, null);
        AppDesign.OpacityAnimation(this, ShadowRectangle, 20, 500, 0);
        //await QuestTapePageVM.GetQuestItems();    //получение новых данных
    }

    private void ContentPage_Disappearing(object sender, EventArgs e)
    {
        var mgc = MainGrid.BackgroundColor;
        QuestTapePageVM.ChangeColorBars(new Color(mgc.Red, mgc.Green, mgc.Blue, (float)0.5), StatusBarColor.BarWhite, null);
        AppDesign.OpacityAnimation(this, ShadowRectangle, 20, 500, 0.5);
    }
}
