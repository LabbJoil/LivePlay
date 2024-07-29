
using CommunityToolkit.Mvvm.Input;
using LivePlay.Front.Core.Enums;
using LivePlay.Front.Core.Models.QuestModels;
using LivePlay.Front.Infrastructure.HttpServices.QuestHttpServices;
using LivePlay.Front.MAUI.Abstracts;
using LivePlay.Front.MAUI.DeviceSettings;
using LivePlay.Front.MAUI.Pages.UserPages.QuestPages.InProgress.Views;
using LivePlay.Front.MAUI.Pages.UserPages.QuestPages.Tape.Views;
using System.Text.Json;

namespace LivePlay.Front.MAUI.Pages.UserPages.QuestPages.InProgress.ViewModels;

public partial class InProgressQuestionQuestViewModel : BaseQuestViewModel
{
    private readonly QuestionQuestHttpService _questionQuestHttpService;
    private QuestionQuest[] AllQuestionQuests = [];
    private int NowQuest = -1;

    public InProgressQuestionQuestViewModel(IServiceScopeFactory serviceScopeFactory) : base(serviceScopeFactory)
    {
        using var scope = serviceScopeFactory.CreateScope();
        _questionQuestHttpService = scope.ServiceProvider.GetRequiredService<QuestionQuestHttpService>();
        LoadQuestionQuests();
    }

    private async void LoadQuestionQuests()
    {
        (AllQuestionQuests, var error) = await _questionQuestHttpService.GetQuestions(CurrentQuestItem.Id);
        if (error != null)
            ShowError(error);
    }

    public async void GetItemsData(InProgressQuestionQuestPage page)
    {
        await GoNextQuestion(page);
    }

    public int GetCountQuestionQuests()
    {
        return AllQuestionQuests.Length;
    }

    [RelayCommand]
    public async Task GoNextQuestion(InProgressQuestionQuestPage page)
    {
        if (NowQuest < AllQuestionQuests.Length-1)
        {
            NowQuest++;
            await page.GoQuest(DirectionAction.Left, AllQuestionQuests[NowQuest], NowQuest);
        }
    }

    [RelayCommand]
    public async Task GoPreviousQuestion(InProgressQuestionQuestPage page)
    {
        if (NowQuest < 1)
            return;
        if (NowQuest < AllQuestionQuests.Length)
        {
            NowQuest--;
            await page.GoQuest(DirectionAction.Right, AllQuestionQuests[NowQuest], NowQuest);
        }
    }

    [RelayCommand]
    public async Task Check()
    {
        Shell.Current.DisplayAlert("Всё верно", $"Вы получили {_currentQuestItem.Reward}", "ok");
        DesignSettings.ChangeCountCoins(_currentQuestItem.Reward);
        await Shell.Current.GoToAsync($"//{nameof(TapeQuestPage)}");
    }
}
