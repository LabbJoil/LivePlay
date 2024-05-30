
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using LivePlayMAUI.Abstracts;
using LivePlayMAUI.Enum;
using LivePlayMAUI.Models.Domain;
using LivePlayMAUI.Pages;
using LivePlayMAUI.Services;
using MauiPopup;
using System.Collections.ObjectModel;

namespace LivePlayMAUI.Models.ViewModels;

public partial class TapeQuestViewModel : MainTapeViewModel
{
    [ObservableProperty]
    public ObservableCollection<QuestItem> _tapeItems;
    public DeviceStorage _deviceStorage;

    public IReadOnlyList<ChoicePanelItem> QuestFilterItems { get; set; } = [
        new ChoicePanelItem { Icon = "star_light.svg", Text="Все" },
        new ChoicePanelItem { Icon = "in_process_light.svg", Text="В процессе" },
        new ChoicePanelItem { Icon = "done_quests_light.svg", Text="Выполненные" }
        ];

    public TapeQuestViewModel(DeviceDesignSettings designSettings, DeviceStorage deviceStorage) : base(designSettings)
    {
        _deviceStorage = deviceStorage; //заменить, переход строго через goto
        GetQuestItems();
    }

    public async Task GetQuestItems()
    {
        TapeItems = [
            new QuestItem
            {
                Title = "БЕБЕ",
                Description = "fnwejkfnerbiuerbvierbviurbve",
                ImagePath = $@"/storage/emulated/0/DCIM/Camera/Рисунок1.png",
                Status = QuestStatus.NotStarted,
                Type = TypeQuest.Question
            },
            new QuestItem
            {
                Title = "KЕKЕ",
                Description = "fnwejkfnerbiuerbvierbviurbve",
                ImagePath = $@"/storage/emulated/0/DCIM/Camera/Рисунок2.png",
                Status = QuestStatus.InProgress,
                Type = TypeQuest.Search
            },
            new QuestItem
            {
                Title = "MЕMЕ",
                Description = "fnwejkfnerbiuerbvierbviurbve",
                ImagePath = $@"/storage/emulated/0/DCIM/Camera/Рисунок3.png",
                Status = QuestStatus.InProgress,
                Type = TypeQuest.Puzzle
            },
        ];
    }

    [RelayCommand]
    public async override Task GoToTapeItem(object item)
    {
        if (item is Tuple<object, ContentPage> tuple && tuple.Item1 is QuestItem questItem && tuple.Item2 is ContentPage contentPage)
        {
            var shellParameters = new ShellNavigationQueryParameters { { $"{nameof(QuestItem)}Property", questItem } };
            switch (questItem.Status)
            {
                case QuestStatus.NotStarted:
                    var notStartedQuestVM = new BaseQuestViewModel(DesignSettings); // refact error
                    await PopupAction.DisplayPopup(new NotStartedQuestPage(notStartedQuestVM));
                    //await Shell.Current.GoToAsync($"{nameof(NotStartedQuestPage)}", shellParameters);
                    break;

                case QuestStatus.InProgress:
                    await GoToInProcessQuestPage(questItem, shellParameters);
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
