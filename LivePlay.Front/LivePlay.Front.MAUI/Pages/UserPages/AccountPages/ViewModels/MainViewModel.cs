
using CommunityToolkit.Mvvm.Input;
using LivePlay.Front.MAUI.Abstracts;
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
    private readonly IServiceScopeFactory _serviceScopeFactory;
    private readonly UserHttpService _userService;
    private readonly NewsHttpService _newsService;

    [ObservableProperty]
    public ObservableCollection<News> _tapeItems = [];

    public MainViewModel(IServiceScopeFactory serviceScopeFactory) : base(serviceScopeFactory)
    {
        _serviceScopeFactory = serviceScopeFactory;
        using var scope = serviceScopeFactory.CreateScope();
        _userService = scope.ServiceProvider.GetRequiredService<UserHttpService>();
        _newsService = scope.ServiceProvider.GetRequiredService<NewsHttpService>();
        GetMainPageInfo();
    }

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
    public async Task GoToQRPage(Color mainGridColor)
    {
        using var scope = _serviceScopeFactory.CreateScope();
        var personalQRVM = scope.ServiceProvider.GetRequiredService<PersonalQRViewModel>();
        var personalQR = new PersonalQRPage(personalQRVM);
        personalQR.Unloaded += (object? sender, EventArgs e)
            => ChangeColorBars(mainGridColor, barReplay: false);
        await personalQR.ShowAsync();
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
