
using CommunityToolkit.Mvvm.ComponentModel;
using LivePlay.Front.MAUI.DeviceSettings;
using LivePlay.Front.MAUI.Abstracts;
using LivePlay.Front.Core.Models;

namespace LivePlay.Front.MAUI.ViewModels.QuestViewModels;

public partial class BaseQuestPageViewModel(AppDesign designSettings) : BaseViewModel(designSettings)
{
    [ObservableProperty]
    public Quest _currentQuestItem = new();
}
