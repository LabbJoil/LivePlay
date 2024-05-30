﻿using CommunityToolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LivePlayMAUI.Services;
using CommunityToolkit.Mvvm.Input;
using LivePlayMAUI.Enum;

namespace LivePlayMAUI.Abstracts;

public partial class BaseViewModel(DeviceDesignSettings designSettings) : ObservableObject
{
    public DeviceDesignSettings DesignSettings = designSettings;

    [ObservableProperty]
    public bool _isRefreshing;

    [RelayCommand]
    public void Refresh()
    {
        IsRefreshing = false;
    }

    public virtual void ChangeColorBars(Color color, StatusBarColor statusBarColor, Color? secondColor = null)
    {
        DesignSettings.ChangeColorStatusBars?.Invoke(color, statusBarColor, secondColor);
    }
}
