
namespace LivePlay.Front.Infrastructure.Interfaces;

public interface IAppStorage
{
    public void SavePreference(string keyPreference, object model);
    public T? GetPreference<T>(string keyPreference);
}
