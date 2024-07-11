
using CommunityToolkit.Mvvm.Input;
using LivePlay.Front.MAUI.Abstracts;
using LivePlay.Front.MAUI.DeviceSettings;
using LivePlay.Front.Core.Models;
using System.Collections.ObjectModel;
using LivePlay.Front.MAUI.Pages.UserPages.NewsPages.Views;
using LivePlay.Front.Infrastructure.HttpServices;
using CommunityToolkit.Maui.Core.Extensions;
using CommunityToolkit.Mvvm.ComponentModel;

namespace LivePlay.Front.MAUI.Pages.UserPages.AccountPages.ViewModels;

public partial class MainViewModel : BaseTapeViewModel
{
    private readonly UserHttpService _userService;
    private readonly NewsHttpService _newsService;
    private string? _qrData;

    [ObservableProperty]
    public ObservableCollection<News> _tapeItems = [];

    [RelayCommand]
    public void RefreshPage()
    {
        GetMainPageInfo();
        Refresh();
    }

    [RelayCommand]
    public async override Task GoToTapeItem(object item)
    {
        if (item is Tuple<object, ContentPage> tuple && tuple.Item1 is News newsItem && tuple.Item2 is ContentPage contentPage)
        {
            await Shell.Current.GoToAsync($"{nameof(CurrentNewsPage)}", new ShellNavigationQueryParameters { { $"{nameof(News)}Property", newsItem } });
        }
    }

    public MainViewModel(AppDesign designSettings, UserHttpService userHttpService, NewsHttpService newsHttpService) : base(designSettings)
    {
        _userService = userHttpService;
        _newsService = newsHttpService;
        GetMainPageInfo();
    }

    public async void GetMainPageInfo()
    {
        StartLoading();
        var (points, error) = await _userService.GetPoints();
        if (error != null) { ShowError(error); goto EndProcess; }
        (_qrData, error) = await _userService.GetPersonalQR();
        if (error != null) { ShowError(error); goto EndProcess; }
        (var news, error) = await _newsService.GetLastNews();
        if (error != null) { ShowError(error); goto EndProcess; }

        TapeItems = news?.ToObservableCollection() ?? [];
        DesignSettings.ChangeCountCoins?.Invoke(points);

    EndProcess:
        StopLoading();
    }
}
