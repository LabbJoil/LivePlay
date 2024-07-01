
using CommunityToolkit.Mvvm.Input;
using LivePlay.Front.MAUI.Abstracts;
using LivePlay.Front.MAUI.DeviceSettings;

namespace LivePlay.Front.MAUI.Pages.UserPages.QuestPages.InProgress.ViewModels;

public partial class InProgressDrawingQuestViewModel(AppDesign designSettings) : BaseQuestViewModel(designSettings)
{
    [RelayCommand]
    public async Task ChooseFiles()
    {
        await AppStorage.GetSelectItemsStorage();
    }
}
