﻿
using LivePlay.Front.Core.Enums;

namespace LivePlay.Front.MAUI.DeviceSettings;

public class AppDesign
{
    private Action<Color?, Color?, bool>? ChangeColorStatusBarsAction;
    private Action<int>? ChangeCountCoinsAction;
    private Func<int>? GetCountCoinsFunc;

    public Action<Color?, Color?, bool>? ChangeColorStatusBars
    {
        get => ChangeColorStatusBarsAction;
        set => ChangeColorStatusBarsAction ??= value;
    }

    public Action<int>? ChangeCountCoins
    {
        get => ChangeCountCoinsAction;
        set => ChangeCountCoinsAction ??= value;
    }

    public Func<int>? GetCountCoins
    {
        get => GetCountCoinsFunc;
        set => GetCountCoinsFunc ??= value;
    }

    public AppTheme LoadSettings()
    {
        AppTheme them = AppTheme.Dark; // TODO: загрузка из JSON
        return them;
    }
}
