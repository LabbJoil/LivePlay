
using LivePlay.Front.Core.Enums;
using LivePlay.Front.Core.Services;
using LivePlay.Front.MAUI.Models.ViewModels.AccountViewModels;

namespace LivePlay.Front.MAUI.Pages;

public partial class EnterPage : ContentPage
{
    private StackLayout NowStackLayout;
    private readonly EnterPageViewModel EnterPVM;

    private int CountSymbolsEmailCode = 0;
    private Label[] EmailCodeLabelDigits { get; }

    public EnterPage(EnterPageViewModel enterPage)
    {
        InitializeComponent();
        BindingContext = enterPage;
        EnterPVM = enterPage;
        EmailCodeLabelDigits = [OneEmailCodeDigit, TwoEmailCodeDigit, ThreeEmailCodeDigit, FourEmailCodeDigit];
        NowStackLayout = LoginStackLayout;
    }

    private void ContentPage_Appearing(object sender, EventArgs e)
    {
        EnterPVM.ChangeColorBars(BackgroundColor, StatusBarColor.BarReplay);
    }

    private void ContentPage_Disappearing(object sender, EventArgs e)
    {
        LoginPassword.Text = string.Empty;
        LoginEmail.Text = string.Empty;
        LoginPassword.IsPassword = false;
    }

    // -- next edit --

    private async Task LogInButtonClicked(object sender, EventArgs e)
    {
        if (NowStackLayout != LoginStackLayout)
            await ChangeStackLayout(LoginStackLayout, DirectionAction.Right);
    }

    private async Task SignUpButtonClicked(object sender, EventArgs e)
    {
        if (NowStackLayout != EmailStackLayout)
            await ChangeStackLayout(EmailStackLayout, DirectionAction.Left);
    }

    public async Task<(Action<object?>, Action)> VerifyEmailFrontProcess()
    {
        await ChangeStackLayout(CodeStackLayout, DirectionAction.Left);
        return (PrintTimer, EndTimer);
    }

    private void CheckCodeEmailFrontProcess(object sender, EventArgs e)
    {
        //Random rand = new ();
        //if (rand.Next(0, 2) == 1)
        //    SendCodeTimer?.Stop();
        //else
        //    DisplayAlert("Code", "Код неправильный", "ok");
    }

    private void SendCodeAgainButtonClicked(object sender, EventArgs e)
    {
        //SendCodeTimer?.Stop();
        //SendCodeButton.IsEnabled = false;
        //SendCodeTimer = new(DirectionAction.Down, PrintTimer, EndTimer);
        //SendCodeTimer.Start(65, 0);
    }

    private void PrintTimer(object? obj)
    {
        if(obj is int fullMilliseconds)
        {
            var fullSeconds = fullMilliseconds / 1000;
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

    public async Task ChangeStackLayout(StackLayout stackLayoutIn, DirectionAction swipeSlIn)
    {
        double slInXStartposition = swipeSlIn == DirectionAction.Left ? 350 : -350;     // константы
        stackLayoutIn.TranslationX = slInXStartposition;
        stackLayoutIn.IsVisible = true;
        Task animation1 = NowStackLayout.TranslateTo(-slInXStartposition, 0, 350, Easing.Linear);
        Task animation2 = stackLayoutIn.TranslateTo(0, 0, 350, Easing.Linear);
        await Task.WhenAll(animation1, animation2);
        NowStackLayout.IsVisible = false;
        NowStackLayout = stackLayoutIn;
    }

    private void TapGestureRecognizer_Tapped(object sender, TappedEventArgs e)
        => EmailCode.Focus();

    private void EmailCode_TextChanged(object sender, TextChangedEventArgs e)
    {
        if (sender is Entry entry)
        {
            string nextValue = e.NewTextValue ?? "";
            string oldValue = e.OldTextValue ?? "";

            if (nextValue.Length < oldValue.Length)
            {
                if (oldValue.Length < 5 && oldValue.Last() != '.' && oldValue.Last() != '-')
                {
                    CountSymbolsEmailCode--;
                    EmailCodeLabelDigits[CountSymbolsEmailCode].Text = "";
                }
                return;
            }

            if (CountSymbolsEmailCode < 4 && nextValue.Last() != '.' && nextValue.Last() != '-')
            {
                EmailCodeLabelDigits[CountSymbolsEmailCode].Text = nextValue[CountSymbolsEmailCode].ToString();
                CountSymbolsEmailCode++;
            }
            else
                entry.Text = oldValue;
        }
    }
}
