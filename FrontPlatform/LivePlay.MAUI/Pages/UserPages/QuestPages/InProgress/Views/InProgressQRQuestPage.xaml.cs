
using LivePlay.Front.MAUI.Abstracts;
using LivePlay.Front.MAUI.Pages.UserPages.QuestPages.InProgress.ViewModels;

namespace LivePlay.Front.MAUI.Pages.UserPages.QuestPages.InProgress.Views;

public partial class InProgressQRQuestPage : ContentPage
{
	public InProgressQRQuestPage(InProgressQRQuestViewModel inProgressQRQuestVM)
	{
		InitializeComponent();
        BindingContext = inProgressQRQuestVM;

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