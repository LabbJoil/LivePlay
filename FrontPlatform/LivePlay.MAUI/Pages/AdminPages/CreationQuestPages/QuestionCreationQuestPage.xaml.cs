
using LivePlay.Front.Application.DeviceSettings;
using LivePlay.Front.Core.Enums;
using LivePlay.Front.Core.Models;
using LivePlay.Front.MAUI.Pages.AdminPages;
using LivePlay.Front.MAUI.PersonalElements;
using LivePlay.Front.MAUI.ViewModels.AdminViewModels;
using Microsoft.Maui.Controls;
using System.Text.Json;

namespace LivePlay.Front.MAUI.Pages.QuestPages.CreationQuestPages;

[QueryProperty(nameof(QuestItemProperty), nameof(QuestItemProperty))]
public partial class QuestionCreationQuestPage : ContentPage
{
    private Grid NowGrid;

    public QuestItem QuestItemProperty { get; set; } = new();

    public QuestionCreationQuestPage(QuestionCreationQuestPageViewModel questionCreationQuestPVM)
	{
        InitializeComponent();
        BindingContext = questionCreationQuestPVM;
        NowGrid = FirstItem;
    }

    public async Task<QuestionQuestItemControl> GoQuest(DirectionAction swipeSlIn)
    {
        var nextGrid = NowGrid == FirstItem ? SecondItem : FirstItem;
        await ChangeStackLayout(nextGrid, swipeSlIn);
        return NowGrid.Children[0] as QuestionQuestItemControl;
    }

    // TODO: גûםוסעט מעהוכüםûל לועמהמל
    private async Task ChangeStackLayout(Grid GridIn, DirectionAction swipeSlIn)
    {
        double slInXStartposition = swipeSlIn == DirectionAction.Left ? NowGrid.Width : -NowGrid.Width;
        GridIn.TranslationX = slInXStartposition;
        GridIn.IsVisible = true;
        Task animation1 = NowGrid.TranslateTo(-slInXStartposition, 0, 350, Easing.Linear);
        Task animation2 = GridIn.TranslateTo(0, 0, 350, Easing.Linear);
        await Task.WhenAll(animation1, animation2);
        NowGrid.IsVisible = false;
        NowGrid = GridIn;
    }
}