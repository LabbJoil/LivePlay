
using LivePlayMAUI.Models.Enum;
using LivePlayMAUI.Models.ViewModels;
using LivePlayMAUI.Services;

namespace LivePlayMAUI.Pages;

public partial class EnterPage : ContentPage
{
    LoginViewModel Loggin = new();
    StackLayout NowStackLayout;
    ActionTimer? SendCodeTimer;


    public EnterPage()
    {
        InitializeComponent();
        BindingContext = Loggin;
        NowStackLayout = LoginStackLayout;
        SettingsModel.ChangeColorStatusBars?.Invoke(MainGrid.BackgroundColor);
    }

    private async void OnLoginButtonClicked(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync($"//{nameof(TapePage)}");
        //await DisplayAlert("Login", $"Вы вошли как: {Loggin.UserName} - {Loggin.Password}", "ok");
    }

    private async Task LogInButtonClicked(object sender, EventArgs e)
    {
        if (NowStackLayout != LoginStackLayout)
        {
            await ChangeStackLayout(LoginStackLayout, DirectionAction.Right);
        }
    }

    private async Task SignUpButtonClicked(object sender, EventArgs e)
    {
        if (NowStackLayout != EmailStackLayout)
        {
            await ChangeStackLayout(EmailStackLayout, DirectionAction.Left);
        }
    }

    private async void EmailCheckButtonClicked(object sender, EventArgs e)
    {
        SendCodeTimer?.Stop();
        SendCodeTimer = new(DirectionAction.Down, PrintTimer, EndTimer);
        SendCodeTimer.Start(5, 1000);
        await ChangeStackLayout(CodeStackLayout, DirectionAction.Left);
    }

    private void CodeCheckButtonClicked(object sender, EventArgs e)
    {
        Random rand = new ();
        if (rand.Next(0, 2) == 1)
            SendCodeTimer?.Stop();
        else
            DisplayAlert("Code", "Код неправильный", "ok");
        //ChangeStackLayout(CodeStackLayout, DirectionAction.Left);

    }

    private void SendCodeAgainButtonClicked(object sender, EventArgs e)
    {
        SendCodeButton.IsEnabled = false;
        SendCodeTimer?.Stop();
        SendCodeTimer = new(DirectionAction.Down, PrintTimer, EndTimer);
        SendCodeTimer.Start(65, 1000);
    }

    private void PrintTimer(object? obj)
    {
        if(obj is int seconds)
            TimerLabel.Text = $"{seconds / 60}:{seconds % 60}";
    }

    private void EndTimer()
    {
        SendCodeButton.IsEnabled = true;
        TimerLabel.Text = "00:00";
    }

    private async Task ChangeStackLayout(StackLayout stackLayoutIn, DirectionAction swipeSlIn)
    {
        double slInXStartposition = swipeSlIn == DirectionAction.Left ? 350 : -350;
        stackLayoutIn.TranslationX = slInXStartposition;
        stackLayoutIn.IsVisible = true;
        Task animation1 = NowStackLayout.TranslateTo(-slInXStartposition, 0, 350, Easing.Linear);
        Task animation2 = stackLayoutIn.TranslateTo(0, 0, 350, Easing.Linear);
        await Task.WhenAll(animation1, animation2);
        NowStackLayout.IsVisible = false;
        NowStackLayout = stackLayoutIn;
    }

    
}
