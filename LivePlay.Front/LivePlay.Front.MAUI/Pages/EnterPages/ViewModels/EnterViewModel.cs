
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using LivePlay.Front.Infrastructure.HttpServices;
using LivePlay.Front.Core.Enums;
using LivePlay.Front.Core.Models;
using LivePlay.Front.Infrastructure;
using LivePlay.Front.MAUI.Abstracts;
using LivePlay.Front.MAUI.DeviceSettings;
using LivePlay.Front.MAUI.Pages.EnterPages.Views;
using LivePlay.Front.MAUI.Pages.AdminPages.FeedbackPages.Views;
using LivePlay.Front.MAUI.Pages.UserPages.AccountPages.Views;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace LivePlay.Front.MAUI.Pages.EnterPages.ViewModels;

public partial class EnterViewModel : BaseViewModel
{
    private readonly UserHttpService _userService;
    private ActionTimer? _sendCodeTimer;
    private uint _numberRegistratrtion = 0;

    [ObservableProperty]
    public User _enterUser = new();

    public EnterViewModel(IServiceScopeFactory serviceScopeFactory) : base(serviceScopeFactory)
    {
        using var scope = serviceScopeFactory.CreateScope();
        _userService = scope.ServiceProvider.GetRequiredService<UserHttpService>();
    }

    [RelayCommand]
    public async Task LoginUser()
    {
        StartMiddleLoading();
        var (roles, error) = await _userService.Login(EnterUser.Email, EnterUser.Password);

        if (roles.Length > 0)
        {
            DeleteStackPages();
            if (roles.Length == 1 && roles[0] == Role.User)
                await Shell.Current.GoToAsync($"//{nameof(MainPage)}");
            else
                await Shell.Current.GoToAsync($"//{nameof(TapeFeedbackPage)}");
        }
        else
            ShowError(error);
        StopLoading();
    }

    [RelayCommand]
    public async Task VerifyEmail(EnterPage enterPage)
    {
        StartMiddleLoading();
        (_numberRegistratrtion, var error) = await _userService.VerifyEmail(EnterUser.Email);
        StopLoading();

        if (error != null) { ShowError(error); return; }

        var (printTimer, endTimer) = await enterPage.VerifyEmailFrontProcess();
        _sendCodeTimer = new(DirectionAction.Down, printTimer, endTimer);
        _sendCodeTimer.Start(5000, 0);
    }

    [RelayCommand]
    public async Task CheckCodeEmail(object obj)
    {
        if (obj is Tuple<object, object> tuple && tuple.Item1 is string code && tuple.Item2 is EnterPage enterPage)
        {
            StartMiddleLoading();
            var error = await _userService.CheckEmailCode(_numberRegistratrtion, code);
            StopLoading();

            if (error != null) { ShowError(error); return; }

            _sendCodeTimer?.Stop();
            await enterPage.FillUserInfoFrontProcess();
        }
    }

    [RelayCommand]
    public async Task SendCodeAgain(EnterPage enterPage)
    {
        StartMiddleLoading();
        var error = await _userService.SendCodeAgain(_numberRegistratrtion);
        StopLoading();

        if (error != null) { ShowError(error); return; }

        var (printTimer, endTimer) = enterPage.GetPrintEndTimerActions();
        _sendCodeTimer = new(DirectionAction.Down, printTimer, endTimer);
        _sendCodeTimer.Start(5000, 0);
    }

    [RelayCommand]
    public async Task SendRegistrationInfo(EnterPage enterPage)
    {
        StartMiddleLoading();
        var error = await _userService.Registration(_numberRegistratrtion, EnterUser);
        StopLoading();

        if (error != null) { ShowError(error); return; }

        await enterPage.SwitchButtonTappedButton1();
    }
}
