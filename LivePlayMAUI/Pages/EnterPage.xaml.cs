
using LivePlayMAUI.Models.Enum;
using LivePlayMAUI.Models.ViewModels;
using LivePlayMAUI.Services;

namespace LivePlayMAUI.Pages;

public partial class EnterPage : ContentPage
{
    private StackLayout NowStackLayout;
    private ActionTimer? SendCodeTimer;
    private readonly EnterPageViewModel EnterPageVM;

    public EnterPage(EnterPageViewModel enterPage)
    {
        InitializeComponent();
        BindingContext = enterPage;
        EnterPageVM = enterPage;
        NowStackLayout = LoginStackLayout;
    }

    private void ContentPage_Appearing(object sender, EventArgs e)
    {
        EnterPageVM.ChangeColorBars(BackgroundColor, StatusBarColor.BarReplay);
    }

    private async void OnLoginButtonClicked(object sender, EventArgs e)
    {
    RequestPermissions:
        bool havePermissions = await EnterPageVM._appSettings.GetPermission();
        if (!havePermissions)
        {
            if (await DisplayAlert("Нет доступа к хранилищу", $"Предоставьте, пожалуйста, доступ к хранилищу", "ok", "no"))
                goto RequestPermissions;
            else
                return;
        }

        //---

        //using var stream = new MemoryStream(Encoding.Default.GetBytes("Hello from the Community Toolkit!"));
        //var fileSaveResult = await FileSaver.Default.SaveAsync("LOL.txt", stream);
        //if (fileSaveResult.IsSuccessful)
        //{
        //    await Toast.Make($"File is saved: {fileSaveResult.FilePath.Split('0')[1]}").Show();
        //}
        //else
        //{
        //    await Toast.Make($"File is not saved, {fileSaveResult.Exception.Message}").Show();
        //}

        //---

        await Shell.Current.GoToAsync($"//{nameof(NewsTapePage)}");
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
        if (SendCodeTimer == null)
        {
            SendCodeTimer = new(DirectionAction.Down, PrintTimer, EndTimer);
            SendCodeTimer.Start(5, 1000);
        }
        await ChangeStackLayout(CodeStackLayout, DirectionAction.Left);
    }

    private void CodeCheckButtonClicked(object sender, EventArgs e)
    {
        Random rand = new ();
        if (rand.Next(0, 2) == 1)
            SendCodeTimer?.Stop();
        else
            DisplayAlert("Code", "Код неправильный", "ok");
    }

    private void SendCodeAgainButtonClicked(object sender, EventArgs e)
    {
        SendCodeTimer?.Stop();
        SendCodeButton.IsEnabled = false;
        SendCodeTimer = new(DirectionAction.Down, PrintTimer, EndTimer);
        SendCodeTimer.Start(65, 1000);
    }

    private void PrintTimer(object? obj)
    {
        if(obj is int fullSeconds)
        {
            var minutes = fullSeconds / 60;
            var seconds = fullSeconds % 60;
            TimerLabel.Text = string.Format("{0:d2}:{1:d2}", minutes, seconds);
        }
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
