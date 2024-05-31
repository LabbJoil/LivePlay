using LivePlayMAUI.Models.ViewModels;
using System.Formats.Tar;

namespace LivePlayMAUI.PersonalElements;

public partial class PasswordEntryControl : ContentView
{
    public PasswordEntryControl()
    {
        InitializeComponent();
    }

    public static readonly BindableProperty TextProperty = BindableProperty.Create(
       propertyName: nameof(Text),
       returnType: typeof(string),
       declaringType: typeof(PasswordEntryControl),
       defaultValue: null,
       defaultBindingMode: BindingMode.TwoWay);

    public static readonly BindableProperty PlaceholderProperty = BindableProperty.Create(
        propertyName: nameof(Placeholder),
        returnType: typeof(string),
        declaringType: typeof(PasswordEntryControl),
        defaultValue: null,
        defaultBindingMode: BindingMode.OneWay);

    public static readonly BindableProperty IsPasswordProperty = BindableProperty.Create(
        propertyName: nameof(IsPassword),
        returnType: typeof(bool),
        declaringType: typeof(PasswordEntryControl),
        defaultValue: true,
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

    public bool IsPassword
    {
        get => (bool)GetValue(IsPasswordProperty);
        set { SetValue(IsPasswordProperty, value); }
    }

    //public Color NewBackgroundColor
    //{
    //    get => (Color)GetValue(NewBackgroundColorProperty);
    //    set { SetValue(NewBackgroundColorProperty, value); }
    //}

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

    private void ShowPassword(object sender, EventArgs e)
        => TogglePasswordVisibility(true);

    private void HidePassword(object sender, EventArgs e)
        => TogglePasswordVisibility(false);

    private void TogglePasswordVisibility(bool showPassword)
    {
        IsPassword = showPassword;
        ShowPasswordButton.IsVisible = ShowPasswordButton.IsEnabled = !showPassword;
        HidePasswordButton.IsVisible = HidePasswordButton.IsEnabled = showPassword;
    }
}