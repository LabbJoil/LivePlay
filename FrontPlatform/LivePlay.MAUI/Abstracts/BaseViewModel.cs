
using CommunityToolkit.Mvvm.ComponentModel;
using LivePlay.Front.MAUI.DeviceSettings;
using CommunityToolkit.Mvvm.Input;
using LivePlay.Front.Core.Enums;
using LivePlay.Front.Application.Models.ResponseModel;
using LivePlay.Front.Application.Contracts.ResponseModel;
using LivePlay.Front.Application;

namespace LivePlay.Front.MAUI.Abstracts;

public partial class BaseViewModel(AppDesign designSettings) : ObservableObject
{
    public AppDesign DesignSettings = designSettings;

    private CancellationTokenSource StopLoadingTokenSourse = new();
    private ActionTimer? LoadingTimer;

    [ObservableProperty]
    public bool _isRefreshing;

    [RelayCommand]
    public void Refresh()
    {
        IsRefreshing = false;
    }

    public virtual void ChangeColorBars(Color color, StatusBarColor statusBarColor, Color? secondColor = null)
    {
        DesignSettings.ChangeColorStatusBars?.Invoke(color, statusBarColor, secondColor);
    }

    protected void StartLoading()
    {
        StopLoadingTokenSourse = new();
        LoadingTimer = new(DirectionAction.Down, null, GoToLoadingPage);
        LoadingTimer.Start(1500, 0, 500);
    }

    protected void StopLoading()
    {
        LoadingTimer?.Stop();
        StopLoadingTokenSourse.Cancel();
    }

    protected static async Task<(bool, T?)> ResponseProcessing<T>(BaseResponse<T> response)
    {
        if (response.IsSuccess && response.Data is T goodResponse)
            return (true, goodResponse);
        else if (response.Error is ErrorResponse error)
            await Shell.Current.DisplayAlert(error.ErrorCode, error.Message, "ok");
        else
            await Shell.Current.DisplayAlert("Ошибка сервера", "Что-то пошло не так", "ok");       // INFO: возможно вынести как отдельную констнту или в appsettings
        return (true, default);
    }

    private void GoToLoadingPage()
    {
        var navigationParameter = new ShellNavigationQueryParameters
        {
            { "StopingAnimationSource", StopLoadingTokenSourse },
        };

        Shell.Current.GoToAsync("/LoadingPage", navigationParameter);   // INFO: Возможно стоит перенести в MAUI
    }
}
