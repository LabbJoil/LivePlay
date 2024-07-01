
using LivePlay.Front.Core.Enums;
using LivePlay.Front.Core.Models;
using LivePlay.Front.MAUI.Pages.UserPages.QuestPages.InProgress.ViewModels;
using LivePlay.Front.MAUI.PersonalElements;

namespace LivePlay.Front.MAUI.Pages.UserPages.QuestPages.InProgress.Views;

[QueryProperty(nameof(QuestProperty), nameof(QuestProperty))]
public partial class InProgressQuestionQuestPage : ContentPage
{
    public Quest QuestProperty
    {
        set => _inProgressQuestionQuestPVM.CurrentQuestItem = value;
    }

    private readonly InProgressQuestionQuestPageViewModel _inProgressQuestionQuestPVM;
    private InProgressQuestionQuestItem _nowQQIC;
    private int _numberQuestion = 0;
    private readonly int _countQuests;

    public InProgressQuestionQuestPage(InProgressQuestionQuestPageViewModel inProgressQuestionQuestPVM)
	{
		InitializeComponent();
        BindingContext = inProgressQuestionQuestPVM;
        _inProgressQuestionQuestPVM = inProgressQuestionQuestPVM;
        _nowQQIC = FirstItem;
        _countQuests = inProgressQuestionQuestPVM.GetCountQuestionQuests();
        inProgressQuestionQuestPVM.GetItemsData(this);

        NumberQuestLabel.Text = $"1 из {_countQuests}";
    }

    public async Task<QuestionQuest> GoQuest(DirectionAction swipeSlIn, QuestionQuest questionQuestModel, int numberQuest)
    {
        if (_countQuests-1 == numberQuest)
            SaveQuestButton.IsVisible = true;
        else
            SaveQuestButton.IsVisible = false;

        NumberQuestLabel.Text = $"{numberQuest+1} из {_countQuests}";

        var nowQuestionQuestModel = _nowQQIC.NowQuestionQuest;
        var nextQQIC = _nowQQIC == FirstItem ? SecondItem : FirstItem;
        nextQQIC.NowQuestionQuest = questionQuestModel;
        await ChangeStackLayout(nextQQIC, swipeSlIn);
        return nowQuestionQuestModel;
    }

    // TODO: вынести отдельным методом
    private async Task ChangeStackLayout(InProgressQuestionQuestItem QQICIn, DirectionAction swipeSlIn)
    {
        double slInXStartposition = swipeSlIn == DirectionAction.Left ? _nowQQIC.Width : -_nowQQIC.Width;
        QQICIn.TranslationX = slInXStartposition;
        QQICIn.IsVisible = true;
        Task animation1 = _nowQQIC.TranslateTo(-slInXStartposition, 0, 350, Easing.Linear);
        Task animation2 = QQICIn.TranslateTo(0, 0, 350, Easing.Linear);
        await Task.WhenAll(animation1, animation2);
        _nowQQIC.IsVisible = false;
        _nowQQIC = QQICIn;
    }
}