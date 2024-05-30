﻿
using CommunityToolkit.Mvvm.Input;
using LivePlayMAUI.Abstracts;
using LivePlayMAUI.Models.Domain;
using LivePlayMAUI.Pages;
using System.Collections.ObjectModel;
using LivePlayMAUI.Services;

namespace LivePlayMAUI.Models.ViewModels.NewsViewModels;

public partial class TapeNewsViewModel : MainTapeViewModel
{
    public ObservableCollection<NewsItem> TapeItems { get; set; }

    [RelayCommand]
    public async override Task GoToTapeItem(object item)
    {
        if (item is Tuple<object, ContentPage> tuple && tuple.Item1 is NewsItem newsItem && tuple.Item2 is ContentPage contentPage)
        {
            await Shell.Current.GoToAsync($"{nameof(CurrentNewsPage)}", new ShellNavigationQueryParameters { { $"{nameof(NewsItem)}Property", newsItem } });
        }
    }

    public TapeNewsViewModel(DeviceDesignSettings designSettings) : base(designSettings)
    {
        // запрос к серверу
        TapeItems = [
            new()
            {
                Image = $@"/storage/emulated/0/DCIM/Camera/Рисунок1.png",
                Title = "БЕБЕ",
                Description = "fnwejkfnerbiuerbvierbviurbve"
            },
            new()
            {
                Image = $@"/storage/emulated/0/DCIM/Camera/20230414_212808.jpg",
                Title = "huiyuyuи",
                Description = "fnwejkfnerbiuerbvierbviurbve"
            },
            new()
            {
                Image = $@"/storage/emulated/0/DCIM/Camera/Рисунок1.png",
                Title = "БЕБЕ",
                Description = "fnwejkfnerbiuerbvierbviurbve"
            },
            new()
            {
                Image = $@"/storage/emulated/0/DCIM/Camera/20230414_212808.jpg",
                Title = "jhhfyf",
                Description = "fnwejkfnerbiuerbvierbviurbve"
            },
        ];
    }
}