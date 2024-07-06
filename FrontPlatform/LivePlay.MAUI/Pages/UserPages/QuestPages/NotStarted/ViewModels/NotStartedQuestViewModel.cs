
using CommunityToolkit.Mvvm.Input;
using LivePlay.Front.Application.HttpServices.QuestHttpServices;
using LivePlay.Front.MAUI.Abstracts;
using LivePlay.Front.MAUI.DeviceSettings;

namespace LivePlay.Front.MAUI.Pages.UserPages.QuestPages.NotStarted.ViewModels;

public partial class NotStartedQuestViewModel(AppDesign appDesign, QuestHttpService questHttpService) : BaseQuestViewModel(appDesign)
{
    private readonly QuestHttpService _questHttpService = questHttpService;

    [RelayCommand]
    public async Task TakePartQuest(int idQuest)
    {
        var error = await _questHttpService.TakePart(idQuest);
        if (error != null)
            ShowError(error);
    }
}
