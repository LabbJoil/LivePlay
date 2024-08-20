
using LivePlay.Front.Core.Enums;
using LivePlay.Front.MAUI.Pages.UserPages.AccountPages.ViewModels;
using System;
using System.Reflection;
using System.Text;

namespace LivePlay.Front.MAUI.Pages.UserPages.AccountPages.Views;

public partial class MainPage : ContentPage
{
    private readonly MainViewModel MainVM;

    public MainPage(MainViewModel mainViewModel)
	{
		InitializeComponent();
        BindingContext = mainViewModel;
        MainVM = mainViewModel;

        const string pathYandexMapHTML = "Resources.Webs.YandexMapHTMLView.html";
        var info = Assembly.GetExecutingAssembly().GetName();
        var name = info.Name;
        using var stream = Assembly
            .GetExecutingAssembly()
            .GetManifestResourceStream($"{name}.{pathYandexMapHTML}")!;

        using var streamReader = new StreamReader(stream, Encoding.UTF8);
        YandexMapWebView.Source = new HtmlWebViewSource { Html = streamReader.ReadToEnd() };
    }

    public void MyCsharpMethod(string message)
    {
        Shell.Current.DisplayAlert("11", "Получено сообщение из JavaScript: " + message, "ok");
    }

    private void ContentPage_Appearing(object sender, EventArgs e)
    {
        MainVM.ChangeColorBars(MainGrid.BackgroundColor, Colors.White);
    }

    private void YandexMapWebView_Navigating(object sender, WebNavigatingEventArgs e)
    {
        //var urlParts = e.Url.Split(".");
        return;
        //if (urlParts[0].ToLower().Contains("runcsharp"))
        //{
        //    Console.WriteLine(urlParts);
        //    var funcToCall = urlParts[1].Split("?");
        //    var methodName = funcToCall[0];
        //    var funcParams = funcToCall[1];
        //    Console.WriteLine("Calling: " + methodName);
        //    e.Cancel = true;
        //}
    }
}