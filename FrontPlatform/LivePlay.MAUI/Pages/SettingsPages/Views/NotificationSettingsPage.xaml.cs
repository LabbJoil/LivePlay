
using LivePlay.Front.MAUI.Pages.AdminPages.SettingsPages.ViewModels;

namespace LivePlay.Front.MAUI.Pages.AdminPages.SettingsPages.Views;

public partial class NotificationSettingsPage : ContentPage
{
    private readonly SettingsViewModel SettingsVM;
    public NotificationSettingsPage(SettingsViewModel settingsViewModel)
    {
        InitializeComponent();
        BindingContext = settingsViewModel;
        SettingsVM = settingsViewModel;
    }

}