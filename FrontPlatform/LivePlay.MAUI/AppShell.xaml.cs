
using LivePlay.Front.Application.DeviceSettings;
using LivePlay.Front.MAUI.Pages;
using LivePlay.Front.MAUI.Pages.AdminPages;
using LivePlay.Front.MAUI.Pages.QuestPages.CreationQuestPages;
using Microsoft.Maui.Controls.Shapes;

namespace LivePlay.Front.MAUI;

public partial class AppShell : Shell
{
    private Grid? LastGrid;
    private readonly AppDesign DesignSettings;


    public AppShell(AppDesign designSettings)
    {
        InitializeComponent();
        DesignSettings = designSettings;
        designSettings.ChangeCountCoins = ChangeCountCoins;

        Routing.RegisterRoute(nameof(InProgressPhotoQuestPage), typeof(InProgressPhotoQuestPage));
        Routing.RegisterRoute(nameof(InProgressQRQuestPage), typeof(InProgressQRQuestPage));
        Routing.RegisterRoute(nameof(InProgressQuizQuestPage), typeof(InProgressQuizQuestPage));
        Routing.RegisterRoute(nameof(NotStartedQuestPage), typeof(NotStartedQuestPage));
        Routing.RegisterRoute(nameof(CurrentNewsPage), typeof(CurrentNewsPage));
        Routing.RegisterRoute(nameof(QuestionCreationQuestPage), typeof(QuestionCreationQuestPage));
        Routing.RegisterRoute(nameof(CurrentFeedbackPage), typeof(CurrentFeedbackPage)); //возможно открывается по другому  popup ...
        Routing.RegisterRoute(nameof(QRcodeCreationQuestPage), typeof(QRcodeCreationQuestPage)); //возможно открывается по другому
        Routing.RegisterRoute(nameof(CreativeQuestCreationQuestPage), typeof(CreativeQuestCreationQuestPage)); //возможно открывается по другому
        Routing.RegisterRoute(nameof(LoadingPage), typeof(LoadingPage));

    }

    private void FlyoutGrid_Loaded(object sender, EventArgs e)
    {
        if (sender is Grid grid)
        {
            if (grid.AutomationId == "0")
                LastGrid = grid;
            else
                SetViewElement(grid, false);
        }
    }

    private async void TapGestureRecognizer_Tapped(object sender, TappedEventArgs e)
    {
        if (sender is Grid grid)
        {
            if (LastGrid != null) SetViewElement(LastGrid, false);
            SetViewElement(grid, true);
            LastGrid = grid;
            var item = FlyoutItemsNow.Items.ToArray().First(i => i.Items[0].AutomationId == grid.AutomationId);
            await GoToAsync($"//{item.Route}");
            Current.FlyoutIsPresented = false;
        }
    }

    private void ChangeCountCoins(string newCountCoins)
    {
        //CoinLabel.Text = newCountCoins;
    }

    private static void SetViewElement(Grid grid, bool isVisible)
    {
        foreach (var elem in grid.Children)
        {
            if (elem is Rectangle rec)
                rec.IsVisible = isVisible;
        }
    }

    //private async void LogOut_Clicked(object sender, EventArgs e)
    //{
    //    if(await DisplayAlert("Выход", $"Вы точно хотите выйти", "ok", "no"))
    //        await NavigateThrow.GoToRootPage($"//{nameof(EnterPage)}");
    //}

    private void TapGestureRecognizer_Tapped_1(object sender, TappedEventArgs e)
    {
       
    }
}
