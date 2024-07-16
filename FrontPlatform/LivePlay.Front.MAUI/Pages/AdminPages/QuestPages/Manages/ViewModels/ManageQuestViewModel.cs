
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using LivePlay.Front.Core.Models.QuestModels;
using LivePlay.Front.Infrastructure.HttpServices.QuestHttpServices;
using LivePlay.Front.MAUI.Abstracts;
using LivePlay.Front.MAUI.DeviceSettings;
using LivePlay.Front.MAUI.Pages.AdminPages.QuestPages.Creations.Views;
using System.Text.Json;

namespace LivePlay.Front.MAUI.Pages.AdminPages.QuestPages.Manages.ViewModels;

public partial class ManageQuestViewModel : BaseQuestViewModel
{
    private readonly QuestHttpService _questHttpService;

    [ObservableProperty]
    public Quest[] _questItems = [];

    public ManageQuestViewModel(AppDesign designSettings, QuestHttpService questHttpService) : base(designSettings)
    {
        _questHttpService = questHttpService;
        GetQuestItems();
    }

    public async void GetQuestItems()
    {
        //string? json = Preferences.Get(nameof(Quest), null);
        //if (json != null)
        //    QuestItems = [JsonSerializer.Deserialize<Quest>(json)];

        StartLoading();
        (QuestItems, var error) = await _questHttpService.GetAllQuests();
        if (error != null) { ShowError(error); }
        StopLoading();
    }

    [RelayCommand]
    private async Task GoToNextCreationPage()
    {
        await Shell.Current.GoToAsync($"{nameof(CreationQuestPage)}");
    }
}
