
using CommunityToolkit.Mvvm.ComponentModel;
using LivePlay.Front.MAUI.Abstracts;
using LivePlay.Front.MAUI.Models.Domain;
using LivePlay.Front.MAUI.Services;

namespace LivePlay.Front.MAUI.ViewModels.QuestViewModels;

public partial class BaseQuestViewModel(DeviceDesignSettings designSettings) : BaseViewModel(designSettings)
{
    [ObservableProperty]
    public QuestionQuestModel _currentQuestItem = new();
}
