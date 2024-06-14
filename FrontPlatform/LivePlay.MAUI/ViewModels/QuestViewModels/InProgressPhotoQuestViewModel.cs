
using CommunityToolkit.Mvvm.Input;
using LivePlay.Front.Application.DeviceSettings;
using LivePlay.Front.MAUI.ViewModels.QuestViewModels;

namespace LivePlay.Front.MAUI.Models.ViewModels.QuestViewModels;

public partial class InProgressPhotoQuestViewModel(AppDesign designSettings, AppStorage deviceStorage) : BaseQuestViewModel(designSettings)
{
    private readonly AppStorage Storage = deviceStorage;

    [RelayCommand]
    public async Task ChooseFiles()
    {
        await Storage.GetSelectItemsStorage();
    }
}
