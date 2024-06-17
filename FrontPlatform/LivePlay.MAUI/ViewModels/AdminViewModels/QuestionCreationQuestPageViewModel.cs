
using CommunityToolkit.Mvvm.Input;
using LivePlay.Front.Application.Abstracts;
using LivePlay.Front.Application.DeviceSettings;
using LivePlay.Front.Core.Enums;
using LivePlay.Front.Core.Models;
using LivePlay.Front.MAUI.Pages.QuestPages.CreationQuestPages;

namespace LivePlay.Front.MAUI.ViewModels.AdminViewModels;

public partial class QuestionCreationQuestPageViewModel(AppDesign designSettings) : BaseViewModel(designSettings)
{
    private readonly List<QuestionQuestModel> AllQuestionQuest = [];
    private int NowQuest = 0;

    [RelayCommand]
    public async Task GoForvardQuestion((QuestionCreationQuestPage, QuestionQuestModel) pageAndModel)
    {
        if (NowQuest < AllQuestionQuest.Count - 1)
        {
            AllQuestionQuest[NowQuest] = pageAndModel.Item2;
            NowQuest++;
            var forwardItem = await pageAndModel.Item1.GoQuest(DirectionAction.Left);
            forwardItem.NowQuestionQuest = AllQuestionQuest[NowQuest];
        }
        else
        {
            AllQuestionQuest.Add(new(pageAndModel.Item2));
            pageAndModel.Item2 = new();
            var forwardItem = await pageAndModel.Item1.GoQuest(DirectionAction.Left);
            forwardItem.NowQuestionQuest = new();
            NowQuest++;
        }
    }

    [RelayCommand]
    public async Task GoPreviousQuestion((QuestionCreationQuestPage, QuestionQuestModel) pageAndModel)
    {
        if (NowQuest == 0)
            return;
        if (NowQuest < AllQuestionQuest.Count)
        {
            AllQuestionQuest[NowQuest] = pageAndModel.Item2;
            NowQuest--;
            var previousItem = await pageAndModel.Item1.GoQuest(DirectionAction.Right);
            previousItem.NowQuestionQuest = AllQuestionQuest[NowQuest];
        }
        else
        {
            AllQuestionQuest.Add(pageAndModel.Item2);
            NowQuest--;
            var previousItem = await pageAndModel.Item1.GoQuest(DirectionAction.Right);
            previousItem.NowQuestionQuest = AllQuestionQuest[NowQuest];
        }
    }
}
