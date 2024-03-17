using Microsoft.Maui;
using static System.Net.Mime.MediaTypeNames;

namespace LivePlay.PersonalElements;

public partial class SwitchButtonsControl : ContentView
{
    public event EventHandler? ClickButton1;
    public event EventHandler? ClickButton2;

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

    private int T = 0;
    private void Button1_Clicked(object sender, EventArgs e)
    {
        AnimateRectangle(0);
        ClickButton1?.Invoke(this, e);
    }

    private void Button2_Clicked(object sender, EventArgs e)
    {
        AnimateRectangle(MainGrid.Width / 2);
        ClickButton2?.Invoke(this, e);
    }

    private async void AnimateRectangle(double xAnimate)
        => await AnimatedFrame.TranslateTo(xAnimate, 0, 500, Easing.Linear);
}