
using CommunityToolkit.Mvvm.Input;
using LivePlayMAUI.Services;

namespace LivePlayMAUI.Models.ViewModels.QuestViewModels;

public partial class InProgressPhotoQuestViewModel(DeviceDesignSettings designSettings, DeviceStorage deviceStorage) : BaseQuestViewModel(designSettings)
{
    private readonly DeviceStorage Storage = deviceStorage;

    [RelayCommand]
    public async Task ChooseFiles()
    {
        await Storage.GetSelectItemsStorage();
    }
}
