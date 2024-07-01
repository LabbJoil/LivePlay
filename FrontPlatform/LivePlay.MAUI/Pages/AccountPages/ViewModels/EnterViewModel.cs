
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using LivePlay.Front.Application.HttpServices;
using LivePlay.Front.Core.Enums;
using LivePlay.Front.Core.Models;
using LivePlay.Front.Infrastructure;
using LivePlay.Front.MAUI.Abstracts;
using LivePlay.Front.MAUI.DeviceSettings;
using LivePlay.Front.MAUI.Pages.AccountPages.Views;
using LivePlay.Front.MAUI.Pages.AdminPages.FeedbackPages.Views;
using LivePlay.Front.MAUI.Pages.UserPages.AccountPages.Views;

namespace LivePlay.Front.MAUI.Pages.AccountPages.ViewModels;

public partial class EnterViewModel(AppDesign designSettings, AppPermissions permissions, UserHttpService userHttpService) : BaseViewModel(designSettings)
{
    private AppPermissions Permissions { get; } = permissions;
    private UserHttpService UserService { get; set; } = userHttpService;
    private ActionTimer? SendCodeTimer;

    private uint NumberRegistratrtion = 0;

    [ObservableProperty]
    public User _enterUser = new();

    [RelayCommand]
    public async Task LoginUser()
    {
        RequestPermissions:
        bool havePermissions = await Permissions.GetPermission();
        if (!havePermissions)
        {
            if (await Shell.Current.DisplayAlert("Нет доступа к хранилищу", $"Предоставьте, пожалуйста, доступ к хранилищу", "ok", "no"))
                goto RequestPermissions;
            else
                return;
        }

        if (_enterUser.Email == "tre@gmail.com")
            await Shell.Current.GoToAsync($"//{nameof(TapeFeedbackPage)}");
        else if (_enterUser.Email == "lio@gmail.com")
            await Shell.Current.GoToAsync($"//{nameof(MainPage)}");
        else if(_enterUser.Email == "111")
        {
            Preferences.Clear();
            Preferences.Remove($"{nameof(Quest)}");
            Preferences.Remove($"{nameof(QuestionQuest)}");
        }
        else
            await Shell.Current.DisplayAlert("Нет доступа", $"Неправильный логин или пароль", "ok");
    }

    [RelayCommand]
    public async Task VerifyEmail(EnterPage enterPage)
    {
        StartLoading();
        var response = await UserService.VerifyEmail(EnterUser.Email);
        StopLoading();

        (var ok, NumberRegistratrtion) = await ResponseProcessing(response);
        if (!ok)
            return;

        var timerActions = await enterPage.VerifyEmailFrontProcess();
        SendCodeTimer = new(DirectionAction.Down, timerActions.Item1, timerActions.Item2);
        SendCodeTimer.Start(5000, 0);
    }

    [RelayCommand]
    public async Task CheckCodeEmail(object obj)
    {
        if (obj is Tuple<object, object> tuple && tuple.Item1 is string code && tuple.Item2 is EnterPage enterPage)
        {
            //StartLoading();
            //var response = await UserService.VerifyCodeEmail(NumberRegistratrtion, code);
            //StopLoading();

            //var ok = await ResponseProcessing(response);
            //if (!ok.Item1)
            //    return;

            SendCodeTimer?.Stop();
            enterPage.CheckCodeEmailFrontProcess();
        }
    }
}
