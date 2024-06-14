
using LivePlay.Front.Application.Abstracts;
using LivePlay.Front.Application.DeviceSettings;
using LivePlay.Front.Core.Models;

namespace LivePlay.Front.MAUI.ViewModels.SettingsViewModels;

public partial class SettingsPageViewModel : BaseViewModel
{
    public IReadOnlyList<ChoicePanelItem> SettingsItems { get; set; } = [
        new ChoicePanelItem { Icon = "settings.svg", Text="Основные" },
        new ChoicePanelItem { Icon = "notifications.svg", Text="Уведомления" }
        ];

    public SettingsPageViewModel(AppDesign designSettings) : base(designSettings)
    {
        // запрос к серверу
    }
}
