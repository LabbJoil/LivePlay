
using CommunityToolkit.Mvvm.Input;
using LivePlayMAUI.Models.Domain;
using LivePlayMAUI.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LivePlayMAUI.Models.ViewModels.QuestViewModels;

public partial class InProgressPhotoPageViewModel(DeviceDesignSettings designSettings, DeviceStorage deviceStorage, QuestItem questItem) : BaseQuestPageViewModel(designSettings, questItem)
{
    private readonly DeviceStorage Storage = deviceStorage;

    [RelayCommand]
    public async Task ChooseFiles()
    {
        await Storage.GetSelectItemsStorage();
    }
}
