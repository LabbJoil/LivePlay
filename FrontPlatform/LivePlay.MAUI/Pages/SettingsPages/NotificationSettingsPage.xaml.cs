
using LivePlayMAUI.Models.ViewModels.SettingsViewModels;
using LivePlayMAUI.Enum;
using LivePlayMAUI.Services;

namespace LivePlayMAUI.Pages;

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