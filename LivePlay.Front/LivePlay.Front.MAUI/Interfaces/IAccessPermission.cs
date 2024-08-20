
namespace LivePlay.Front.MAUI.Interfaces;

public interface IAccessPermission
{
    Task<PermissionStatus> CheckStatusAsync();
    Task<PermissionStatus> RequestAsync();
}
