
using LivePlay.Front.MAUI.DeviceSettings;
using LivePlay.Front.Core.Enums;
using LivePlay.Front.Core.Models;
using LivePlay.Front.MAUI.Pages.AdminPages;
using LivePlay.Front.MAUI.PersonalElements;
using LivePlay.Front.MAUI.ViewModels.AdminViewModels;
using Microsoft.Maui.Controls;
using System.Text.Json;

namespace LivePlay.Front.MAUI.Pages.QuestPages.CreationQuestPages;

[QueryProperty(nameof(QuestProperty), nameof(QuestProperty))]
public partial class QuestionCreationQuestPage : ContentPage
{
    private QuestionQuestItemControl _nowQQIC;
    private readonly QuestionCreationQuestPageViewModel _questionCreationQuestPVM;

    public Quest QuestProperty {
        set => _questionCreationQuestPVM.CurrentQuestItem = value;
    }

    public QuestionCreationQuestPage(QuestionCreationQuestPageViewModel questionCreationQuestPVM)
	{
        InitializeComponent();
        BindingContext = questionCreationQuestPVM;
        _questionCreationQuestPVM = questionCreationQuestPVM;
        _nowQQIC = FirstItem;
    }

    public async void GoQuest(DirectionAction swipeSlIn, QuestionQuest questionQuestModel, int numberQuest, int countQuests)
    {
        CountQuestionsLabel.Text = $"{numberQuest}";
        var nextQQIC = _nowQQIC == FirstItem ? SecondItem : FirstItem;
        nextQQIC.NowQuestionQuest = questionQuestModel;
        await ChangeStackLayout(nextQQIC, swipeSlIn);
    }

    public QuestionQuest GetNowQuestion()
    {
        return _nowQQIC.NowQuestionQuest;
    }

    // TODO: גûםוסעט מעהוכüםûל לועמהמל
    private async Task ChangeStackLayout(QuestionQuestItemControl GridIn, DirectionAction swipeSlIn)
    {
        double slInXStartposition = swipeSlIn == DirectionAction.Left ? _nowQQIC.Width : -_nowQQIC.Width;
        GridIn.TranslationX = slInXStartposition;
        GridIn.IsVisible = true;
        Task animation1 = _nowQQIC.TranslateTo(-slInXStartposition, 0, 350, Easing.Linear);
        Task animation2 = GridIn.TranslateTo(0, 0, 350, Easing.Linear);
        await Task.WhenAll(animation1, animation2);
        _nowQQIC.IsVisible = false;
        _nowQQIC = GridIn;
    }
}