
using CommunityToolkit.Mvvm.Input;
using LivePlay.Front.Core.Enums;
using LivePlay.Front.Core.Models;
using LivePlay.Front.MAUI.Abstracts;
using LivePlay.Front.MAUI.DeviceSettings;
using LivePlay.Front.MAUI.Pages.AdminPages.QuestPages.Creations.Views;
using System.Text.Json;

namespace LivePlay.Front.MAUI.Pages.AdminPages.QuestPages.Creations.ViewModels;

public partial class CreationQuestionQuestViewModel(AppDesign designSettings) : BaseQuestViewModel(designSettings)
{
    private readonly List<QuestionQuest> AllQuestionQuest = [];
    private int _nowQuest = 0;

    [RelayCommand]
    public void GoNextQuestion(CreationQuestionQuestPage page)
    {
        if (_nowQuest < AllQuestionQuest.Count - 1)
        {
            AllQuestionQuest[_nowQuest] = page.GetNowQuestion();
            page.GoQuest(DirectionAction.Left, AllQuestionQuest[++_nowQuest], _nowQuest + 1, AllQuestionQuest.Count);
        }
        else
        {
            AllQuestionQuest.Add(page.GetNowQuestion());
            page.GoQuest(DirectionAction.Left, new(), ++_nowQuest+1, AllQuestionQuest.Count+1);
            //NowQuest++;
        }
    }

    [RelayCommand]
    public void GoPreviousQuestion(CreationQuestionQuestPage page)
    {
        if (_nowQuest == 0)
            return;
        if (_nowQuest < AllQuestionQuest.Count)
        {
            AllQuestionQuest[_nowQuest] = page.GetNowQuestion();
            page.GoQuest(DirectionAction.Right, AllQuestionQuest[--_nowQuest], _nowQuest+1, AllQuestionQuest.Count);
        }
        else
        {
            AllQuestionQuest.Add(page.GetNowQuestion());
            page.GoQuest(DirectionAction.Right, AllQuestionQuest[--_nowQuest], _nowQuest+1, AllQuestionQuest.Count);
        }
    }

    [RelayCommand]
    public void SaveQuest(CreationQuestionQuestPage page)
    {

        if (_nowQuest < AllQuestionQuest.Count - 1)
            AllQuestionQuest[_nowQuest] = page.GetNowQuestion();
        else
            AllQuestionQuest.Add(page.GetNowQuestion());

        AllQuestionQuest.ForEach(q => q.RightAnswer = -1);

        Preferences.Set(nameof(Quest), JsonSerializer.Serialize(CurrentQuestItem));
        Preferences.Set(nameof(QuestionQuest), JsonSerializer.Serialize(AllQuestionQuest));
        Shell.Current.DisplayAlert("", "Вы создали квест", "ok");
        Shell.Current.GoToAsync("../..");
    }
}
