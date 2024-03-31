
using LivePlay.Pages;

namespace LivePlay;

public partial class AppShell : Shell
{
    public AppShell()
    {
        InitializeComponent();
        Routing.RegisterRoute(nameof(TapePage), typeof(TapePage));
    }
}
