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

namespace LivePlayMAUI.Models.ViewModels;

internal partial class QuestTapePageViewModel : MainTapeViewModel
{
    public ObservableCollection<QuestItem> TapeItems { get; set; }

    [RelayCommand]
    public async override Task GoToTapeItem(object item)
    {
        var questItem = item as QuestItem;
        await PopupAction.DisplayPopup(new CurrentQuestPage(questItem ?? new()));
    }

    public QuestTapePageViewModel(AppSettings appSettings) : base(appSettings)
    {
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
