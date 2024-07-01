﻿
using CommunityToolkit.Mvvm.Input;
using LivePlay.Front.MAUI.Abstracts;
using LivePlay.Front.MAUI.DeviceSettings;
using LivePlay.Front.MAUI.Pages.Reward;

namespace LivePlay.Front.MAUI.Pages.UserPages.CouponPages.ViewModels;

public partial class MainRewardPageViewModel(AppDesign designSettings) : BaseViewModel(designSettings)
{
    [RelayCommand]
    public async Task GoToCoupon()
    {
        await Shell.Current.GoToAsync($"{nameof(CouponInfoPage)}");
    }
}
