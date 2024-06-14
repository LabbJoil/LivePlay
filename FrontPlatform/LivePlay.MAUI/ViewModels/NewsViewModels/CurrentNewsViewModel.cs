
using LivePlay.Front.Core.Models;
using LivePlay.Front.Application.Abstracts;
using CommunityToolkit.Mvvm.ComponentModel;
using LivePlay.Front.Application.DeviceSettings;

namespace LivePlay.Front.MAUI.ViewModels.NewsViewModels;

public partial class CurrentNewsViewModel(AppDesign designSettings) : BaseViewModel(designSettings)
{
    [ObservableProperty]
    public NewsItem _currentNewsItem = new();
}
