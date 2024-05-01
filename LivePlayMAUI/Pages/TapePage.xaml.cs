
using System.Collections.ObjectModel;
using LivePlayMAUI.Models.Enum;
using LivePlayMAUI.Services;

namespace LivePlayMAUI.Pages;

public partial class TapePage : ContentPage
{
    public TapePage()
	{
		InitializeComponent();
        BindingContext = new MainViewModel();
        Settings.ChangeColorStatusBars?.Invoke(MainScrollView.BackgroundColor, StatusBarColor.BarWhite, null);
    }

    private void GoBack(object sender, EventArgs e)
    {
		//Navigation.PopModalAsync();
    }
}

public class ImageItem
{
    public string ImageUrl { get; set; }
    public string Caption { get; set; }
}

public class MainViewModel
{
    public ObservableCollection<ImageItem> Images { get; set; }

    public MainViewModel()
    {
        Images = new ObservableCollection<ImageItem>
        {
            new ImageItem { ImageUrl = @"C:\Users\levt1\Pictures\Screenshots\Screenshot 2023-12-11 012631.png", Caption = "Caption 1" },
            new ImageItem { ImageUrl = @"C:\Users\levt1\Pictures\Screenshots\Screenshot 2024-02-20 234438.png", Caption = "Caption 2" },
            // Добавьте другие элементы
        };
    }
}
