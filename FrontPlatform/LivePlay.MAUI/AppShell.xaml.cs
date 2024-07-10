
using LivePlay.Front.MAUI.DeviceSettings;
using LivePlay.Front.MAUI.Pages.AdminPages.FeedbackPages.Views;
using LivePlay.Front.MAUI.Pages.AdminPages.QuestPages.Creations.Views;
using LivePlay.Front.MAUI.Pages.SettingsPages.Views;
using LivePlay.Front.MAUI.Pages.UserPages.CouponPages.Views;
using LivePlay.Front.MAUI.Pages.UserPages.NewsPages.Views;
using LivePlay.Front.MAUI.Pages.UserPages.QuestPages.InProgress.Views;
using LivePlay.Front.MAUI.Pages.UserPages.QuestPages.NotStarted.Views;
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
        designSettings.GetCountCoins = GetCountCoins;

        Routing.RegisterRoute(nameof(InProgressDrawingQuestPage), typeof(InProgressDrawingQuestPage));
        Routing.RegisterRoute(nameof(InProgressQRQuestPage), typeof(InProgressQRQuestPage));
        Routing.RegisterRoute(nameof(InProgressQuestionQuestPage), typeof(InProgressQuestionQuestPage));
        Routing.RegisterRoute(nameof(NotStartedQuestPage), typeof(NotStartedQuestPage));
        Routing.RegisterRoute(nameof(CurrentNewsPage), typeof(CurrentNewsPage));
        Routing.RegisterRoute(nameof(CreationQuestionQuestPage), typeof(CreationQuestionQuestPage));
        Routing.RegisterRoute(nameof(CurrentFeedbackPage), typeof(CurrentFeedbackPage)); //возможно открывается по другому  popup ...
        Routing.RegisterRoute(nameof(CreationQRQuestPage), typeof(CreationQRQuestPage)); //возможно открывается по другому
        Routing.RegisterRoute(nameof(CreationCreativeQuestPage), typeof(CreationCreativeQuestPage)); //возможно открывается по другому
        Routing.RegisterRoute(nameof(LoadingPage), typeof(LoadingPage));
        Routing.RegisterRoute(nameof(CreationQuestPage), typeof(CreationQuestPage));
        Routing.RegisterRoute(nameof(CouponInfoPage), typeof(CouponInfoPage));
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

    private async void FlyoutItemTap(object sender, TappedEventArgs e)
    {
        if (sender is Grid grid)
        {
            if (LastGrid != null) SetViewElement(LastGrid, false);
            SetViewElement(grid, true);
            LastGrid = grid;
            var item = FlyoutItemsNow.Items.ToArray().First(i => i.Items[0].AutomationId == grid.AutomationId);
            //необходимо добавить удаление последних страниц
            await GoToAsync($"//{item.Route}");
            Current.FlyoutIsPresented = false;
        }
    }

    private void ChangeCountCoins(int newCountCoins)
    {
        CoinLabel.Text = newCountCoins.ToString();
    }

    private int GetCountCoins()
    {
        return int.Parse(CoinLabel.Text);
    }

    private static void SetViewElement(Grid grid, bool isVisible)
    {
        foreach (var elem in grid.Children)
        {
            if (elem is Rectangle rec)
                rec.IsVisible = isVisible;
        }
    }

    private async void GetLastTransactions(object sender, TappedEventArgs e)
    {
        if (sender is Grid grid)
        {
            if (LastGrid != null) SetViewElement(LastGrid, false);
            SetViewElement(grid, true);
            LastGrid = grid;
            var item = FlyoutItemsNow.Items.ToArray().First(i => i.Items[0].AutomationId == grid.AutomationId);
            //необходимо добавить удаление последних страниц
            await GoToAsync($"//{item.Route}");
            Current.FlyoutIsPresented = false;
        }
    }
}
