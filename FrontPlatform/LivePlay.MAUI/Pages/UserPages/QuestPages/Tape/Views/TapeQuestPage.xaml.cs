
using LivePlay.Front.Core.Enums;
using LivePlay.Front.MAUI.DeviceSettings;
using LivePlay.Front.MAUI.Pages.UserPages.QuestPages.Tape.ViewModels;

namespace LivePlay.Front.MAUI.Pages.UserPages.QuestPages.Tape.Views;

public partial class TapeQuestPage : ContentPage
{
    private readonly TapeQuestViewModel QuestTapePVM;
    public TapeQuestPage(TapeQuestViewModel questTapePageViewModel)
    {
        InitializeComponent();
        BindingContext = questTapePageViewModel;
        QuestTapePVM = questTapePageViewModel;
    }

    private void ContentPage_Appearing(object sender, EventArgs e)
    {
        QuestTapePVM.ChangeColorBars(MainGrid.BackgroundColor, StatusBarColor.BarWhite, null);
        AppDesign.OpacityAnimation(this, ShadowRectangle, 20, 500, 0);
        //await QuestTapePageVM.GetQuestItems();    //получение новых данных
    }

    private void ContentPage_Disappearing(object sender, EventArgs e)
    {
        var mgc = MainGrid.BackgroundColor;
        QuestTapePVM.ChangeColorBars(new Color(mgc.Red, mgc.Green, mgc.Blue, (float)0.5), StatusBarColor.BarWhite, null);
        AppDesign.OpacityAnimation(this, ShadowRectangle, 20, 500, 0.5);
    }
}
