
namespace LivePlayMAUI.Interfaces;

public interface IStoragePermissions
{
    Task<PermissionStatus> CheckStatusAsync();
    Task<PermissionStatus> RequestAsync();
}
