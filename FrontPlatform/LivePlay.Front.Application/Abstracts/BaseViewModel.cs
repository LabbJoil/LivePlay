
using CommunityToolkit.Mvvm.ComponentModel;
using LivePlay.Front.Application.DeviceSettings;
using CommunityToolkit.Mvvm.Input;
using LivePlay.Front.Core.Enums;

namespace LivePlay.Front.Application.Abstracts;

public partial class BaseViewModel(AppDesign designSettings) : ObservableObject
{
    public AppDesign DesignSettings = designSettings;

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
