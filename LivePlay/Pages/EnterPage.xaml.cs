
using LivePlay.Models.ViewModels;
using Microsoft.Maui.Controls;

namespace LivePlay.Pages;

public partial class EnterPage : ContentPage
{
    LoginViewModel Loggin = new();

    public EnterPage()
    {
        InitializeComponent();
        BindingContext = Loggin;
    }

    private async void OnLoginButtonClicked(object sender, EventArgs e)
    {
        await DisplayAlert("Login", $"Вы вошли как: {Loggin.UserName} - {Loggin.Password}", "ok");
    }

    private void LogIn(object sender, EventArgs e)
    {
        AnimateEnterFrame(0, 100);
    }

    private void SignUp(object sender, EventArgs e)
    {
        AnimateEnterFrame(300, 100);
    }

    private async void AnimateEnterFrame(double xAnimate, uint timeDo)
        => await AnimatedFrame.TranslateTo(xAnimate, 0, timeDo, Easing.Linear);
}
