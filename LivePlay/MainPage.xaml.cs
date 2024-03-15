
using LivePlay.Models.ViewModels;

namespace LivePlay;

public partial class MainPage : ContentPage
{
    LoginViewModel Loggin = new();

    public MainPage()
    {
        InitializeComponent();
        BindingContext = Loggin;
    }

    //private void OnShowPasswordToggled(object sender, ToggledEventArgs e)
    //{
    //    IsPasswordEntry = !e.Value;
    //}

    private async void OnLoginButtonClicked(object sender, EventArgs e)
    {
        await DisplayAlert("Login", $"Вы вошли как: {Loggin.UserName} - {Loggin.Password}", "ok");
    }

    //private void HidePassword(object sender, EventArgs e)
    //{
    //    PasswordEntry.IsPassword = !IsPasswordEntry;
    //    IsPasswordEntry = !IsPasswordEntry;
    //}
}
