using Microsoft.Maui;
using static System.Net.Mime.MediaTypeNames;

namespace LivePlay.PersonalElements;

public partial class SwitchButtonsControl : ContentView
{
    public delegate Task ClickBT(object sender, EventArgs e);
    public event ClickBT? ClickButton1;
    public event ClickBT? ClickButton2;

    public static readonly BindableProperty TextButton1Property = BindableProperty.Create(
       propertyName: nameof(TextButton1),
       returnType: typeof(string),
       declaringType: typeof(SimpleEntryControl),
       defaultValue: "Button 1",
       defaultBindingMode: BindingMode.TwoWay);

    public static readonly BindableProperty TextButton2Property = BindableProperty.Create(
        propertyName: nameof(TextButton2),
        returnType: typeof(string),
        declaringType: typeof(SimpleEntryControl),
        defaultValue: "Button 1",
        defaultBindingMode: BindingMode.OneWay);

    public string TextButton1
    {
        get => (string)GetValue(TextButton1Property);
        set { SetValue(TextButton1Property, value); }
    }

    public string TextButton2
    {
        get => (string)GetValue(TextButton2Property);
        set { SetValue(TextButton2Property, value); }
    }

    public SwitchButtonsControl()
	{
		InitializeComponent();
	}

    private async void Button1_Clicked(object sender, EventArgs e)
    {
        Button1.IsEnabled = false;
        await Task.WhenAll(AnimateFrame(0),
            ClickButton2?.Invoke(this, e) ?? Task.CompletedTask);
        Button2.IsEnabled = true;
    }

    private async void Button2_Clicked(object sender, EventArgs e)
    {
        Button2.IsEnabled = false;
        await Task.WhenAll(AnimateFrame(MainGrid.Width / 2),
            ClickButton1?.Invoke(this, e) ?? Task.CompletedTask);
        Button1.IsEnabled = true;
    }

    private async Task AnimateFrame(double xAnimate)
        => await AnimatedFrame.TranslateTo(xAnimate, 0, 250, Easing.Linear);
}