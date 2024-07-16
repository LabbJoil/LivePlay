
using Camera.MAUI;
using CommunityToolkit.Mvvm.ComponentModel;
using LivePlay.Front.Infrastructure.HttpServices;
using LivePlay.Front.MAUI.Abstracts;
using LivePlay.Front.MAUI.DeviceSettings;
using LivePlay.Front.MAUI.Models;
using LivePlay.Front.MAUI.Pages.UserPages.AccountPages.Views;
using Microsoft.Maui.Controls;
using Microsoft.Maui.Controls.Shapes;
using Microsoft.Maui.Layouts;

namespace LivePlay.Front.MAUI.Pages.UserPages.AccountPages.ViewModels;

public partial class PersonalQRViewModel(AppDesign appDesign, UserHttpService userHttpService, AppStorage appStorage) : BaseViewModel(appDesign)
{
    private readonly UserHttpService _userHttpService = userHttpService;
    private readonly AppStorage _appStorage = appStorage;

    [ObservableProperty]
    private UserQRData? _qRData;

    public override async Task Refresh()
    {
        await UpdateQRData();
        await base.Refresh();
    }

    public async void FirstLoadQRData(PersonalQRPage personalQRPage)
    {
        StartLoading(personalQRPage);

        QRData = _appStorage.GetPreference<UserQRData>(nameof(UserQRData));
        if (QRData != null)
            return;

        await UpdateQRData();
        //StopLoading();
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
        //StartLoading();
        var (newQRCode, error) = await _userHttpService.GetPersonalQR();
        //StopLoading();
        if (error != null)
            ShowError(error);
        return newQRCode;
    }







    public CancellationTokenSource StopingAnimationSource { get; set; } = new();


    

}
