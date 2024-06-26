
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using LivePlay.Front.Application;
using LivePlay.Front.MAUI.Abstracts;
using LivePlay.Front.MAUI.DeviceSettings;
using LivePlay.Front.Application.Models.ResponseModel;
using LivePlay.Front.MAUI.Services;
using LivePlay.Front.Core.Enums;
using LivePlay.Front.Core.Models;
using LivePlay.Front.MAUI.Pages;
using LivePlay.Front.MAUI.Pages.AdminPages;
using LivePlay.Front.MAUI.Services.HttpServices;

namespace LivePlay.Front.MAUI.Models.ViewModels.AccountViewModels;

public partial class EnterPageViewModel(AppDesign designSettings, AppPermissions permissions, UserHttpService userHttpService) : BaseViewModel(designSettings)
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

        

        await Shell.Current.GoToAsync($"//{nameof(TapeFeedbackPage)}");

        //if (Email == "tre@gmail.com")
        //    await NavigateLoading.GoToRootPage($"//{nameof(TapeFeedbackPage)}");
        //else if (Email == "lio@gmail.com")
        //    await NavigateLoading.GoToRootPage($"//{nameof(MainPage)}");
        //else
        //    await Shell.Current.DisplayAlert("Нет доступа", $"Неправильный логин или пароль", "ok");
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
