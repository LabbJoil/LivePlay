
namespace LivePlay.Front.MAUI.Pages.SettingsPages.Views;

public partial class MiddleLoadingPage : ContentPage
{
    private CancellationTokenSource? _stopingAnimationSource;

    public MiddleLoadingPage()
	{
		InitializeComponent();
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
        while (_stopingAnimationSource != null)
            await Task.Delay(300);
        LoadingAI.IsRunning = false;
    }
}