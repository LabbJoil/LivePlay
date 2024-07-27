
using CommunityToolkit.Mvvm.Input;
using LivePlay.Front.Core.Enums;
using LivePlay.Front.Core.Models.QuestModels;
using LivePlay.Front.Infrastructure.HttpServices;
using LivePlay.Front.Infrastructure.HttpServices.QuestHttpServices;
using LivePlay.Front.Infrastructure.Interfaces;
using LivePlay.Front.MAUI.Abstracts;
using LivePlay.Front.MAUI.DeviceSettings;
using LivePlay.Front.MAUI.Pages.AdminPages.QuestPages.Creations.Views;
using System.Text.Json;

namespace LivePlay.Front.MAUI.Pages.AdminPages.QuestPages.Creations.ViewModels;

public partial class CreationQuestionQuestViewModel : BaseQuestViewModel
{
    private readonly QuestionQuestHttpService _questionQuestHttpService;
    private readonly List<QuestionQuest> _allQuestionQuest = [];
    private int _nowQuest = 0;

    public CreationQuestionQuestViewModel(IServiceScopeFactory serviceScopeFactory) : base(serviceScopeFactory)
    {
        using var scope = serviceScopeFactory.CreateScope();
        _questionQuestHttpService = scope.ServiceProvider.GetRequiredService<QuestionQuestHttpService>();
    }

    [RelayCommand]
    public void GoNextQuestion(CreationQuestionQuestPage page)
    {
        if (_nowQuest < _allQuestionQuest.Count - 1)
        {
            _allQuestionQuest[_nowQuest] = page.GetNowQuestion();
            page.GoQuest(DirectionAction.Left, _allQuestionQuest[++_nowQuest], _nowQuest + 1, _allQuestionQuest.Count);
        }
        else
        {
            _allQuestionQuest.Add(page.GetNowQuestion());
            page.GoQuest(DirectionAction.Left, new(), ++_nowQuest+1, _allQuestionQuest.Count+1);
            //NowQuest++;
        }
    }

    [RelayCommand]
    public void GoPreviousQuestion(CreationQuestionQuestPage page)
    {
        if (_nowQuest == 0)
            return;
        if (_nowQuest < _allQuestionQuest.Count)
        {
            _allQuestionQuest[_nowQuest] = page.GetNowQuestion();
            page.GoQuest(DirectionAction.Right, _allQuestionQuest[--_nowQuest], _nowQuest+1, _allQuestionQuest.Count);
        }
        else
        {
            _allQuestionQuest.Add(page.GetNowQuestion());
            page.GoQuest(DirectionAction.Right, _allQuestionQuest[--_nowQuest], _nowQuest+1, _allQuestionQuest.Count);
        }
    }

    [RelayCommand]
    public async Task SaveQuest(CreationQuestionQuestPage page)
    {
        if (_nowQuest <= _allQuestionQuest.Count - 1)
            _allQuestionQuest[_nowQuest] = page.GetNowQuestion();
        else
            _allQuestionQuest.Add(page.GetNowQuestion());

        StartMiddleLoading();
        var error = await _questionQuestHttpService.AddQuest(CurrentQuestItem, _allQuestionQuest);
        StopLoading();

        if(error != null) { ShowError(error); return; }

        await Shell.Current.DisplayAlert("", "Вы создали квест", "ok");
        await Shell.Current.GoToAsync("../..");
    }
}
