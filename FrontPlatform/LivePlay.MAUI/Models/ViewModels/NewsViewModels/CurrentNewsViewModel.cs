
using LivePlayMAUI.Models.Domain;
using LivePlayMAUI.Abstracts;
using LivePlayMAUI.Services;
using CommunityToolkit.Mvvm.ComponentModel;

namespace LivePlayMAUI.Models.ViewModels.NewsViewModels;

public partial class CurrentNewsViewModel(DeviceDesignSettings designSettings) : BaseViewModel(designSettings)
{
    [ObservableProperty]
    public NewsItem _currentNewsItem = new();
}
