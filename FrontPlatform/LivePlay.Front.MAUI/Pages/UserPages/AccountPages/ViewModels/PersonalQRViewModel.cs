
using CommunityToolkit.Mvvm.ComponentModel;
using LivePlay.Front.Infrastructure.HttpServices;
using LivePlay.Front.MAUI.Abstracts;
using LivePlay.Front.MAUI.DeviceSettings;
using LivePlay.Front.MAUI.Models;

namespace LivePlay.Front.MAUI.Pages.UserPages.AccountPages.ViewModels;

public partial class PersonalQRViewModel(AppDesign appDesign, UserHttpService userHttpService, AppStorage appStorage) : BaseViewModel(appDesign)
{
    private readonly UserHttpService _userHttpService = userHttpService;
    private readonly AppStorage _appStorage = appStorage;

    [ObservableProperty]
    private UserQRData? _qRData;

    public override async Task Refresh()
    {
        StartMiddleLoading();
        await UpdateQRData();
        StopLoading();
        await base.Refresh();
    }

    public async void FirstLoadQRData(VisualElement[] visualElements)
    {
        StartFirstLoading(visualElements);
        QRData = _appStorage.GetPreference<UserQRData>(nameof(UserQRData));
        if (QRData != null)
            return;

        await UpdateQRData();
        StopLoading();
    }

    public async Task UpdateQRData()
    {
        var qrCode = await GetNewQRCode();
        if (qrCode == null)
            return;     // TODO: грусный смайлик вместо qrCode :(
        QRData = new(qrCode, DateTime.Now);
        _appStorage.SavePreference(nameof(UserQRData), QRData);
    }

    private async Task<string?> GetNewQRCode()
    {
        var (newQRCode, error) = await _userHttpService.GetPersonalQR();
        if (error != null)
            ShowError(error);
        return newQRCode;
    }
}
