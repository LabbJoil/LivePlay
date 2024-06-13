
using CommunityToolkit.Mvvm.Input;
using LivePlay.Front.MAUI.Services;
using LivePlay.Front.MAUI.ViewModels.QuestViewModels;

namespace LivePlay.Front.MAUI.Models.ViewModels.QuestViewModels;

public partial class InProgressPhotoQuestViewModel(DeviceDesignSettings designSettings, DeviceStorage deviceStorage) : BaseQuestViewModel(designSettings)
{
    private readonly DeviceStorage Storage = deviceStorage;

    [RelayCommand]
    public async Task ChooseFiles()
    {
        await Storage.GetSelectItemsStorage();
    }
}
