
using LivePlayMAUI.Models.Domain;
using LivePlayMAUI.Abstracts;
using LivePlayMAUI.Services;
using CommunityToolkit.Mvvm.ComponentModel;

namespace LivePlayMAUI.Models.ViewModels;

public partial class CurrentNewsPageViewModel(DeviceDesignSettings designSettings, NewsItem newsItem) : BaseViewModel(designSettings)
{
    [ObservableProperty]
    public NewsItem _currentNewsItem = newsItem;
}
