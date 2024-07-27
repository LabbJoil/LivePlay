
using LivePlay.Front.MAUI.DeviceSettings;
using LivePlay.Front.MAUI.Pages.SettingsPages.ViewModels;
using LivePlay.Front.Core.Enums;

namespace LivePlay.Front.MAUI.Pages.SettingsPages.Views;

public partial class MiddleLoadingPage : ContentPage, IQueryAttributable
{
    private CancellationTokenSource? _stopingAnimationSource;
    private readonly MiddleLoadingViewModel _middleLoadingVM;

    public MiddleLoadingPage(MiddleLoadingViewModel middleLoadingVM)
	{
		InitializeComponent();
        _middleLoadingVM = middleLoadingVM;

    }

    public void ApplyQueryAttributes(IDictionary<string, object> query)
    {
        if (query.TryGetValue($"{nameof(CancellationTokenSource)}Property", out object? cts) && cts is CancellationTokenSource cancellationTokenSource)
        {
            _stopingAnimationSource = cancellationTokenSource;
            LoadingAI.IsRunning = true;
        }
        else
            throw new Exception("Not all parameters were passed");
    }

    private async void ContentPage_Loaded(object sender, EventArgs e)
        => await WaitingDownload();

    private async Task WaitingDownload()
    {
        while (_stopingAnimationSource != null && !_stopingAnimationSource.IsCancellationRequested)
            await Task.Delay(30);
        await Shell.Current.GoToAsync($"..");
    }

    private void ContentPage_Appearing(object sender, EventArgs e)
    {
        _middleLoadingVM.ChangeColorBars(ShadowRectangle.BackgroundColor, StatusBarColor.BarReplay);
    }
}