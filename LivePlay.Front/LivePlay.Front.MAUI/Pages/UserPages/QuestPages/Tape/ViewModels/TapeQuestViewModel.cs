
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using LivePlay.Front.Core.Enums;
using LivePlay.Front.Core.Models.QuestModels;
using LivePlay.Front.Infrastructure.HttpServices;
using LivePlay.Front.Infrastructure.HttpServices.QuestHttpServices;
using LivePlay.Front.MAUI.Abstracts;
using LivePlay.Front.MAUI.DeviceSettings;
using LivePlay.Front.MAUI.Models;
using LivePlay.Front.MAUI.Pages.UserPages.QuestPages.InProgress.Views;
using LivePlay.Front.MAUI.Pages.UserPages.QuestPages.NotStarted.Views;

namespace LivePlay.Front.MAUI.Pages.UserPages.QuestPages.Tape.ViewModels;

public partial class TapeQuestViewModel : BaseTapeViewModel
{
    private readonly AppStorage _appStorage;
    private readonly QuestHttpService _questHttpService;

    [ObservableProperty]
    public IReadOnlyList<Quest> _tapeItems = [];

    public IReadOnlyList<ChoicePanelItem> QuestFilterItems { get; } = [
        new ChoicePanelItem { Icon = "star_light.svg", Text="Все" },
        new ChoicePanelItem { Icon = "in_process_light.svg", Text="В процессе" },
        new ChoicePanelItem { Icon = "done_quests_light.svg", Text="Выполнены" }
        ];

    public TapeQuestViewModel(IServiceScopeFactory serviceScopeFactory) : base(serviceScopeFactory)
    {
        using var scope = serviceScopeFactory.CreateScope();
        _appStorage = scope.ServiceProvider.GetRequiredService<AppStorage>();
        _questHttpService = scope.ServiceProvider.GetRequiredService<QuestHttpService>();
        FirstLoadTapeQuest();
    }

    public override async Task Refresh()
    {
        await GetQuestItems();
        await base.Refresh();
    }

    public async void FirstLoadTapeQuest()
    {
        StartMiddleLoading();
        await GetQuestItems();
        StopLoading();
    }

    public async Task GetQuestItems()
    {
        (TapeItems, var error) = await _questHttpService.GetAllQuests();
        if (error != null) ShowError(error);
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

            case TypeQuest.QR:
                await Shell.Current.GoToAsync($"{nameof(InProgressQRQuestPage)}", shellParameters);
                break;

            case TypeQuest.Drawing:
                await Shell.Current.GoToAsync($"{nameof(InProgressDrawingQuestPage)}", shellParameters);
                break;
        }
    }
}
