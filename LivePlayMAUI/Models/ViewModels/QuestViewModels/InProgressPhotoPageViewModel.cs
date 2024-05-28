
using CommunityToolkit.Mvvm.Input;
using LivePlayMAUI.Models.Domain;
using LivePlayMAUI.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LivePlayMAUI.Models.ViewModels.QuestViewModels;

public partial class InProgressPhotoPageViewModel(OverApplicationSettings appSettings, QuestItem questItem) : BaseQuestPageViewModel(appSettings, questItem)
{
    [RelayCommand]
    public async Task ChooseFiles()
    {
        await AppSettings.GetSelectItemsStorage();
    }
}
