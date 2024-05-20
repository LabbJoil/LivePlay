using CommunityToolkit.Mvvm.Input;
using LivePlayMAUI.Abstracts;
using LivePlayMAUI.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LivePlayMAUI.Models.ViewModels;

public partial class AccountPageViewModel : MainTapeViewModel
{
    public ObservableCollection<CouponItem> CouponItems { get; set; }

    [RelayCommand]
    public async override Task GoToTapeItem(object item)
    {
        if (item is Tuple<object, ContentPage> tuple && tuple.Item1 is NewsItem newsItem && tuple.Item2 is ContentPage contentPage)
        {
            var currentPageViewModel = new CurrentNewsPageViewModel(_appSettings, newsItem ?? new NewsItem());
            await contentPage.Navigation.PushAsync(new CurrentNewsPage(currentPageViewModel));
        }
    }

    public AccountPageViewModel(AppSettings appSettings) : base(appSettings)
    {
        // запрос к серверу
        CouponItems = [
            new()
            {
                TitleView = "БЕБЕ",
                DescriptionView = "fnwejkfnerbiuerbvierbviurbve"
            },
            new()
            {
                TitleView = "huiyuyuи",
                DescriptionView = "fnwejkfnerbiuerbvierbviurbve"
            },
            new()
            {
                TitleView = "БЕБЕ",
                DescriptionView = "fnwejkfnerbiuerbvierbviurbve"
            },
            new()
            {
                TitleView = "jhhfyf",
                DescriptionView = "fnwejkfnerbiuerbvierbviurbve"
            },
        ];
    }
}
