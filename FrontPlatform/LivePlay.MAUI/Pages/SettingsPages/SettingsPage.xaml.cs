
using LivePlay.Front.MAUI.ViewModels.SettingsViewModels;

namespace LivePlay.Front.MAUI.Pages;

public partial class SettingsPage : ContentPage
{
    private readonly SettingsPageViewModel SettingsVM;
    public SettingsPage(SettingsPageViewModel settingsViewModel)
    {
        InitializeComponent();
        BindingContext = settingsViewModel;
        SettingsVM = settingsViewModel;
    }

}