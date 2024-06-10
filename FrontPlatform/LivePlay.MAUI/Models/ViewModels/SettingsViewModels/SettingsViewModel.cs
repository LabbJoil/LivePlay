using CommunityToolkit.Mvvm.Input;
using LivePlayMAUI.Abstracts;
using LivePlayMAUI.Models.Domain;
using LivePlayMAUI.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LivePlayMAUI.Models.ViewModels.SettingsViewModels;

public partial class SettingsViewModel : BaseViewModel
{
    public IReadOnlyList<ChoicePanelItem> SettingsItems { get; set; } = [
        new ChoicePanelItem { Icon = "settings.svg", Text="Основные" },
        new ChoicePanelItem { Icon = "notifications.svg", Text="Уведомления" }
        ];

    public SettingsViewModel(DeviceDesignSettings designSettings) : base(designSettings)
    {
        // запрос к серверу
    }
}
