
using LivePlay.Front.Core.Enums;
using LivePlay.Front.Infrastructure.HttpServices;
using LivePlay.Front.Infrastructure.Interfaces;
using LivePlay.Front.MAUI.Abstracts;
using LivePlay.Front.MAUI.DeviceSettings;
using LivePlay.Front.MAUI.Pages.AdminPages.FeedbackPages.Views;
using LivePlay.Front.MAUI.Pages.EnterPages.Views;
using LivePlay.Front.MAUI.Pages.UserPages.AccountPages.Views;

namespace LivePlay.Front.MAUI.Pages.EnterPages.ViewModels;

public class BlackViewModel(AppDesign appDesign, AppStorage appStorage, UserHttpService userHttpService) : BaseViewModel(appDesign)
{
    private readonly UserHttpService _userHttpService = userHttpService;
    private readonly AppStorage _appStorage = appStorage;

    public async void MakeDecision(VisualElement[] visualElements)
    {
        //_appStorage.GetPreference<string> = 
        StartFirstLoading(visualElements);
        await Task.Delay(10500);
        var roles = await _userHttpService.CheckToken();
        await StopLoading();

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
