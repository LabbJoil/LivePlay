
using CommunityToolkit.Maui.Alerts;
using CommunityToolkit.Maui.Storage;
using System.Text.Json;

namespace LivePlay.Front.MAUI.DeviceSettings;

public class  AppStorage
{
    public static async Task GetSelectItemsStorage()
    {
        var fileSaveResult = await FilePicker.Default.PickMultipleAsync();
        if (fileSaveResult != null)
        {
            await Toast.Make($"File is get").Show();
        }
        else
        {
            await Toast.Make($"File is not get").Show();
        }
    }

    public static async Task<string> GetOneItemStorage()
    {
        var fileSaveResult = await FilePicker.Default.PickAsync();
        if (fileSaveResult != null)
        {
            await Toast.Make($"File is get").Show();
            return fileSaveResult.FullPath;
        }
        else
        {
            await Toast.Make($"File is not get").Show();
            return "";
        }
    }

    public static async void SaveFile(string nameFile, byte[] writeBytes)
    {
        using var stream = new MemoryStream(writeBytes);

        var fileSaveResult = await FileSaver.Default.SaveAsync(nameFile, stream);
        if (fileSaveResult.IsSuccessful)
        {
            await Toast.Make($"File is saved: {fileSaveResult.FilePath.Split('0')[1]}").Show();
        }
        else
        {
            await Toast.Make($"File is not saved, {fileSaveResult.Exception.Message}").Show();
        }
    }

    public void GetHttpParams()
    {
        const string key = "HttpParams";
        //var HttpParams = GetPreference<>(key);
    }

    private static void SavePreference(string keyPreference, object model)
    {
        Preferences.Set(keyPreference, JsonSerializer.Serialize(model));
    }

    private static T? GetPreference<T>(string keyPreference)
    {
        if (Preferences.Get(keyPreference, null) is string json)
            return JsonSerializer.Deserialize<T>(json);
        return default;
    }
}
