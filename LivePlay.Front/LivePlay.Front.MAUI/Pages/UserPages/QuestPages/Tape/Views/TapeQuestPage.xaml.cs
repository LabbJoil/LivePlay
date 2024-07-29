
using LivePlay.Front.Core.Enums;
using LivePlay.Front.MAUI.DeviceSettings;
using LivePlay.Front.MAUI.Pages.UserPages.QuestPages.Tape.ViewModels;

namespace LivePlay.Front.MAUI.Pages.UserPages.QuestPages.Tape.Views;

public partial class TapeQuestPage : ContentPage
{
    private readonly TapeQuestViewModel QuestTapeVM;
    public TapeQuestPage(TapeQuestViewModel questTapeVM)
    {
        InitializeComponent();
        BindingContext = questTapeVM;
        QuestTapeVM = questTapeVM;
    }

    private void ContentPage_Appearing(object sender, EventArgs e)
    {
        QuestTapeVM.ChangeColorBars(MainGrid.BackgroundColor, StatusBarColor.BarWhite, null);
    }

    private void ContentPage_Disappearing(object sender, EventArgs e)
    {
        var mgc = MainGrid.BackgroundColor;
        QuestTapeVM.ChangeColorBars(new Color(mgc.Red, mgc.Green, mgc.Blue, (float)0.5), StatusBarColor.BarWhite, null);
    }

    private void Loaded(object sender, EventArgs e)
    {
        //QuestTapeVM.FirstLoadTapeQuest();
    }
}
