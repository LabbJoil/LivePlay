
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using LivePlayMAUI.Abstracts;
using LivePlayMAUI.Enum;
using LivePlayMAUI.Models.Domain;
using LivePlayMAUI.Pages;
using LivePlayMAUI.Services;
using MauiPopup;
using System.Collections.ObjectModel;
using System.Text.Json;

namespace LivePlayMAUI.Models.ViewModels;

public partial class FeedbackViewModel : MainTapeViewModel
{
    public DeviceStorage _deviceStorage;

    [ObservableProperty]
    public IReadOnlyList<FeedbackContactInfoModel> _tapeItems;

    public FeedbackViewModel(DeviceDesignSettings designSettings, DeviceStorage deviceStorage) : base(designSettings)
    {
        _deviceStorage = deviceStorage; //заменить, переход строго через goto
        GetFeedbackItems();
    }

    public async Task GetFeedbackItems()
    {
        TapeItems = [new() { NameUser = "Ivanov Ivan" }];
    }

    [RelayCommand]
    public async override Task GoToTapeItem(object item)
    {
        if (item is Tuple<object, ContentView> tuple && tuple.Item1 is QuestionQuestModel questItem && tuple.Item2 is ContentView contentPage)
        {

        }
    }
}
