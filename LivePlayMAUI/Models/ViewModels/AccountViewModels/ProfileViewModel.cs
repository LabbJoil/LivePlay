﻿using CommunityToolkit.Mvvm.Input;
using LivePlayMAUI.Abstracts;
using LivePlayMAUI.Models.Domain;
using LivePlayMAUI.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LivePlayMAUI.Models.ViewModels.AccountViewModels;

public partial class ProfileViewModel : MainTapeViewModel
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

    public ProfileViewModel(DeviceDesignSettings designSettings) : base(designSettings)
    {
        // запрос к серверу
    }
}