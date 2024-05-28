
using LivePlayMAUI.Models.Domain;
using LivePlayMAUI.Abstracts;
using LivePlayMAUI.Services;
using CommunityToolkit.Mvvm.ComponentModel;

namespace LivePlayMAUI.Models.ViewModels;

public partial class BaseQuestPageViewModel(AppSettings appSettings, QuestItem questItem) : BaseViewModel(appSettings)
{
    [ObservableProperty]
    public QuestItem _currentQuestItem = questItem;
}
