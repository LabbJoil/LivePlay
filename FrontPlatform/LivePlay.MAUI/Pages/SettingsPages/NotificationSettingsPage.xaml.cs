
using LivePlay.Front.MAUI.ViewModels.SettingsViewModels;

namespace LivePlay.Front.MAUI.Pages;

public partial class NotificationSettingsPage : ContentPage
{
    private readonly SettingsPageViewModel SettingsVM;
    public NotificationSettingsPage(SettingsPageViewModel settingsViewModel)
    {
        InitializeComponent();
        BindingContext = settingsViewModel;
        SettingsVM = settingsViewModel;
    }

}