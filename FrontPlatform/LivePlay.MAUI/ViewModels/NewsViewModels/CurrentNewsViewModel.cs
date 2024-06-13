
using LivePlay.Front.Core.Models.Domain;
using LivePlay.Front.MAUI.Abstracts;
using LivePlay.Front.MAUI.Services;
using CommunityToolkit.Mvvm.ComponentModel;

namespace LivePlay.Front.MAUI.ViewModels.NewsViewModels;

public partial class CurrentNewsViewModel(DeviceDesignSettings designSettings) : BaseViewModel(designSettings)
{
    [ObservableProperty]
    public NewsItem _currentNewsItem = new();
}
