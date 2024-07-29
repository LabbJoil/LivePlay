
using LivePlay.Front.Core.Models;
using LivePlay.Front.MAUI.Abstracts;
using CommunityToolkit.Mvvm.ComponentModel;
using LivePlay.Front.MAUI.DeviceSettings;

namespace LivePlay.Front.MAUI.ViewModels.NewsViewModels;

public partial class CurrentNewsPageViewModel(IServiceScopeFactory serviceScopeFactory) : BaseViewModel(serviceScopeFactory)
{
    [ObservableProperty]
    public News _currentNewsItem = new();
}
