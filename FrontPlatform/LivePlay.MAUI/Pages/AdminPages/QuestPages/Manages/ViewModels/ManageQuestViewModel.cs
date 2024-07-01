
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using LivePlay.Front.Core.Models;
using LivePlay.Front.MAUI.Abstracts;
using LivePlay.Front.MAUI.DeviceSettings;
using System.Text.Json;

namespace LivePlay.Front.MAUI.Pages.AdminPages.QuestPages.Manages.ViewModels;

public partial class ManageQuestViewModel : BaseQuestViewModel
{
    [ObservableProperty]
    public Quest[] _questItems = [];

    public ManageQuestViewModel(AppDesign designSettings) : base(designSettings)
    {
    }

    public void GetQuestItems()
    {
        string? json = Preferences.Get(nameof(Quest), null);
        if (json != null)
            QuestItems = [JsonSerializer.Deserialize<Quest>(json)];
    }

    [RelayCommand]
    private async Task GoToNextCreationPage()
    {
        await Shell.Current.GoToAsync($"{nameof(CreationQuestPage)}");
    }
}
