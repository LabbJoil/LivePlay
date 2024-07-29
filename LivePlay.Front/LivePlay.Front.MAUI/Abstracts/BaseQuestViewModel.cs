
using CommunityToolkit.Mvvm.ComponentModel;
using LivePlay.Front.MAUI.DeviceSettings;
using LivePlay.Front.Core.Models.QuestModels;

namespace LivePlay.Front.MAUI.Abstracts;

public abstract partial class BaseQuestViewModel(IServiceScopeFactory serviceScopeFactory) : BaseViewModel(serviceScopeFactory)
{
    [ObservableProperty]
    public Quest _currentQuestItem = new();
}
