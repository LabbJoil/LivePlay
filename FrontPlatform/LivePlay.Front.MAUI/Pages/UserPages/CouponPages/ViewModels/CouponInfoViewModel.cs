
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using LivePlay.Front.Core.Models;
using LivePlay.Front.MAUI.Abstracts;
using LivePlay.Front.MAUI.DeviceSettings;
using LivePlay.Front.MAUI.Pages.UserPages.CouponPages.Views;

namespace LivePlay.Front.MAUI.Pages.UserPages.CouponPages.ViewModels;

public partial class CouponInfoViewModel(AppDesign designSettings) : BaseViewModel(designSettings)
{
    [ObservableProperty]
    public Coupon _thisCoupon = new()
    {
        Title = "Скидка на номер 10%",
        DescriptionFull = "В сети отелей Wone Hotels\r\nPalace Bridge\r\nCosmos SPb Olympia Garden Hotel\r\nVasilievsky Hotel\r\nпредоставляется скидка 10% на бронирование номеров эконом-класса",
        Image = File.ReadAllBytes(@"/storage/emulated/0/Download/hotelnumber.jpg"),
        CouponS = "nif913gffg3",
        Price = 200
    };

    [RelayCommand]
    public void BuyCoupon()
    {
        DesignSettings.ChangeCountCoins(0);
        Shell.Current.DisplayAlert("Купон", "Успешно куплен купон", "ok");
        Shell.Current.GoToAsync($"//{nameof(MyCouponsPage)}");
    }
}
