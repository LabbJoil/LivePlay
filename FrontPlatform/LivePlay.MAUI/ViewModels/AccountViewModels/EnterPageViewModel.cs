
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using LivePlay.Front.Application;
using LivePlay.Front.Application.Abstracts;
using LivePlay.Front.Application.DeviceSettings;
using LivePlay.Front.Application.Models.ResponseModel;
using LivePlay.Front.Application.Services;
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

    //[ObservableProperty]
    //public string _email = string.Empty;

    //[ObservableProperty]
    //public string _password = string.Empty;

    private uint NumberRegistratrtion = 0;

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

        

        await Shell.Current.GoToAsync($"//{nameof(MainPage)}");

        //if (Email == "tre@gmail.com")
        //    await NavigateLoading.GoToRootPage($"//{nameof(TapeFeedbackPage)}");
        //else if (Email == "lio@gmail.com")
        //    await NavigateLoading.GoToRootPage($"//{nameof(TapeNewsPage)}");
        //else
        //    await Shell.Current.DisplayAlert("Нет доступа", $"Неправильный логин или пароль", "ok");
    }

    [RelayCommand]
    public async Task VerifyEmail(object obj)
    {
        if (obj is Tuple<object, object> tuple && tuple.Item1 is string email && tuple.Item2 is EnterPage enterPage)
        {
            StartLoading();
            var response = await UserService.VerifyEmail(email);
            StopLoading();

            NumberRegistratrtion = await ResponseProcessing(response);
            if (NumberRegistratrtion == 0)
                return;

            var timerActions = await enterPage.VerifyEmailFrontProcess();

            SendCodeTimer = new(DirectionAction.Down, timerActions.Item1, timerActions.Item2);
            SendCodeTimer.Start(5000, 0);
        }
    }

    [RelayCommand]
    public async Task CheckCodeEmail(string code)
    {
        StartLoading();
        var response = await UserService.VerifyCodeEmail(code);
        StopLoading();

        //NumberRegistratrtion = await ResponseProcessing(response);
        //if (NumberRegistratrtion == 0)
        //    return;

        //SendCodeTimer = new(DirectionAction.Down, enterPage.PrintTimer, enterPage.EndTimer);
        //SendCodeTimer.Start(5, 1000);
    }
}
