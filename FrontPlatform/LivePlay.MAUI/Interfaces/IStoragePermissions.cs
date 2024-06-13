
namespace LivePlay.Front.MAUI.Interfaces;

public interface IStoragePermissions
{
    Task<PermissionStatus> CheckStatusAsync();
    Task<PermissionStatus> RequestAsync();
}
