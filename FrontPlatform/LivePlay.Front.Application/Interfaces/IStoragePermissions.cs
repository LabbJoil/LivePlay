
namespace LivePlay.Front.Application.Interfaces;

public interface IStoragePermissions
{
    Task<PermissionStatus> CheckStatusAsync();
    Task<PermissionStatus> RequestAsync();
}
