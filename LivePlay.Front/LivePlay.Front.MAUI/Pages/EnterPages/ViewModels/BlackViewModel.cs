
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

    public BlackViewModel(IServiceScopeFactory serviceScopeFactory) : base(serviceScopeFactory)
    {
        using var scope = serviceScopeFactory.CreateScope();
        _userHttpService = scope.ServiceProvider.GetRequiredService<UserHttpService>();
        _appStorage = scope.ServiceProvider.GetRequiredService<AppStorage>();
    }

    public async void MakeDecision(VisualElement[] visualElements)
    {
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
