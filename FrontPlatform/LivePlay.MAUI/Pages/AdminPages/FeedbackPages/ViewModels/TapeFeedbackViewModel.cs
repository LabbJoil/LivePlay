
using CommunityToolkit.Maui.Views;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using LivePlay.Front.MAUI.Abstracts;
using LivePlay.Front.MAUI.DeviceSettings;
using LivePlay.Front.MAUI.Pages.AdminPages.FeedbackPages.Views;
using LivePlay.Front.Core.Models.FeedbackModels;

namespace LivePlay.Front.MAUI.Pages.AdminPages.FeedbackPages.ViewModels;

public partial class TapeFeedbackViewModel : BaseTapeViewModel
{
    public AppStorage _deviceStorage;

    [ObservableProperty]
    public IReadOnlyList<FeedbackContactInfo> _tapeItems;

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
        if (item is Tuple<object, object> tuple && tuple.Item1 is FeedbackContactInfo feedbackContactInfoModel && tuple.Item2 is ContentPage contentPage)
        {
            //var shellParameters = new ShellNavigationQueryParameters { { $"{nameof(FeedbackContactInfoModel)}Property", feedbackContactInfoModel } };
            //await Shell.Current.GoToAsync($"{nameof(CurrentFeedbackPage)}", shellParameters);

            var popup = new CurrentFeedbackPage(feedbackContactInfoModel);
            contentPage.ShowPopup(popup);
        }
    }
}
