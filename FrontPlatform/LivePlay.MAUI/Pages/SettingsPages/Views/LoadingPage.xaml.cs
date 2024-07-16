
using Camera.MAUI;
using Microsoft.Maui.Controls.Shapes;
using Microsoft.Maui.Layouts;
using System.Text.Json;
using System.Web;

namespace LivePlay.Front.MAUI.Pages.SettingsPages.Views;

public partial class LoadingPage : ContentPage, IQueryAttributable
{
    private ContentPage? _contentPageProperty;
    private readonly List<Task> AnimationTasks = [];

    private CancellationToken _stopingAnimationToken;

    public LoadingPage()
    {
        InitializeComponent();
    }

    public void ApplyQueryAttributes(IDictionary<string, object> query)
    {
        if (query.TryGetValue($"{nameof(ContentPage)}Property", out object? cp) &&
            query.TryGetValue($"{nameof(CancellationTokenSource)}Property", out object? cts) &&
            cp is ContentPage contentPage && cts is CancellationTokenSource cancellationTokenSource)
        {
            _contentPageProperty = contentPage;
            //_cancellationTokenSourceProperty = cancellationTokenSource;
            _stopingAnimationToken = cancellationTokenSource.Token;
        }
        else
            throw new Exception("Not all parameters were passed");
    }

    private async void ContentPage_Loaded(object sender, EventArgs e)
    {
        if (_contentPageProperty != null)
            await StartAnimation(_contentPageProperty);
        await WaitingDownload();
    }

   private async Task WaitingDownload()
    {
        await Task.WhenAll(AnimationTasks);
        await Shell.Current.GoToAsync($"..");
    }

    private async Task StartAnimation(ContentPage personalQRPage)
    {
        var (staticBorders, animationBorders) = CreateAnimation(personalQRPage.GetVisualTreeDescendants());
        while (staticBorders[0].Width < 1)      // TODO: проверка на наличие элементов
            await Task.Delay(100);
        for (int i = 0; i < animationBorders.Count; i++)
        {
            var animation = TranslationXAnimation(this, animationBorders[i], staticBorders[i].Width + 60, staticBorders[i].TranslationX - 60);
            AnimationTasks.Add(animation);
        }
    }

    private readonly LinearGradientBrush gradientBrush = new()
    {
        StartPoint = new Point(0, 0.5),
        EndPoint = new Point(1, 0.5),
        GradientStops =
        [
            new GradientStop { Color = Colors.Gray, Offset = 0 },
            new GradientStop { Color = Colors.White, Offset = 0.5f },
            new GradientStop { Color = Colors.Gray, Offset = 1 }
        ]
    };

    private (List<Border>, List<Border>) CreateAnimation(IReadOnlyList<IVisualTreeElement> elements)
    {
        List<Border> staticLoadingBorders = [];
        List<Border> animationLoadingBorders = [];

        Type[] FoundElements = [typeof(BarcodeImage), typeof(Label)];//, typeof(Image), typeof(Entry)];

        var absoluteLayout = new AbsoluteLayout();

        foreach (var element in elements)
        {
            if (element is VisualElement visualElement  && FoundElements.Contains(visualElement.GetType()))
            {

                var border = new Border()
                {
                    WidthRequest = visualElement.Width,
                    HeightRequest = visualElement.Height,
                    Background = Colors.Transparent,
                    Stroke = Colors.Black,
                    StrokeShape = new RoundRectangle() { CornerRadius = 5 },
                };

                var grid = new Grid()
                {
                    WidthRequest = visualElement.Width,
                    HeightRequest = visualElement.Height
                };

                AbsoluteLayout.SetLayoutBounds(border, new Rect(visualElement.X, visualElement.Y,
                    border.Width, border.Height));

                var animationBorder = new Border()
                {
                    WidthRequest = 15,
                    HeightRequest = visualElement.Height,
                    HorizontalOptions = LayoutOptions.Start,
                    Background = gradientBrush,
                    Stroke = Colors.Transparent,
                    StrokeShape = new RoundRectangle() { CornerRadius = 5 },
                    Rotation = 15
                };

                grid.Children.Add(animationBorder);
                border.Content = grid;
                absoluteLayout.Children.Add(border);

                staticLoadingBorders.Add(border);
                animationLoadingBorders.Add(animationBorder);
            }
        }
        Content = absoluteLayout;
        return (staticLoadingBorders, animationLoadingBorders);
    }

    private Task<bool> TranslationXAnimation(IAnimatable owner, VisualElement visualElement, double xEnd, double? xStartOptional = null)
    {
        var nameAnimation = $"{visualElement.Id}TranslationX";
        var xStart = xStartOptional ?? visualElement.TranslationX;
        var taskCompletionSource = new TaskCompletionSource<bool>();

        var animation = new Animation(v => visualElement.TranslationX = v, xStart, xEnd);
        animation.Commit(owner, nameAnimation, 10, 1500, Easing.Linear, (v, c) => visualElement.TranslationX = xStart, repeat);

        bool repeat()
        {
            if (_stopingAnimationToken.IsCancellationRequested)
            {
                this.AbortAnimation(nameAnimation);
                taskCompletionSource.SetResult(true);
                return false;
            }
            //await Task.Delay(1500);
            //var t =Task.Run(async () => await Task.Delay(1500)).Wait();
            return true;
        };

        return taskCompletionSource.Task;
    }
}