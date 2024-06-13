
using CommunityToolkit.Mvvm.Input;
using LivePlay.Front.MAUI.Abstracts;
using LivePlay.Front.MAUI.Models.Domain;
using LivePlay.Front.MAUI.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LivePlay.Front.MAUI.ViewModels.AccountViewModels;

public partial class ProfileViewModel : BaseViewModel
{
    public ObservableCollection<CouponItem> CouponItems { get; set; }

    public IReadOnlyList<ChoicePanelItem> ProfileItems { get; set; } = [
        new ChoicePanelItem { Icon = "profile_light.svg", Text="Информация" },
        new ChoicePanelItem { Icon = "coupons_light.svg", Text="Мои купоны" }
        ];

    public ProfileViewModel(DeviceDesignSettings designSettings) : base(designSettings)
    {
        // запрос к серверу
    }
}
