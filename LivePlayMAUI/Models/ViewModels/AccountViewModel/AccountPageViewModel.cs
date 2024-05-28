using CommunityToolkit.Mvvm.Input;
using LivePlayMAUI.Abstracts;
using LivePlayMAUI.Models.Domain;
using LivePlayMAUI.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LivePlayMAUI.Models.ViewModels;

public partial class AccountPageViewModel : MainTapeViewModel
{
    public ObservableCollection<CouponItem> CouponItems { get; set; }

    [RelayCommand]
    public async override Task GoToTapeItem(object item)
    {
        if (item is Tuple<object, ContentPage> tuple && tuple.Item1 is CouponItem couponItem && tuple.Item2 is ContentPage contentPage)
        {
            //var currentPageViewModel = new CurrentNewsPageViewModel(_appSettings, couponItem ?? new CouponItem());
            //await contentPage.Navigation.PushAsync(new CurrentNewsPage(currentPageViewModel));
        }
    }

    public AccountPageViewModel(OverApplicationSettings appSettings) : base(appSettings)
    {
        // запрос к серверу
    }
}
