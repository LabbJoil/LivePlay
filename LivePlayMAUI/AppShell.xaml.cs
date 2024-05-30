﻿
using LivePlayMAUI.Models.ViewModels;
using LivePlayMAUI.Pages;
using LivePlayMAUI.Services;
using Microsoft.Maui.Controls.Shapes;

namespace LivePlayMAUI;

public partial class AppShell : Shell
{
    private Grid? LastGrid;
    private readonly DeviceDesignSettings DesignSettings;
    private readonly NavigateThrowLoading NavigateThrow;

    public AppShell(DeviceDesignSettings designSettings, NavigateThrowLoading navigateThrowLoading)
    {
        InitializeComponent();
        DesignSettings = designSettings;
        NavigateThrow = navigateThrowLoading;
        designSettings.ChangeCountCoins = ChangeCountCoins;

        Routing.RegisterRoute(nameof(InProgressPhotoQuestPage), typeof(InProgressPhotoQuestPage));
        Routing.RegisterRoute(nameof(InProgressQRQuestPage), typeof(InProgressQRQuestPage));
        Routing.RegisterRoute(nameof(InProgressQuizQuestPage), typeof(InProgressQuizQuestPage));
        Routing.RegisterRoute(nameof(NotStartedQuestPage), typeof(NotStartedQuestPage));
        Routing.RegisterRoute(nameof(CurrentNewsPage), typeof(CurrentNewsPage));
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
            //await GoToAsync($"//{item.Route}");
            await NavigateThrow.GoToRootPage(item.Route);
            Current.FlyoutIsPresented = false;
        }
    }

    private void ChangeCountCoins(string newCountCoins)
    {
        CoinLabel.Text = newCountCoins;
    }

    private static void SetViewElement(Grid grid, bool isVisible)
    {
        foreach (var elem in grid.Children)
        {
            if (elem is Rectangle rec)
                rec.IsVisible = isVisible;
        }
    }
}
