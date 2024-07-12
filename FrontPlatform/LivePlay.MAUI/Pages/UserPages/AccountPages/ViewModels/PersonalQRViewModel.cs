
using CommunityToolkit.Mvvm.ComponentModel;
using LivePlay.Front.MAUI.Abstracts;
using LivePlay.Front.MAUI.DeviceSettings;

namespace LivePlay.Front.MAUI.Pages.UserPages.AccountPages.ViewModels;

public partial class PersonalQRViewModel(AppDesign appDesign) : BaseViewModel(appDesign)
{
    [ObservableProperty]
    private readonly string _qrCode = string.Empty;
}
