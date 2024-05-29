using LivePlayMAUI.Abstracts;
using LivePlayMAUI.Services;

namespace LivePlayMAUI.Models.ViewModels.AccountViewModel;

public class EnterPageViewModel(DeviceDesignSettings designSettings, DevicePermissions permissions) : BaseViewModel(designSettings)
{
    public DevicePermissions Permissions { get; } = permissions;
}
