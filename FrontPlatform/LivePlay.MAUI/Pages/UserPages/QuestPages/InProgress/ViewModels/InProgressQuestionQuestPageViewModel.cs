
using CommunityToolkit.Mvvm.Input;
using LivePlay.Front.Core.Enums;
using LivePlay.Front.Core.Models;
using LivePlay.Front.MAUI.DeviceSettings;
using LivePlay.Front.MAUI.Pages;
using System.Text.Json;

namespace LivePlay.Front.MAUI.ViewModels.QuestViewModels;

public partial class InProgressQuestionQuestPageViewModel : BaseQuestPageViewModel
{
    private readonly QuestionQuest[] AllQuestionQuests;
    private int NowQuest = -1;

    public InProgressQuestionQuestPageViewModel(AppDesign designSettings) : base(designSettings)
    {
        AllQuestionQuests = LoadQuestionQuests();
    }

    private QuestionQuest[] LoadQuestionQuests()
    {
        if (Preferences.Get(nameof(QuestionQuest), null) is string json)
            return JsonSerializer.Deserialize<QuestionQuest[]>(json);
        return [];
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
        if (NowQuest == 0)
            return;
        if (NowQuest < AllQuestionQuests.Length)
        {
            NowQuest--;
            await page.GoQuest(DirectionAction.Right, AllQuestionQuests[NowQuest], NowQuest);
        }
    }

    [RelayCommand]
    public async Task Cheack()
    {
        Shell.Current.DisplayAlert("Всё верно", $"Вы получили {_currentQuestItem.Reward}", "ok");
        DesignSettings.ChangeCountCoins(_currentQuestItem.Reward);
        await Shell.Current.GoToAsync($"//{nameof(TapeQuestPage)}");
    }
}
