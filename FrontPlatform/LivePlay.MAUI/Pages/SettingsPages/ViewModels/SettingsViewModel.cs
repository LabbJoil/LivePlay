﻿
using LivePlay.Front.MAUI.Abstracts;
using LivePlay.Front.MAUI.DeviceSettings;
using LivePlay.Front.Core.Models;

namespace LivePlay.Front.MAUI.ViewModels.SettingsViewModels;

public partial class SettingsViewModel : BaseViewModel
{
    public IReadOnlyList<ChoicePanelItem> SettingsItems { get; set; } = [
        new ChoicePanelItem { Icon = "settings.svg", Text="Основные" },
        new ChoicePanelItem { Icon = "notifications.svg", Text="Уведомления" }
        ];

    public SettingsViewModel(AppDesign designSettings) : base(designSettings)
    {
        // запрос к серверу
    }
}