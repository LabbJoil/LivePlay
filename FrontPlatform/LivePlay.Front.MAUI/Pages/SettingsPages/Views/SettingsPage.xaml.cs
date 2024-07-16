
using LivePlay.Front.MAUI.Pages.SettingsPages.ViewModels;

namespace LivePlay.Front.MAUI.Pages.SettingsPages.Views;

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