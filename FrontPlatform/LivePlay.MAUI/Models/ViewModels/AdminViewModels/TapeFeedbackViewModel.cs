
using CommunityToolkit.Maui.Views;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using LivePlayMAUI.Abstracts;
using LivePlayMAUI.Enum;
using LivePlayMAUI.Models.Domain;
using LivePlayMAUI.Pages;
using LivePlayMAUI.Pages.AdminPages;
using LivePlayMAUI.Services;
using MauiPopup;
using System.Collections.ObjectModel;
using System.Text.Json;

namespace LivePlayMAUI.Models.ViewModels;

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
