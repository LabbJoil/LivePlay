
namespace LivePlay.Front.Infrastructure.Interfaces;

public interface IStoragePermissions
{
    Task<PermissionStatus> CheckStatusAsync();
    Task<PermissionStatus> RequestAsync();
}
