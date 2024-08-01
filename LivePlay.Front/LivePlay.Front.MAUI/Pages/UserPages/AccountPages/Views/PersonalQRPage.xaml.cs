
using LivePlay.Front.MAUI.Pages.UserPages.AccountPages.ViewModels;
using Microsoft.Maui.Controls.Shapes;
using The49.Maui.BottomSheet;

namespace LivePlay.Front.MAUI.Pages.UserPages.AccountPages.Views;

public partial class PersonalQRPage : BottomSheet
{
	private readonly PersonalQRViewModel PersonalQRVM;

    public static LinearGradientBrush GradientBrush => new()
    {
        StartPoint = new Point(0, 1),
        EndPoint = new Point(1, 0),
        GradientStops =
        [
            new GradientStop { Color = Colors.Green, Offset = 0 },
            new GradientStop { Color = Colors.Blue, Offset = 0.3f },
            new GradientStop { Color = Colors.Red, Offset = 1 },
        ]
    };

    Rectangle rectangle = new Rectangle
    {
        Fill = new LinearGradientBrush
        {
            GradientStops = {
                new GradientStop { Color = Colors.Red, Offset = 0 },
                new GradientStop { Color = Colors.Green, Offset = 1 }
            }
        }
    };

    LinearGradientPaint linearGradientPaint = new LinearGradientPaint
    {
        StartColor = Colors.Yellow,
        EndColor = Colors.Green,
        StartPoint = new Point(0, 0),
        EndPoint = new Point(1, 1)
    };

    public PersonalQRPage(PersonalQRViewModel personalQRVM)
	{
		PersonalQRVM = personalQRVM;
		InitializeComponent();
        //Background = linearGradientPaint;
        BindingContext = personalQRVM;
    }

	private new void Loaded(object sender, EventArgs e)
    {
        PersonalQRVM.ChangeColorBars(Colors.Black, barReplay:false);
        PersonalQRVM.FirstLoadQRData([QRcode, DateUpdateLabel]);
    }
}