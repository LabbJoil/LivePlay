
using LivePlayMAUI.Models.ViewModels.SettingsViewModels;
using LivePlayMAUI.Enum;
using LivePlayMAUI.Services;

namespace LivePlayMAUI.Pages;

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