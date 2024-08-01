
using CommunityToolkit.Mvvm.ComponentModel;
using LivePlay.Front.Infrastructure.HttpServices;
using LivePlay.Front.Infrastructure.HttpServices.QuestHttpServices;
using LivePlay.Front.MAUI.Abstracts;
using LivePlay.Front.MAUI.DeviceSettings;
using LivePlay.Front.MAUI.Models;
using ZXing.QrCode.Internal;

namespace LivePlay.Front.MAUI.Pages.UserPages.AccountPages.ViewModels;

public partial class PersonalQRViewModel : BaseViewModel
{
    private readonly UserHttpService _userHttpService;
    private readonly AppStorage _appStorage;

    [ObservableProperty]
    private UserQRData? _qRData;

    [ObservableProperty]
    private string _generatedDate = "null";

    [ObservableProperty]
    public LinearGradientBrush _gradientBrush = new()
    {
        StartPoint = new Point(0, 1),
        EndPoint = new Point(1, 0),
        GradientStops =
        [
            new GradientStop { Color = Colors.Green, Offset = 0 },
            new GradientStop { Color = Colors.Blue, Offset = 0.3f },
            new GradientStop { Color = Colors.Red, Offset = 1 },
        ]
    };

    public PersonalQRViewModel(IServiceScopeFactory serviceScopeFactory) : base(serviceScopeFactory)
    {
        using var scope = serviceScopeFactory.CreateScope();
        _userHttpService = scope.ServiceProvider.GetRequiredService<UserHttpService>();
        _appStorage = scope.ServiceProvider.GetRequiredService<AppStorage>();
    }

    public override async Task Refresh()
    {
        StartMiddleLoading();
        await UpdateQRData();
        StopLoading();
        await base.Refresh();
    }

    public async void FirstLoadQRData(VisualElement[] visualElements)
    {
        var qrData = _appStorage.GetPreference<UserQRData>(nameof(UserQRData));
        //var t = DateTime.Today.;
        if (qrData != null && qrData.GeneratedDate < DateTime.Today.AddHours(-12))
        {
            SetQRData(qrData);
            return;
        }
        StartMiddleLoading();
        await UpdateQRData();
        StopLoading();
    }

    private async Task UpdateQRData()
    {
        var qrCode = await GetNewQRCode();
        if (qrCode == null)
            return;     // TODO: грусный смайлик вместо qrCode :(
        SetQRData(new (qrCode, DateTime.Now));
    }

    private async Task<string?> GetNewQRCode()
    {
        var (newQRCode, error) = await _userHttpService.GetPersonalQR();
        if (error != null)
            ShowError(error);
        return newQRCode;
    }

    private void SetQRData(UserQRData newQRData)
    {
        QRData = newQRData;
        GeneratedDate = newQRData.GeneratedDate.ToString("dd.MM.yyyy");
        _appStorage.SavePreference(nameof(UserQRData), QRData);
    }
}
