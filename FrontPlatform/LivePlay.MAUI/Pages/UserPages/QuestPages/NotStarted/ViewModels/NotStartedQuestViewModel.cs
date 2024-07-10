
using CommunityToolkit.Mvvm.Input;
using LivePlay.Front.Infrastructure.HttpServices.QuestHttpServices;
using LivePlay.Front.MAUI.Abstracts;
using LivePlay.Front.MAUI.DeviceSettings;
using LivePlay.Front.Core.Enums;
using LivePlay.Front.MAUI.Pages.UserPages.QuestPages.InProgress.Views;
using LivePlay.Front.Core.Models.QuestModels;

namespace LivePlay.Front.MAUI.Pages.UserPages.QuestPages.NotStarted.ViewModels;

public partial class NotStartedQuestViewModel(AppDesign appDesign, QuestHttpService questHttpService) : BaseQuestViewModel(appDesign)
{
    private readonly QuestHttpService _questHttpService = questHttpService;

    [RelayCommand]
    public async Task TakePartQuest(int idQuest)
    {
        var error = await _questHttpService.TakePart(idQuest);
        if (error != null) { ShowError(error); return; }
        DeleteStackPages(1);

        var navigationParameter = new ShellNavigationQueryParameters
        {
            { $"{nameof(Quest)}Property", CurrentQuestItem },
        };

        switch (CurrentQuestItem.Type)
        {
            case TypeQuest.Question:
                await Shell.Current.GoToAsync($"//{nameof(InProgressQuestionQuestPage)}", navigationParameter);
                break;

            case TypeQuest.QR:
                await Shell.Current.GoToAsync($"//{nameof(InProgressQRQuestPage)}", navigationParameter);
                break;

            default:
                await Shell.Current.GoToAsync($"//{nameof(InProgressDrawingQuestPage)}", navigationParameter);
                break;
        }
    }
}
