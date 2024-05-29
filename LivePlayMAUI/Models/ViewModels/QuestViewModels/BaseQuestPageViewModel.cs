
using LivePlayMAUI.Models.Domain;
using LivePlayMAUI.Abstracts;
using LivePlayMAUI.Services;
using CommunityToolkit.Mvvm.ComponentModel;

namespace LivePlayMAUI.Models.ViewModels;

public partial class BaseQuestPageViewModel(DeviceDesignSettings designSettings, QuestItem questItem) : BaseViewModel(designSettings)
{
    [ObservableProperty]
    public QuestItem _currentQuestItem = questItem;
}
