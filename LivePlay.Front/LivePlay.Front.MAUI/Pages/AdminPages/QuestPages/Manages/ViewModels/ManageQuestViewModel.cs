
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using LivePlay.Front.Core.Models.QuestModels;
using LivePlay.Front.Infrastructure.HttpServices.QuestHttpServices;
using LivePlay.Front.MAUI.Abstracts;
using LivePlay.Front.MAUI.DeviceSettings;
using LivePlay.Front.MAUI.Pages.AdminPages.QuestPages.Creations.Views;

namespace LivePlay.Front.MAUI.Pages.AdminPages.QuestPages.Manages.ViewModels;

public partial class ManageQuestViewModel(AppDesign designSettings, QuestHttpService questHttpService) : BaseQuestViewModel(designSettings)
{
    private readonly QuestHttpService _questHttpService = questHttpService;

    [ObservableProperty]
    public Quest[] _questItems = [];

    public async void FirstLoadManageQuest(VisualElement[] visualElements)
    {
        StartFirstLoading(visualElements);
        await GetQuestItems();
        StopLoading();
    }

    public override async Task Refresh()
    {
        await GetQuestItems();
        await base.Refresh();
    }

    public async Task GetQuestItems()
    {
        (QuestItems, var error) = await _questHttpService.GetAllQuests();
        if (error != null) { ShowError(error); }
    }

    [RelayCommand]
    private async Task GoToNextCreationPage()
    {
        await Shell.Current.GoToAsync($"{nameof(CreationQuestPage)}");
    }
}
