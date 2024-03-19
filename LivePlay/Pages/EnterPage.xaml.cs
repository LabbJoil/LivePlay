
using LivePlay.Models.ViewModels;
using Microsoft.Maui.Controls;

namespace LivePlay.Pages;

public partial class EnterPage : ContentPage
{
    LoginViewModel Loggin = new();
    StackLayout NowStackLayout;

    public EnterPage()
    {
        InitializeComponent();
        BindingContext = Loggin;
        NowStackLayout = LoginStackLayout;
    }

    private async void OnLoginButtonClicked(object sender, EventArgs e)
    {
        await DisplayAlert("Login", $"Вы вошли как: {Loggin.UserName} - {Loggin.Password}", "ok");
    }

    private void LogIn(object sender, EventArgs e)
    {
        if (NowStackLayout != LoginStackLayout)
        {
            LoginStackLayout.TranslationX = -300;
            AnimateEnterFrame(LoginStackLayout, 0, 250);
            AnimateEnterFrame(NowStackLayout, 300, 250);
            NowStackLayout = LoginStackLayout;
        }
    }

    private void SignUp(object sender, EventArgs e)
    {
        if (NowStackLayout != EmailStackLayout)
        {
            EmailStackLayout.TranslationX = 300;
            AnimateEnterFrame(NowStackLayout, -300, 100);
            AnimateEnterFrame(EmailStackLayout, 0, 250);
            NowStackLayout = EmailStackLayout;
        }
    }

    private async void AnimateEnterFrame(StackLayout stackLayout, double xAnimate, uint timeDo)
    {
        await stackLayout.TranslateTo(xAnimate, 0, timeDo, Easing.Linear);
        stackLayout.IsVisible = !stackLayout.IsVisible;
    }
}
