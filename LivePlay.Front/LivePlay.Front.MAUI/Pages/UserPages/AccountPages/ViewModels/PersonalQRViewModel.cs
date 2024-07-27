
using CommunityToolkit.Mvvm.ComponentModel;
using LivePlay.Front.Infrastructure.HttpServices;
using LivePlay.Front.Infrastructure.HttpServices.QuestHttpServices;
using LivePlay.Front.MAUI.Abstracts;
using LivePlay.Front.MAUI.DeviceSettings;
using LivePlay.Front.MAUI.Models;

namespace LivePlay.Front.MAUI.Pages.UserPages.AccountPages.ViewModels;

public partial class PersonalQRViewModel : BaseViewModel
{
    private readonly UserHttpService _userHttpService;
    private readonly AppStorage _appStorage;

    [ObservableProperty]
    private UserQRData? _qRData;

    [ObservableProperty]
    private string _generatedDate = "null";

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
        if (qrData != null && qrData.GeneratedDate < DateTime.Today)
        {
            SetQRData(qrData);
            return;
        }

        await StartFirstLoading(visualElements);
        await UpdateQRData();
        StopLoading();
    }

    private async Task UpdateQRData()
    {
        var qrCode = await GetNewQRCode();
        if (qrCode == null)
            return;     // TODO: грусный смайлик вместо qrCode :(
        SetQRData(new (qrCode, DateTime.Now));

        _appStorage.SavePreference(nameof(UserQRData), qrCode);
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
    }
}
