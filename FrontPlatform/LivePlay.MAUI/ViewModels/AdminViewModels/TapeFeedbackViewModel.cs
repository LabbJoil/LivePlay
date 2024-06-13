
using CommunityToolkit.Maui.Views;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using LivePlay.Front.MAUI.Abstracts;
using LivePlay.Front.MAUI.Enum;
using LivePlay.Front.MAUI.Models.Domain;
using LivePlay.Front.MAUI.Pages;
using LivePlay.Front.MAUI.Pages.AdminPages;
using LivePlay.Front.MAUI.Services;
using MauiPopup;
using System.Collections.ObjectModel;
using System.Text.Json;

namespace LivePlay.Front.MAUI.Models.ViewModels;

public partial class TapeFeedbackViewModel : MainTapeViewModel
{
    public DeviceStorage _deviceStorage;

    [ObservableProperty]
    public IReadOnlyList<FeedbackContactInfoModel> _tapeItems;

    public TapeFeedbackViewModel(DeviceDesignSettings designSettings, DeviceStorage deviceStorage) : base(designSettings)
    {
        _deviceStorage = deviceStorage; //заменить, переход строго через goto
        GetFeedbackItems();
    }

    public async Task GetFeedbackItems()
    {
        TapeItems = [new() { NameUser = "Иванов Иван" }];
    }

    [RelayCommand]
    public async override Task GoToTapeItem(object item)
    {
        if (item is Tuple<object, object> tuple && tuple.Item1 is FeedbackContactInfoModel feedbackContactInfoModel && tuple.Item2 is ContentPage contentPage)
        {
            //var shellParameters = new ShellNavigationQueryParameters { { $"{nameof(FeedbackContactInfoModel)}Property", feedbackContactInfoModel } };
            //await Shell.Current.GoToAsync($"{nameof(CurrentFeedbackPage)}", shellParameters);

            var popup = new CurrentFeedbackPage(feedbackContactInfoModel);
            contentPage.ShowPopup(popup);
        }
    }
}
