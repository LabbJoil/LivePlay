
using LivePlay.Front.Core.Enums;
using LivePlay.Front.MAUI.Pages.EnterPages.ViewModels;

namespace LivePlay.Front.MAUI.Pages.EnterPages.Views;

public partial class EnterPage : ContentPage
{
    private StackLayout NowStackLayout;
    private readonly EnterViewModel EnterVM;

    private int CountSymbolsEmailCode = 0;
    private Label[] EmailCodeLabelDigits { get; }

    public EnterPage(EnterViewModel enterPage)
    {
        InitializeComponent();
        BindingContext = enterPage;
        EnterVM = enterPage;
        EmailCodeLabelDigits = [OneEmailCodeDigit, TwoEmailCodeDigit, ThreeEmailCodeDigit, FourEmailCodeDigit];
        NowStackLayout = LoginStackLayout;
    }

    private void ContentPage_Appearing(object sender, EventArgs e)
    {
        EnterVM.ChangeColorBars(BackgroundColor, StatusBarColor.BarReplay);
    }

    private void ContentPage_Disappearing(object sender, EventArgs e)
    {
        LoginPassword.Text = string.Empty;
        LoginEmail.Text = string.Empty;
        LoginPassword.IsPassword = true;
    }

    // -- SwitchButtons --

    private async Task LogInButtonClicked(object sender, EventArgs e)
        => await LoginFrontProcess();

    private async Task SignUpButtonClicked(object sender, EventArgs e)
        => await ChangeStackLayout(EmailStackLayout, DirectionAction.Left);

    // -- ViewModel --

    public async Task<(Action<object?>, Action)> VerifyEmailFrontProcess()
    {
        await ChangeStackLayout(CodeStackLayout, DirectionAction.Left);
        return GetPrintEndTimerActions();
    }

    public async Task FillUserInfoFrontProcess()
        => await ChangeStackLayout(UserInfoStackLayout, DirectionAction.Left);

    public async Task LoginFrontProcess()
        => await ChangeStackLayout(LoginStackLayout, DirectionAction.Right);

    public (Action<object?>, Action) GetPrintEndTimerActions()
    {
        return (PrintTimer, EndTimer);

        void PrintTimer(object? obj)
        {
            if (obj is int fullMilliseconds)
            {
                var fullSeconds = fullMilliseconds / 1000;
                var minutes = fullSeconds / 60;
                var seconds = fullSeconds % 60;
                TimerLabel.Text = string.Format("{0:d2}:{1:d2}", minutes, seconds);
            }
        }

        void EndTimer()
        {
            SendCodeButton.IsEnabled = true;
            TimerLabel.Text = "00:00";
        }
    }

    private async Task ChangeStackLayout(StackLayout stackLayoutIn, DirectionAction swipeSlIn)
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
