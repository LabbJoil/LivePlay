
using LivePlay.Front.MAUI.DeviceSettings;

namespace LivePlay.Front.MAUI.Pages.QuestPages.CreationQuestPages;

public partial class QRcodeCreationQuestPage : ContentPage
{
    private AppStorage DeviceStorage { get; }

    public QRcodeCreationQuestPage()
	{
        InitializeComponent();
    }

    private async void ImageButton_Clicked(object sender, EventArgs e)
    {
        
    }

    private void Button_Clicked(object sender, EventArgs e)
    {
        barcodeImage.Barcode = "lizochka lubimka";
    }
}