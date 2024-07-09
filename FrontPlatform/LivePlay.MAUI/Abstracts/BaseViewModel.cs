
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using LivePlay.Front.Core.Enums;
using LivePlay.Front.Core.Models;
using LivePlay.Front.Infrastructure;
using LivePlay.Front.MAUI.DeviceSettings;
using LivePlay.Front.MAUI.Pages.SettingsPages.Views;

namespace LivePlay.Front.MAUI.Abstracts;

public abstract partial class BaseViewModel(AppDesign designSettings) : ObservableObject
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

    protected static async void ShowError(DisplayError? displayError)
    {
        if (displayError != null && displayError.Title != string.Empty  && displayError.Message != string.Empty)
            await Shell.Current.DisplayAlert(displayError.Title, displayError.Message, "ok");
        else
            await Shell.Current.DisplayAlert("Ошибка сервера", "Что-то пошло не так", "ok");
    }

    protected static void DeleteStackPages()
    {
        var stack = Shell.Current.Navigation.NavigationStack.ToArray();
        for (int i = stack.Length - 1; i > 0; i--)
            Shell.Current.Navigation.RemovePage(stack[i]);
    }

    private void GoToLoadingPage()
    {
        var navigationParameter = new ShellNavigationQueryParameters
        {
            { "StopingAnimationSource", StopLoadingTokenSourse },
        };

        Shell.Current.GoToAsync($"/{nameof(LoadingPage)}", navigationParameter);
    }
}
