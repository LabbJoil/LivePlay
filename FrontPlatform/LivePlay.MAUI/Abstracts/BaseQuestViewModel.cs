
using CommunityToolkit.Mvvm.ComponentModel;
using LivePlay.Front.MAUI.DeviceSettings;
using LivePlay.Front.MAUI.Abstracts;
using LivePlay.Front.Core.Models;

namespace LivePlay.Front.MAUI.Abstracts;

public abstract partial class BaseQuestViewModel(AppDesign designSettings) : BaseViewModel(designSettings)
{
    [ObservableProperty]
    public Quest _currentQuestItem = new();
}
