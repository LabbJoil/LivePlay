using LivePlayMAUI.Models.ViewModels;
using System.Collections.ObjectModel;

namespace LivePlayMAUI.Pages;

public partial class TapePage : ContentPage
{
    public TapePage()
	{
		InitializeComponent();
        BindingContext = new MainViewModel();
        SettingsModel.ChangeColorStatusBars?.Invoke(MainScrollView.BackgroundColor);
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
            new ImageItem { ImageUrl = "your_image_url_1", Caption = "Caption 1" },
            new ImageItem { ImageUrl = "your_image_url_2", Caption = "Caption 2" },
            // Добавьте другие элементы
        };
    }
}
