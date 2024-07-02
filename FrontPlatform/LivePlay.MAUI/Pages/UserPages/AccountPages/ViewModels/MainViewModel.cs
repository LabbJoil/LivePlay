
using CommunityToolkit.Mvvm.Input;
using LivePlay.Front.MAUI.Abstracts;
using LivePlay.Front.MAUI.DeviceSettings;
using LivePlay.Front.Core.Models;
using System.Collections.ObjectModel;
using LivePlay.Front.MAUI.Pages.UserPages.NewsPages.Views;

namespace LivePlay.Front.MAUI.Pages.UserPages.AccountPages.ViewModels;

public partial class MainViewModel : BaseTapeViewModel
{
    public ObservableCollection<News> TapeItems { get; set; }

    [RelayCommand]
    public async override Task GoToTapeItem(object item)
    {
        if (item is Tuple<object, ContentPage> tuple && tuple.Item1 is News newsItem && tuple.Item2 is ContentPage contentPage)
        {
            await Shell.Current.GoToAsync($"{nameof(CurrentNewsPage)}", new ShellNavigationQueryParameters { { $"{nameof(News)}Property", newsItem } });
        }
    }

    public MainViewModel(AppDesign designSettings) : base(designSettings)
    {
        string cookiesPath = Environment.GetFolderPath(Environment.SpecialFolder.Cookies);
        string appDataPath = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);

        string filePath = Path.Combine(appDataPath, "Рисунок1.txt");


        //File.WriteAllBytes(filePath, File.ReadAllBytes($@"/storage/emulated/0/Рисунок1.png"));

        TapeItems = [
            new()
            {
                Image = $@"/storage/emulated/0/Рисунок1.png",
                Title = "Новые события",
                Description = "В наших отелях новые конкурсы!"
            },
            new()
            {
                Image = $@"/storage/emulated/0/Рисунок1.png",
                Title = "Новые события",
                Description = "В наших отелях новые конкурсы!"
            },
            new()
            {
                Image = $@"/storage/emulated/0/Рисунок1.png",
                Title = "Новые события",
                Description = "В наших отелях новые конкурсы!"
            }
        ];
    }
}
