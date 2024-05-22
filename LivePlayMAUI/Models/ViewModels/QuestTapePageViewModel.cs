using CommunityToolkit.Maui.Storage;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using LivePlayMAUI.Abstracts;
using LivePlayMAUI.Interfaces;
using LivePlayMAUI.Models.Domain;
using LivePlayMAUI.Pages;
using MauiPopup;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Input;
using LivePlayMAUI.Services;
using Microsoft.Extensions.Options;
using LivePlayMAUI.Models.Options;

namespace LivePlayMAUI.Models.ViewModels;

public partial class QuestTapePageViewModel : MainTapeViewModel
{
    public ObservableCollection<QuestItem> TapeItems { get; set; }
    public ObservableCollection<FilterItem> FilterItems { get; }

    [RelayCommand]
    public async override Task GoToTapeItem(object item)
    {
        var questItem = item as QuestItem;
        await PopupAction.DisplayPopup(new CurrentQuestPage(questItem ?? new()));
    }

    public QuestTapePageViewModel(AppSettings appSettings, IOptions<QuestFilterOptions> questFilterOptions) : base(appSettings)
    {
        FilterItems = new ObservableCollection<FilterItem>(questFilterOptions.Value.QuestFilterItems);

        // запрос к серверу
        TapeItems = [
            new()
            {
                ImageView = $@"/storage/emulated/0/DCIM/Camera/Рисунок1.png",
                TitleView = "БЕБЕ",
                DescriptionView = "fnwejkfnerbiuerbvierbviurbve"
            },
            new()
            {
                ImageView = $@"/storage/emulated/0/DCIM/Camera/20230414_212808.jpg",
                TitleView = "huiyuyuи",
                DescriptionView = "fnwejkfnerbiuerbvierbviurbve"
            },
            new()
            {
                ImageView = $@"/storage/emulated/0/DCIM/Camera/Рисунок1.png",
                TitleView = "БЕБЕ",
                DescriptionView = "fnwejkfnerbiuerbvierbviurbve"
            },
            new()
            {
                ImageView = $@"/storage/emulated/0/DCIM/Camera/20230414_212808.jpg",
                TitleView = "jhhfyf",
                DescriptionView = "fnwejkfnerbiuerbvierbviurbve"
            },
        ];
    }
}
