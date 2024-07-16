
using LivePlay.Front.MAUI.DeviceSettings;

namespace LivePlay.Front.MAUI.Pages.AdminPages.QuestPages.Creations.Views;

public partial class CreationQRQuestPage : ContentPage
{
    public CreationQRQuestPage()
	{
        InitializeComponent();
    }

    private async void ImageButton_Clicked(object sender, EventArgs e)
    {
        
    }

    private void Button_Clicked(object sender, EventArgs e)
    {
        QRQuestBI.Barcode = "lizochka lubimka";
    }
}