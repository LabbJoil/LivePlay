
using LivePlay.Front.MAUI.Abstracts;
using LivePlay.Front.MAUI.DeviceSettings;

namespace LivePlay.Front.MAUI.Pages.EnterPages.ViewModels;

public class BlackViewModel(AppDesign appDesign, AppStorage storage) : BaseViewModel(appDesign)
{
    private readonly AppStorage _storage = storage;

    public void MakeDecision()
    {
        StartLoading();

        StopLoading();
    }
}
