
using LivePlay.Front.MAUI.ViewModels.SettingsViewModels;

namespace LivePlay.Front.MAUI.Pages;

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