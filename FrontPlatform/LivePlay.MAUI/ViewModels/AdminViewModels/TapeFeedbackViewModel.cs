
using CommunityToolkit.Maui.Views;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using LivePlay.Front.Application.Abstracts;
using LivePlay.Front.Application.DeviceSettings;
using LivePlay.Front.Core.Models;
using LivePlay.Front.MAUI.Pages.AdminPages;

namespace LivePlay.Front.MAUI.Models.ViewModels;

public partial class TapeFeedbackViewModel : MainTapeViewModel
{
    public AppStorage _deviceStorage;

    [ObservableProperty]
    public IReadOnlyList<FeedbackContactInfoModel> _tapeItems;

    public TapeFeedbackViewModel(AppDesign designSettings, AppStorage deviceStorage) : base(designSettings)
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
