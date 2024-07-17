
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using LivePlay.Front.Core.Enums;
using LivePlay.Front.Core.Models;
using LivePlay.Front.Infrastructure;
using LivePlay.Front.MAUI.DeviceSettings;
using LivePlay.Front.MAUI.Pages.SettingsPages.Views;
using System.Text.Json;

namespace LivePlay.Front.MAUI.Abstracts;

public abstract partial class BaseViewModel(AppDesign designSettings) : ObservableObject
{
    private CancellationTokenSource? _stopLoadingTokenSourse;
    //private ActionTimer? _loadingTimer;

    public AppDesign DesignSettings { get; } = designSettings;

    [ObservableProperty]
    public bool _isRefreshing;

    [RelayCommand]
    public virtual async Task Refresh()
    {
        IsRefreshing = false;
        await Task.Delay(0);
    }

    public virtual void ChangeColorBars(Color color, StatusBarColor statusBarColor, Color? secondColor = null)
    {
        DesignSettings.ChangeColorStatusBars?.Invoke(color, statusBarColor, secondColor);
    }

    protected void StartLoading() // TODO: DEPRECATED
    {
    }

    protected async void StartLoading(VisualElement[] visualElements)
    {
        _stopLoadingTokenSourse = new();
        var navigationParameter = new ShellNavigationQueryParameters
        {
            { $"{nameof(CancellationTokenSource)}Property", _stopLoadingTokenSourse },
            { $"{nameof(VisualElement)}sProperty", visualElements }
        };

        await Shell.Current.GoToAsync($"{nameof(LoadingPage)}", navigationParameter);
    }

    protected void StopLoading()
        => _stopLoadingTokenSourse?.Cancel();

    protected static async void ShowError(DisplayError? displayError)
    {
        if (displayError != null && displayError.Title != string.Empty  && displayError.Message != string.Empty)
            await Shell.Current.DisplayAlert(displayError.Title, displayError.Message, "ok");
        else
            await Shell.Current.DisplayAlert("Ошибка сервера", "Что-то пошло не так", "ok");
    }

    protected static void DeleteStackPages(int countPages = -1)
    {
        var stack = Shell.Current.Navigation.NavigationStack.ToArray();
        if (countPages > 0)
            for (int i = stack.Length - 1, countDeletePages = 0; countDeletePages < countPages && i > 0; i--, countDeletePages++)
                Shell.Current.Navigation.RemovePage(stack[i]);
        else
            for (int i = stack.Length - 1; i > 0; i--)
                Shell.Current.Navigation.RemovePage(stack[i]);
    }

    private void GoToLoadingPage(ContentPage contentPage)
    {
        _stopLoadingTokenSourse = new();
        var navigationParameter = new ShellNavigationQueryParameters
        {
            { "StopingAnimationSource", _stopLoadingTokenSourse },
            { $"{nameof(ContentPage)}Property", contentPage }
        };

        Shell.Current.GoToAsync($"/{nameof(LoadingPage)}", navigationParameter);
    }
}
