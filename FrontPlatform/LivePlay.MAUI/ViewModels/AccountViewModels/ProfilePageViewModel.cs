
using LivePlay.Front.MAUI.Abstracts;
using LivePlay.Front.MAUI.DeviceSettings;
using LivePlay.Front.Core.Models;
using System.Collections.ObjectModel;

namespace LivePlay.Front.MAUI.ViewModels.AccountViewModels;

public partial class ProfilePageViewModel : BaseViewModel
{
    public ObservableCollection<CouponItem> CouponItems { get; set; }

    public IReadOnlyList<ChoicePanelItem> ProfileItems { get; set; } = [
        new ChoicePanelItem { Icon = "profile_light.svg", Text="Информация" },
        new ChoicePanelItem { Icon = "coupons_light.svg", Text="Мои купоны" }
        ];

    public ProfilePageViewModel(AppDesign designSettings) : base(designSettings)
    {
        // запрос к серверу
    }
}
