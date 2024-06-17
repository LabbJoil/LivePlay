
using CommunityToolkit.Mvvm.Input;
using LivePlay.Front.MAUI.DeviceSettings;
using LivePlay.Front.MAUI.ViewModels.QuestViewModels;

namespace LivePlay.Front.MAUI.Models.ViewModels.QuestViewModels;

public partial class InProgressPhotoQuestPageViewModel(AppDesign designSettings) : BaseQuestPageViewModel(designSettings)
{
    [RelayCommand]
    public async Task ChooseFiles()
    {
        await AppStorage.GetSelectItemsStorage();
    }
}
