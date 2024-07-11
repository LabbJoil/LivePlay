
using LivePlay.Front.MAUI.Abstracts;
using LivePlay.Front.MAUI.DeviceSettings;
using LivePlay.Front.Core.Models;
using System.Collections.ObjectModel;
using LivePlay.Front.MAUI.Models;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using LivePlay.Front.Infrastructure.HttpServices;
using LivePlay.Front.MAUI.Pages.EnterPages.Views;

namespace LivePlay.Front.MAUI.Pages.UserPages.AccountPages.ViewModels;

public partial class ProfileViewModel : BaseViewModel
{
    private readonly UserHttpService _userHttpService;

    public ObservableCollection<Coupon> CouponItems { get; set; } = [];
    public IReadOnlyList<ChoicePanelItem> ProfileItems { get; } = [
        new ChoicePanelItem { Icon = "profile_light.svg", Text="Информация" },
        new ChoicePanelItem { Icon = "coupons_light.svg", Text="Мои купоны" }
        ];

    public ProfileViewModel(AppDesign designSettings, UserHttpService userHttpService) : base(designSettings)
    {
        _userHttpService = userHttpService;
        // запрос к серверу
    }

    [RelayCommand]
    public async Task Logout()
    {
        _userHttpService.Logout();
        await Shell.Current.GoToAsync($"//{nameof(EnterPage)}");
    }
}
