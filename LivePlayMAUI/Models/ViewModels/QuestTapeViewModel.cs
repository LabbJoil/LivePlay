using CommunityToolkit.Maui.Storage;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
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

namespace LivePlayMAUI.Models.ViewModels;

internal partial class QuestTapeViewModel : ObservableObject, ITapeViewModel
{
    public ObservableCollection<QuestItem> TapeItems { get; set; }

    [ObservableProperty]
    public bool _isRefreshing;

    [RelayCommand]
    public void Refresh()
    {
        IsRefreshing = false;
    }

    [RelayCommand]
    public void GoToTapeItem(object item)
    {
        var questItem = item as QuestItem;
        PopupAction.DisplayPopup(new CurrentQuestPage(questItem ?? new()));
    }

    public QuestTapeViewModel()
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
