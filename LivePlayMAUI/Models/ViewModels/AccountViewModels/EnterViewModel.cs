using LivePlayMAUI.Abstracts;
using LivePlayMAUI.Services;

namespace LivePlayMAUI.Models.ViewModels.AccountViewModels;

public class EnterViewModel(DeviceDesignSettings designSettings, DevicePermissions permissions) : BaseViewModel(designSettings)
{
    public DevicePermissions Permissions { get; } = permissions;
}
