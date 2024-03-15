using System.Formats.Tar;

namespace LivePlay.PersonalElements;

public partial class PasswordEntryControl : ContentView
{
    public PasswordEntryControl()
        => InitializeComponent();

    private bool IsPasswordTurn = true;

    public static readonly BindableProperty TextProperty = BindableProperty.Create(
       propertyName: nameof(Text),
       returnType: typeof(string),
       declaringType: typeof(SimpleEntryControl),
       defaultValue: null,
       defaultBindingMode: BindingMode.TwoWay);

    public static readonly BindableProperty PlaceholderProperty = BindableProperty.Create(
        propertyName: nameof(Placeholder),
        returnType: typeof(string),
        declaringType: typeof(SimpleEntryControl),
        defaultValue: null,
        defaultBindingMode: BindingMode.OneWay);

    public static readonly BindableProperty NewBackgroundColorProperty = BindableProperty.Create(
        propertyName: nameof(NewBackgroundColor),
        returnType: typeof(Color),
        declaringType: typeof(SimpleEntryControl),
        defaultValue: Color.FromRgba(0, 0, 0, 0),
        defaultBindingMode: BindingMode.OneWay);

    public string Text
    {
        get => (string)GetValue(TextProperty);
        set { SetValue(TextProperty, value); }
    }

    public string Placeholder
    {
        get => (string)GetValue(PlaceholderProperty);
        set { SetValue(PlaceholderProperty, value); }
    }

    public Color NewBackgroundColor
    {
        get => (Color)GetValue(NewBackgroundColorProperty);
        set { SetValue(NewBackgroundColorProperty, value); }
    }

    private void PasswordEntry_Focused(object sender, FocusEventArgs e)
    {
        LabelPlaceholderMini.IsVisible = true;
        LabelPlaceholderBase.IsVisible = false;
    }

    private void PasswordEntry_Unfocused(object sender, FocusEventArgs e)
    {
        if (string.IsNullOrWhiteSpace(Text))
        {
            LabelPlaceholderMini.IsVisible = false;
            LabelPlaceholderBase.IsVisible = true;
        }
    }

    private void HideShowPassword(object sender, EventArgs e)
    {
        PasswordEntry.IsPassword = !IsPasswordTurn;
        IsPasswordTurn = !IsPasswordTurn;
        ActionButton.Source = IsPasswordTurn ? "open_eye.svg" : "close_eye.svg";
    }
}