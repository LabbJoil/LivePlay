
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using LivePlay.Front.Core.Models;
using LivePlay.Front.MAUI.DeviceSettings;
using LivePlay.Front.MAUI.Pages.QuestPages.CreationQuestPages;
using System.Text.Json;

namespace LivePlay.Front.MAUI.ViewModels.QuestViewModels;

public partial class ManageQuestPageViewModel : BaseQuestPageViewModel
{
    [ObservableProperty]
    public Quest[] _questItems = [];

    public ManageQuestPageViewModel(AppDesign designSettings) : base(designSettings)
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
        await Shell.Current.GoToAsync($"{nameof(MainCreationQuestPage)}");
    }
}
