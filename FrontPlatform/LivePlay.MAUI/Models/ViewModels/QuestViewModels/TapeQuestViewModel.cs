
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using LivePlayMAUI.Abstracts;
using LivePlayMAUI.Enum;
using LivePlayMAUI.Models.Domain;
using LivePlayMAUI.Pages;
using LivePlayMAUI.Services;
using MauiPopup;
using System.Collections.ObjectModel;
using System.Text.Json;

namespace LivePlayMAUI.Models.ViewModels;

public partial class TapeQuestViewModel : MainTapeViewModel
{
    public DeviceStorage _deviceStorage;

    [ObservableProperty]
    public IReadOnlyList<QuestionQuestModel> _tapeItems;

    public IReadOnlyList<ChoicePanelItem> QuestFilterItems { get; set; } = [
        new ChoicePanelItem { Icon = "star_light.svg", Text="Все" },
        new ChoicePanelItem { Icon = "in_process_light.svg", Text="В процессе" },
        new ChoicePanelItem { Icon = "done_quests_light.svg", Text="Выполнены" }
        ];

    public TapeQuestViewModel(DeviceDesignSettings designSettings, DeviceStorage deviceStorage) : base(designSettings)
    {
        _deviceStorage = deviceStorage; //заменить, переход строго через goto
        GetQuestItems();
    }

    public async Task GetQuestItems()
    {
        string? json = Preferences.Get($"{nameof(QuestionQuestModel)}", null);
        QuestionQuestModel nowModel;
        if (json != null)
        {
            nowModel = JsonSerializer.Deserialize<QuestionQuestModel>(json);
            TapeItems = [
                nowModel
            ];
        }
    }

    [RelayCommand]
    public async override Task GoToTapeItem(object item)
    {
        if (item is Tuple<object, object> tuple && tuple.Item1 is QuestionQuestModel questItem && tuple.Item2 is ContentView contentPage)
        {
            var shellParameters = new ShellNavigationQueryParameters { { $"{nameof(QuestionQuestModel)}Property", questItem } };
            switch (questItem.NowItem.Status)
            {
                case QuestStatus.NotStarted:
                    var notStartedQuestVM = new BaseQuestViewModel(DesignSettings); // refact error
                    await Shell.Current.DisplayAlert("111", "111", "ok");
                    await PopupAction.DisplayPopup(new NotStartedQuestPage(notStartedQuestVM, questItem));
                    //await Shell.Current.GoToAsync($"{nameof(NotStartedQuestPage)}", shellParameters);
                    break;

                case QuestStatus.InProgress:
                    //await GoToInProcessQuestPage(questItem, shellParameters);
                    break;

                case QuestStatus.Done:
                    //var currentPageViewModel = new CurrentQuestPageViewModel(_appSettings, questItem ?? throw new Exception("Не удалось загрузить страницу"));
                    //await contentPage.Navigation.PushAsync(new CurrentQuestPage(currentPageViewModel));
                    break;
            }
        }
    }

    public async Task GoToInProcessQuestPage(QuestItem questItem, ShellNavigationQueryParameters shellParameters)
    {
        switch (questItem.Type)
        {
            case TypeQuest.Question:
                await Shell.Current.GoToAsync($"{nameof(InProgressQuizQuestPage)}", shellParameters);
                break;

            case TypeQuest.Puzzle:
                await Shell.Current.GoToAsync($"{nameof(InProgressQRQuestPage)}", shellParameters);
                break;

            case TypeQuest.Search:
                await Shell.Current.GoToAsync($"{nameof(InProgressPhotoQuestPage)}", shellParameters);
                break;
        }
    }
}
