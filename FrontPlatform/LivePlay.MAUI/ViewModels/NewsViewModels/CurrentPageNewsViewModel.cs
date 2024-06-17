
using LivePlay.Front.Core.Models;
using LivePlay.Front.MAUI.Abstracts;
using CommunityToolkit.Mvvm.ComponentModel;
using LivePlay.Front.MAUI.DeviceSettings;

namespace LivePlay.Front.MAUI.ViewModels.NewsViewModels;

public partial class CurrentNewsPageViewModel(AppDesign designSettings) : BaseViewModel(designSettings)
{
    [ObservableProperty]
    public NewsItem _currentNewsItem = new();
}
