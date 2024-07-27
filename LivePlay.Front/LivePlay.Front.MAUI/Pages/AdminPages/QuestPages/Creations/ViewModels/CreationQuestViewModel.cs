
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using LivePlay.Front.Core.Models.QuestModels;
using LivePlay.Front.Infrastructure.HttpServices;
using LivePlay.Front.Infrastructure.Interfaces;
using LivePlay.Front.MAUI.Abstracts;
using LivePlay.Front.MAUI.DeviceSettings;
using LivePlay.Front.MAUI.Pages.AdminPages.QuestPages.Creations.Views;

namespace LivePlay.Front.MAUI.Pages.AdminPages.QuestPages.Creations.ViewModels;

public partial class CreationQuestViewModel(IServiceScopeFactory serviceScopeFactory) : BaseQuestViewModel(serviceScopeFactory)
{
    [ObservableProperty]
    public Quest _nowQuest = new();

    [ObservableProperty]
    public DateTime _minDate  = DateTime.UtcNow.AddDays(1);

    [RelayCommand]
    public async Task GetImage()
    {
        var imagePath = await AppStorage.GetOneItemStorage();
        NowQuest.Image = File.ReadAllBytes(imagePath);
    }

    [RelayCommand]
    public async Task GoToNextCreationQuest()
    {
        var shellParameters = new ShellNavigationQueryParameters { { $"{nameof(Quest)}Property", NowQuest } };
        await Shell.Current.GoToAsync($"{nameof(CreationQuestionQuestPage)}", shellParameters);
    }
}
