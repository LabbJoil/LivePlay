
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using LivePlay.Front.Core.Enums;
using LivePlay.Front.Core.Models;
using LivePlay.Front.MAUI.Abstracts;
using LivePlay.Front.MAUI.DeviceSettings;
using LivePlay.Front.MAUI.Pages.UserPages.QuestPages.InProgress.Views;
using LivePlay.Front.MAUI.Pages.UserPages.QuestPages.NotStarted.Views;
using System.Text.Json;

namespace LivePlay.Front.MAUI.Pages.UserPages.QuestPages.Tape.ViewModels;

public partial class TapeQuestViewModel : BaseTapeViewModel
{
    public AppStorage _deviceStorage;

    [ObservableProperty]
    public IReadOnlyList<Quest> _tapeItems;

    public IReadOnlyList<ChoicePanelItem> QuestFilterItems { get; set; } = [
        new ChoicePanelItem { Icon = "star_light.svg", Text="Все" },
        new ChoicePanelItem { Icon = "in_process_light.svg", Text="В процессе" },
        new ChoicePanelItem { Icon = "done_quests_light.svg", Text="Выполнены" }
        ];

    public TapeQuestViewModel(AppDesign designSettings, AppStorage deviceStorage) : base(designSettings)
    {
        _deviceStorage = deviceStorage; //заменить, переход строго через goto
        TapeItems = GetQuestItems();
    }

    public Quest[] GetQuestItems()
    {
        string? json = Preferences.Get(nameof(Quest), null);
        if (json != null)
            return [JsonSerializer.Deserialize<Quest>(json)];
        return [];
    }

    [RelayCommand]
    public async override Task GoToTapeItem(object item)
    {
        if (item is Tuple<object, object> tuple && tuple.Item1 is Quest questItem && tuple.Item2 is ContentView contentPage)
        {
            var shellParameters = new ShellNavigationQueryParameters { { $"{nameof(Quest)}Property", questItem } };
            switch (questItem.Status)
            {
                case QuestStatus.NotStarted:
                    //var notStartedQuestVM = new BaseQuestPageViewModel(DesignSettings); // refact error
                    await Shell.Current.GoToAsync($"/{nameof(NotStartedQuestPage)}", shellParameters);
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

    public async Task GoToInProcessQuestPage(Quest questItem, ShellNavigationQueryParameters shellParameters)
    {
        switch (questItem.Type)
        {
            case TypeQuest.Question:
                await Shell.Current.GoToAsync($"{nameof(InProgressQuestionQuestPage)}", shellParameters);
                break;

            case TypeQuest.Puzzle:
                await Shell.Current.GoToAsync($"{nameof(InProgressQRQuestPage)}", shellParameters);
                break;

            case TypeQuest.Search:
                await Shell.Current.GoToAsync($"{nameof(InProgressDrawingQuestPage)}", shellParameters);
                break;
        }
    }
}
