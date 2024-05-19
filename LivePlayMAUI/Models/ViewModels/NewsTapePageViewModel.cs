
using CommunityToolkit.Mvvm.Input;
using LivePlayMAUI.Abstracts;
using LivePlayMAUI.Models.Domain;
using LivePlayMAUI.Pages;
using System.Collections.ObjectModel;
using LivePlayMAUI.Services;

namespace LivePlayMAUI.Models.ViewModels;

public partial class NewsTapePageViewModel : MainTapeViewModel
{
    public ObservableCollection<NewsItem> TapeItems { get; set; }

    [RelayCommand]
    public async override Task GoToTapeItem(object item)
    {
        if (item is Tuple<object, ContentPage> tuple && tuple.Item1 is NewsItem newsItem && tuple.Item2 is ContentPage contentPage)
        {
            var currentPageViewModel = new CurrentNewsPageViewModel(_appSettings, newsItem ?? new NewsItem());
            await contentPage.Navigation.PushAsync(new CurrentNewsPage(currentPageViewModel));
        }
    }

    public NewsTapePageViewModel(AppSettings appSettings) : base(appSettings)
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
