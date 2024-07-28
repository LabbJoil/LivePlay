
namespace LivePlay.Front.MAUI.PersonalElements;

public partial class NameEntryControl : ContentView
{
	public NameEntryControl()
	{
		InitializeComponent();
	}

    public static readonly BindableProperty FirstNameProperty = BindableProperty.Create(
       propertyName: nameof(FirstName),
       returnType: typeof(string),
       declaringType: typeof(NameEntryControl),
       defaultValue: "",
       defaultBindingMode: BindingMode.TwoWay);

    public static readonly BindableProperty SecondNameProperty = BindableProperty.Create(
        propertyName: nameof(SecondName),
        returnType: typeof(string),
        declaringType: typeof(NameEntryControl),
        defaultValue: "",
        defaultBindingMode: BindingMode.TwoWay);

    public static new readonly BindableProperty BackgroundProperty = BindableProperty.Create(
        propertyName: nameof(Background),
        returnType: typeof(Color),
        declaringType: typeof(NameEntryControl),
        defaultValue: new Color(255, 255, 255),
        defaultBindingMode: BindingMode.OneWay);

    public string FirstName
    {
        get => (string)GetValue(FirstNameProperty);
        set { SetValue(FirstNameProperty, value); }
    }

    public string SecondName
    {
        get => (string)GetValue(SecondNameProperty);
        set { SetValue(SecondNameProperty, value); }
    }

    public new Color Background
    {
        get => (Color)GetValue(BackgroundProperty);
        set { SetValue(BackgroundProperty, value); }
    }
}