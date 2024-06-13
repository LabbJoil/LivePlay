
using CommunityToolkit.Maui.Alerts;
using CommunityToolkit.Maui.Storage;

namespace LivePlay.Front.MAUI.Services;

public class  DeviceStorage
{
    public async Task GetSelectItemsStorage()
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

    public async Task<string> GetOneItemStorage()
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

    public async void SaveFile(string nameFile, byte[] writeBytes)
    {
        using var stream = new MemoryStream(writeBytes);

#if IOS14_0_OR_GREATER || __ANDROID__
        var fileSaveResult = await FileSaver.Default.SaveAsync(nameFile, stream);
        if (fileSaveResult.IsSuccessful)
        {
            await Toast.Make($"File is saved: {fileSaveResult.FilePath.Split('0')[1]}").Show();
        }
        else
        {
            await Toast.Make($"File is not saved, {fileSaveResult.Exception.Message}").Show();
        }
#endif
    }


    //Preferences.Set("MyModel", JsonSerializer.Serialize(model));

    //    string json = Preferences.Get("MyModel", null);
    //    if (json != null)
    //    {
    //        return JsonSerializer.Deserialize<MyModel>(json);
    //    }
}
