
using LivePlayMAUI.Models.Domain;
using LivePlayMAUI.Abstracts;
using LivePlayMAUI.Services;
using CommunityToolkit.Mvvm.ComponentModel;

namespace LivePlayMAUI.Models.ViewModels;

public partial class CurrentNewsPageViewModel(AppSettings appSettings, NewsItem newsItem) : BaseViewModel(appSettings)
{
    [ObservableProperty]
    public NewsItem _currentNewsItem = newsItem;
}
