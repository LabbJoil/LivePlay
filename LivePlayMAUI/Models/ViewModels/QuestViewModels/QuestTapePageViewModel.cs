
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
    public ObservableCollection<QuestItem> TapeItems { get; set; }

    public ObservableCollection<ChosePanelItem> QuestFilterItems { get; set; }

    public QuestTapePageViewModel(AppSettings appSettings, IOptions<QuestFilterOptions> questFilterOptions) : base(appSettings)
    {
        QuestFilterItems = new ObservableCollection<ChosePanelItem>(questFilterOptions.Value.QuestFilterItems);

        // запрос к серверу
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
        //var questItem = item as QuestItem;
        //await PopupAction.DisplayPopup(new CurrentQuestPage(questItem ?? new()));

        if (item is Tuple<object, ContentPage> tuple && tuple.Item1 is QuestItem questItem && tuple.Item2 is ContentPage contentPage)
        {
            switch (questItem.Status)
            {
                case QuestStatus.NotStarted:
                    var notStartedQuestPVM = new BaseQuestPageViewModel(_appSettings, questItem ?? throw new Exception("Не удалось загрузить страницу")); // refact error
                    await contentPage.Navigation.PushAsync(new NotStartedQuestPage(notStartedQuestPVM));
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
        BaseQuestPageViewModel inProgressPhotoPVM; 
        switch (questItem.Type)
        {
            case TypeQuest.Question:
                inProgressPhotoPVM = new BaseQuestPageViewModel(_appSettings, questItem ?? throw new Exception("Не удалось загрузить страницу"));
                await contentPage.Navigation.PushAsync(new InProgressQuizQuestPage(inProgressPhotoPVM));
                break;

            case TypeQuest.Puzzle:
                inProgressPhotoPVM = new InProgressPhotoPageViewModel(_appSettings, questItem ?? throw new Exception("Не удалось загрузить страницу"));
                await contentPage.Navigation.PushAsync(new InProgressQRQuestPage((InProgressPhotoPageViewModel)inProgressPhotoPVM));
                break;

            case TypeQuest.Search:
                inProgressPhotoPVM = new BaseQuestPageViewModel(_appSettings, questItem ?? throw new Exception("Не удалось загрузить страницу"));
                await contentPage.Navigation.PushAsync(new InProgressPhotoQuestPage(inProgressPhotoPVM));
                break;
        }
    }
}
