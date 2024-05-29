
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using LivePlayMAUI.Abstracts;
using LivePlayMAUI.Models.Domain;
using LivePlayMAUI.Models.Enum;
using LivePlayMAUI.Models.Options;
using LivePlayMAUI.Models.ViewModels.QuestViewModels;
using LivePlayMAUI.Pages;
using LivePlayMAUI.Services;
using MauiPopup;
using Microsoft.Extensions.Options;
using Microsoft.Maui.Controls;
using Microsoft.Maui.Controls.Internals;
using System.Collections.ObjectModel;

namespace LivePlayMAUI.Models.ViewModels;

public partial class QuestTapePageViewModel : MainTapeViewModel
{
    [ObservableProperty]
    public ObservableCollection<QuestItem> _tapeItems;
    public DeviceStorage _deviceStorage;

    public IReadOnlyList<ChoicePanelItem> QuestFilterItems { get; set; } = [
        new ChoicePanelItem { Icon = "star_light.svg", Text="Все" },
        new ChoicePanelItem { Icon = "in_process_light.svg", Text="В процессе" },
        new ChoicePanelItem { Icon = "done_quests_light.svg", Text="Выполненные" }
        ];

    public QuestTapePageViewModel(DeviceDesignSettings designSettings, DeviceStorage deviceStorage) : base(designSettings)
    {
        _deviceStorage = deviceStorage; //заменить, переход строго через goto
        GetQuestItems();
    }

    public async Task GetQuestItems()
    {
        TapeItems = [
            new("БЕБЕ", "fnwejkfnerbiuerbvierbviurbve", $@"/storage/emulated/0/DCIM/Camera/Рисунок1.png", QuestStatus.NotStarted, TypeQuest.Question),
            new("huiyuyuи", "fnwejkfnerbiuerbvierbviurbve", $@"/storage/emulated/0/DCIM/Camera/20230414_212808.jpg", QuestStatus.InProgress, TypeQuest.Search),
            new("БЕБЕ", "fnwejkfnerbiuerbvierbviurbve", $@"/storage/emulated/0/DCIM/Camera/Рисунок1.png", QuestStatus.InProgress, TypeQuest.Puzzle),
            new("jhhfyf", "fnwejkfnerbiuerbvierbviurbve", $@"/storage/emulated/0/DCIM/Camera/20230414_212808.jpg", QuestStatus.NotStarted, TypeQuest.Question)
        ];
    }

    [RelayCommand]
    public async override Task GoToTapeItem(object item)
    {
        if (item is Tuple<object, ContentPage> tuple && tuple.Item1 is QuestItem questItem && tuple.Item2 is ContentPage contentPage)
        {
            switch (questItem.Status)
            {
                case QuestStatus.NotStarted:
                    var notStartedQuestPVM = new BaseQuestPageViewModel(DesignSettings, questItem ?? throw new Exception("Не удалось загрузить страницу")); // refact error
                    await PopupAction.DisplayPopup(new NotStartedQuestPage(notStartedQuestPVM));
                    break;

                case QuestStatus.InProgress:
                    await GoToInProcessQuestPage(contentPage, questItem);
                    break;

                case QuestStatus.Done:
                    //var currentPageViewModel = new CurrentQuestPageViewModel(_appSettings, questItem ?? throw new Exception("Не удалось загрузить страницу"));
                    //await contentPage.Navigation.PushAsync(new CurrentQuestPage(currentPageViewModel));
                    break;
            }
        }
    }

    public async Task GoToInProcessQuestPage(ContentPage contentPage, QuestItem questItem)
    {
        switch (questItem.Type)
        {
            case TypeQuest.Question:
                var inProgressQuizPVM = new BaseQuestPageViewModel(DesignSettings, questItem ?? throw new Exception("Не удалось загрузить страницу"));
                await contentPage.Navigation.PushAsync(new InProgressQuizQuestPage(inProgressQuizPVM));
                break;

            case TypeQuest.Puzzle:
                var inProgressQRPVM = new BaseQuestPageViewModel(DesignSettings, questItem ?? throw new Exception("Не удалось загрузить страницу"));
                await contentPage.Navigation.PushAsync(new InProgressQRQuestPage(inProgressQRPVM));
                break;

            case TypeQuest.Search:
                var inProgressPhotoPVM = new InProgressPhotoPageViewModel(DesignSettings, _deviceStorage, questItem ?? throw new Exception("Не удалось загрузить страницу"));
                await contentPage.Navigation.PushAsync(new InProgressPhotoQuestPage(inProgressPhotoPVM));
                break;
        }
    }
}
