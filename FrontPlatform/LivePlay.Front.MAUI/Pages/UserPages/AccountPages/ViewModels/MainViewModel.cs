﻿
using CommunityToolkit.Mvvm.Input;
using LivePlay.Front.MAUI.Abstracts;
using LivePlay.Front.MAUI.DeviceSettings;
using LivePlay.Front.Core.Models;
using System.Collections.ObjectModel;
using LivePlay.Front.MAUI.Pages.UserPages.NewsPages.Views;
using LivePlay.Front.Infrastructure.HttpServices;
using CommunityToolkit.Maui.Core.Extensions;
using CommunityToolkit.Mvvm.ComponentModel;
using LivePlay.Front.MAUI.Pages.UserPages.AccountPages.Views;

namespace LivePlay.Front.MAUI.Pages.UserPages.AccountPages.ViewModels;

public partial class MainViewModel : BaseTapeViewModel
{
    private readonly UserHttpService _userService;
    private readonly NewsHttpService _newsService;

    [ObservableProperty]
    public ObservableCollection<News> _tapeItems = [];

    public override async Task Refresh()
    {
        GetMainPageInfo();
        await base.Refresh();
    }

    [RelayCommand]
    public async override Task GoToTapeItem(object item)
    {
        if (item is Tuple<object, ContentPage> tuple && tuple.Item1 is News newsItem && tuple.Item2 is ContentPage contentPage)
        {
            await Shell.Current.GoToAsync($"{nameof(CurrentNewsPage)}", new ShellNavigationQueryParameters { { $"{nameof(News)}Property", newsItem } });
        }
    }

    [RelayCommand]
    public async Task GoToQRPage()
    {
        await Shell.Current.GoToAsync($"{nameof(PersonalQRPage)}");
    }

    public MainViewModel(AppDesign designSettings, UserHttpService userHttpService, NewsHttpService newsHttpService) : base(designSettings)
    {
        _userService = userHttpService;
        _newsService = newsHttpService;
        GetMainPageInfo();
    }

    private async void GetMainPageInfo()
    {
        var (points, error) = await _userService.GetPoints();
        if (error != null) { ShowError(error); return; }
        (var news, error) = await _newsService.GetLastNews();
        if (error != null) { ShowError(error); return; }

        TapeItems = news?.ToObservableCollection() ?? [];
        DesignSettings.ChangeCountCoins?.Invoke(points);
    }
}
