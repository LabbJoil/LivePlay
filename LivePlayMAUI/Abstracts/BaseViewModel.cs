using CommunityToolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LivePlayMAUI.Services;
using LivePlayMAUI.Models.Enum;
using CommunityToolkit.Mvvm.Input;

namespace LivePlayMAUI.Abstracts;

public partial class BaseViewModel(AppSettings appSettings) : ObservableObject
{
    public AppSettings _appSettings = appSettings;

    [ObservableProperty]
    public bool _isRefreshing;

    [RelayCommand]
    public void Refresh()
    {
        IsRefreshing = false;
    }

    public virtual void ChangeColorBars(Color color, StatusBarColor statusBarColor, Color? secondColor = null)
    {
        _appSettings.ChangeColorStatusBars?.Invoke(color, statusBarColor, secondColor);
    }
}
