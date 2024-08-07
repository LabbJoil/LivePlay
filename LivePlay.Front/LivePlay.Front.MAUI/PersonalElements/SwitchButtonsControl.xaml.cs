
namespace LivePlay.Front.MAUI.PersonalElements;

public partial class SwitchButtonsControl : ContentView
{
    public delegate Task ClickBT();
    public event ClickBT? ClickButton1;
    public event ClickBT? ClickButton2;

    public event Action EventClickButton1;
    public event Action EventClickButton2;

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
        defaultValue: "Button 2",
        defaultBindingMode: BindingMode.TwoWay);

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

    private void Loaded_Page(object sender, EventArgs e)
    {
        ButtonFrame1.IsEnabled = false;
    }

    private async void Button1_Clicked(object sender, EventArgs e)
    {
        await DoProcessButton1();
    }

    private async void Button2_Clicked(object sender, EventArgs e)
    {
        await DoProcessButton2();
    }

    public async Task DoProcessButton1()
    {
        ButtonFrame1.IsEnabled = false;
        await Task.WhenAll(AnimateFrame(0),
            ClickButton2?.Invoke() ?? Task.CompletedTask);
        ButtonFrame2.IsEnabled = true;
    }

    public async Task DoProcessButton2()
    {
        ButtonFrame2.IsEnabled = false;
        await Task.WhenAll(AnimateFrame(MainGrid.Width / 2),
            ClickButton1?.Invoke() ?? Task.CompletedTask);
        ButtonFrame1.IsEnabled = true;
    }

    private async Task AnimateFrame(double xAnimate)
        => await AnimatedFrame.TranslateTo(xAnimate, 0, 250, Easing.Linear);

}