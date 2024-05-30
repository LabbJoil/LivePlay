
using CommunityToolkit.Mvvm.ComponentModel;
using LivePlayMAUI.Abstracts;
using LivePlayMAUI.Models.Domain;
using LivePlayMAUI.Services;

namespace LivePlayMAUI.Models.ViewModels;

public partial class BaseQuestViewModel(DeviceDesignSettings designSettings) : BaseViewModel(designSettings)
{
    [ObservableProperty]
    public QuestItem _currentQuestItem = new();
}
