
using LivePlay.Front.MAUI.Abstracts;
using LivePlay.Front.MAUI.DeviceSettings;
using LivePlay.Front.Core.Models;
using System.Collections.ObjectModel;
using LivePlay.Front.MAUI.Models;

namespace LivePlay.Front.MAUI.Pages.UserPages.AccountPages.ViewModels;

public partial class ProfileViewModel : BaseViewModel
{
    public ObservableCollection<Coupon> CouponItems { get; set; }

    public IReadOnlyList<ChoicePanelItem> ProfileItems { get; set; } = [
        new ChoicePanelItem { Icon = "profile_light.svg", Text="Информация" },
        new ChoicePanelItem { Icon = "coupons_light.svg", Text="Мои купоны" }
        ];

    public ProfileViewModel(AppDesign designSettings) : base(designSettings)
    {
        // запрос к серверу
    }
}
