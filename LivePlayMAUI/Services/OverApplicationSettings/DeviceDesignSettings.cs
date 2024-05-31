
using CommunityToolkit.Maui.Alerts;
using CommunityToolkit.Maui.Storage;
using LivePlayMAUI.Enum;
using LivePlayMAUI.Models.ViewModels;
using System.Diagnostics.CodeAnalysis;
using System.Text;

namespace LivePlayMAUI.Services;

public class DeviceDesignSettings
{
    private Action<Color, StatusBarColor, Color?>? ChangeColorStatusBarsAction;
    private Action<string>? ChangeCountCoinsAction;

    public Action<Color, StatusBarColor, Color?>? ChangeColorStatusBars
    {
        get => ChangeColorStatusBarsAction;
        set => ChangeColorStatusBarsAction ??= value;
    }

    public Action<string>? ChangeCountCoins
    {
        get => ChangeCountCoinsAction;
        set => ChangeCountCoinsAction ??= value;
    }

    public AppTheme LoadSettings()
    {
        AppTheme them = AppTheme.Dark; // TODO: загрузка из JSON
        return them;
    }

    public static void OpacityAnimation(IAnimatable owner, VisualElement visualElement, uint rate, uint lengthAnimation, double endOpacity, double? startOpacity = null)
    {
        var animationBackground = new Animation(v => visualElement.Opacity = v, startOpacity ?? visualElement.Opacity, endOpacity);
        animationBackground.Commit(owner, nameof(owner) + "AnimationOpacity", rate, lengthAnimation);
    }

    public void SetShellDesign()
    {
        //Shell.TabBarIsVisibleProperty = false;
    }
}
