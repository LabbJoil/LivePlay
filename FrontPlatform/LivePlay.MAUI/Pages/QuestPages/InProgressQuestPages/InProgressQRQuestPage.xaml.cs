using LivePlay.Front.MAUI.Models.ViewModels.QuestViewModels;
using LivePlay.Front.MAUI.ViewModels.QuestViewModels;

namespace LivePlay.Front.MAUI.Pages;

public partial class InProgressQRQuestPage : ContentPage
{
	public InProgressQRQuestPage(BaseQuestPageViewModel inProgressPhotoVM)
	{
		InitializeComponent();
        BindingContext = inProgressPhotoVM;

        QRScan.Options = new ZXing.Net.Maui.BarcodeReaderOptions
        {
            Formats = ZXing.Net.Maui.BarcodeFormat.QrCode,
            AutoRotate = true,
            Multiple = false
        };
    }

    private  void QRScan_BarcodesDetected(object sender, ZXing.Net.Maui.BarcodeDetectionEventArgs e)
    {
        var first = e.Results?.FirstOrDefault();
        QRScan.IsDetecting = false;

        if (first is null)
            return;

        Dispatcher.DispatchAsync( async () =>
        {
            await DisplayAlert("Barcode Detected", first.Value, "OK");
            QRScan.IsDetecting = true;
        });
    }
}