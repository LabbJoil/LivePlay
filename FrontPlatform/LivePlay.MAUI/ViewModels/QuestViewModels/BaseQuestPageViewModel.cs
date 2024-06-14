
using CommunityToolkit.Mvvm.ComponentModel;
using LivePlay.Front.Application.DeviceSettings;
using LivePlay.Front.Application.Abstracts;
using LivePlay.Front.Core.Models;

namespace LivePlay.Front.MAUI.ViewModels.QuestViewModels;

public partial class BaseQuestPageViewModel(AppDesign designSettings) : BaseViewModel(designSettings)
{
    [ObservableProperty]
    public QuestionQuestModel _currentQuestItem = new();
}
