
using LivePlay.Front.MAUI.ViewModels.SettingsViewModels;

namespace LivePlay.Front.MAUI.Pages;

public partial class SettingsPage : ContentPage
{
    private readonly SettingsViewModel SettingsVM;
    public SettingsPage(SettingsViewModel settingsViewModel)
    {
        InitializeComponent();
        BindingContext = settingsViewModel;
        SettingsVM = settingsViewModel;
    }

}