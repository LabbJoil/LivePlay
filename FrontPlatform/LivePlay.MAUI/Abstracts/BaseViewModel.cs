
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
    private CancellationTokenSource _stopLoadingTokenSourse = new();
    private ActionTimer? _loadingTimer;

    public AppDesign DesignSettings { get; } = designSettings;

    [ObservableProperty]
    public bool _isRefreshing;

    [RelayCommand]
    public void Refresh()
        => IsRefreshing = false;

    public virtual void ChangeColorBars(Color color, StatusBarColor statusBarColor, Color? secondColor = null)
    {
        DesignSettings.ChangeColorStatusBars?.Invoke(color, statusBarColor, secondColor);
    }

    protected void StartLoading()
    {
        _stopLoadingTokenSourse = new();
        _loadingTimer = new(DirectionAction.Down, null, GoToLoadingPage);
        _loadingTimer.Start(1500, 0, 500);
    }

    protected void StopLoading()
    {
        _loadingTimer?.Stop();
        _stopLoadingTokenSourse.Cancel();
    }

    protected static async void ShowError(DisplayError? displayError)
    {
        if (displayError != null && displayError.Title != string.Empty  && displayError.Message != string.Empty)
            await Shell.Current.DisplayAlert(displayError.Title, displayError.Message, "ok");
        else
            await Shell.Current.DisplayAlert("Ошибка сервера", "Что-то пошло не так", "ok");
    }

    public static void DeleteStackPages(int countPages = -1)
    {
        var stack = Shell.Current.Navigation.NavigationStack.ToArray();
        if (countPages > 0)
            for (int i = stack.Length - 1, countDeletePages = 0; countDeletePages < countPages && i > 0; i--, countDeletePages++)
                Shell.Current.Navigation.RemovePage(stack[i]);
        else
            for (int i = stack.Length - 1; i > 0; i--)
                Shell.Current.Navigation.RemovePage(stack[i]);
    }

    private void GoToLoadingPage()
    {
        var navigationParameter = new ShellNavigationQueryParameters
        {
            { "StopingAnimationSource", _stopLoadingTokenSourse },
        };

        Shell.Current.GoToAsync($"/{nameof(LoadingPage)}", navigationParameter);
    }
}
