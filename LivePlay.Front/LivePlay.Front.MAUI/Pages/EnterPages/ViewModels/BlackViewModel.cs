
using LivePlay.Front.Core.Enums;
using LivePlay.Front.Infrastructure.HttpServices;
using LivePlay.Front.Infrastructure.Interfaces;
using LivePlay.Front.MAUI.Abstracts;
using LivePlay.Front.MAUI.DeviceSettings;
using LivePlay.Front.MAUI.Pages.AdminPages.FeedbackPages.Views;
using LivePlay.Front.MAUI.Pages.EnterPages.Views;
using LivePlay.Front.MAUI.Pages.UserPages.AccountPages.Views;

namespace LivePlay.Front.MAUI.Pages.EnterPages.ViewModels;

public class BlackViewModel : BaseViewModel
{
    private readonly UserHttpService _userHttpService;
    private readonly AppStorage _appStorage;
    private readonly AppPermissions _permissions;

    public BlackViewModel(IServiceScopeFactory serviceScopeFactory) : base(serviceScopeFactory)
    {
        using var scope = serviceScopeFactory.CreateScope();
        _userHttpService = scope.ServiceProvider.GetRequiredService<UserHttpService>();
        _appStorage = scope.ServiceProvider.GetRequiredService<AppStorage>();
        _permissions = scope.ServiceProvider.GetRequiredService<AppPermissions>();
    }

    public async void MakeDecision(VisualElement[] visualElements)
    {
    RequestPermissions:
        bool havePermissions = await _permissions.GetPermission();
        if (!havePermissions)
        {
            if (await Shell.Current.DisplayAlert("Нет доступа к хранилищу", $"Предоставьте, пожалуйста, доступ к хранилищу", "ok", "no"))
                goto RequestPermissions;
            else
                Application.Current?.Quit();
        }

        StartMiddleLoading();
        var roles = await _userHttpService.CheckToken();
        StopLoading();

        if (roles.Length > 0)
        {
            if (roles.Length == 1 && roles[0] == Role.User)
                await Shell.Current.GoToAsync($"//{nameof(MainPage)}");
            else
                await Shell.Current.GoToAsync($"//{nameof(TapeFeedbackPage)}");
        }
        else
            await Shell.Current.GoToAsync($"//{nameof(EnterPage)}");

    }
}
