
using Camera.MAUI;
using Microsoft.Maui.Controls.Shapes;

namespace LivePlay.Front.MAUI.Pages.SettingsPages.Views;

public partial class LoadingPage : ContentPage, IQueryAttributable
{
    private VisualElement[] _visualElements = [];
    private readonly List<Task> _animationTasks = [];

    private CancellationToken _stopingAnimationToken;

    public LoadingPage()
    {
        InitializeComponent();
    }

    public void ApplyQueryAttributes(IDictionary<string, object> query)
    {
        if (query.TryGetValue($"{nameof(VisualElement)}sProperty", out object? ves) &&
            query.TryGetValue($"{nameof(CancellationTokenSource)}Property", out object? cts) &&
            ves is VisualElement[] visualElements && cts is CancellationTokenSource cancellationTokenSource)
        {
            _visualElements = visualElements;
            _stopingAnimationToken = cancellationTokenSource.Token;
        }
        else
            throw new Exception("Not all parameters were passed");
    }

    private async void ContentPage_Loaded(object sender, EventArgs e)
    {
        await StartAnimation();
        await WaitingDownload();
    }

   private async Task WaitingDownload()
    {
        await Task.WhenAll(_animationTasks);
        await Shell.Current.GoToAsync($"..");
    }

    private async Task StartAnimation()
    {
        var (xEnd, animationBorders) = CreateAnimation();
        if (animationBorders.Count == 0)
            return;
        while (animationBorders[0].Width < 1)
            await Task.Delay(100);

        for (int i = 0; i < animationBorders.Count; i++)
        {
            var taskCompletionSource = new TaskCompletionSource<bool>();
            TranslationXAnimation(taskCompletionSource, this, animationBorders[i], xEnd[i] + 30, -30);
            _animationTasks.Add(taskCompletionSource.Task);
        }
    }

    private readonly LinearGradientBrush gradientBrush = new()
    {
        StartPoint = new Point(0, 0.5),
        EndPoint = new Point(1, 0.5),
        GradientStops =
        [
            new GradientStop { Color = Colors.LightGray, Offset = 0 },
            new GradientStop { Color = Colors.White, Offset = 0.5f },
            new GradientStop { Color = Colors.LightGray, Offset = 1 }
        ]
    };

    private (List<double>, List<Border>) CreateAnimation()
    {
        List<double> xEnd = [];
        List<Border> animationLoadingBorders = [];

        IReadOnlyList<Type> FoundElements = [typeof(BarcodeImage), typeof(Label), typeof(Image), typeof(Entry)];

        var absoluteLayout = new AbsoluteLayout();

        foreach (var element in _visualElements)
        {
            if (element is VisualElement visualElement  && FoundElements.Contains(visualElement.GetType()))
            {

                var staticBorder = new Border()
                {
                    WidthRequest = visualElement.Width,
                    HeightRequest = visualElement.Height,
                    Background = Colors.Transparent,
                    Stroke = Colors.Black,
                    StrokeShape = new RoundRectangle() { CornerRadius = 5 },
                };

                AbsoluteLayout.SetLayoutBounds(staticBorder, new Rect(visualElement.X, visualElement.Y,
                    staticBorder.Width, staticBorder.Height));

                var animationGrid = new Grid()
                {
                    WidthRequest = visualElement.Width,
                    HeightRequest = visualElement.Height
                };

                var animationBorder = new Border()
                {
                    WidthRequest = 15,
                    HeightRequest = visualElement.Height + 10,
                    HorizontalOptions = LayoutOptions.Start,
                    Background = gradientBrush,
                    Stroke = Colors.Transparent,
                    StrokeShape = new RoundRectangle() { CornerRadius = 5 },
                    Rotation = 15
                };

                animationGrid.Children.Add(animationBorder);
                staticBorder.Content = animationGrid;
                absoluteLayout.Children.Add(staticBorder);

                xEnd.Add(visualElement.Width);
                animationLoadingBorders.Add(animationBorder);
            }
        }
        Content = absoluteLayout;
        return (xEnd, animationLoadingBorders);
    }

    private void TranslationXAnimation(TaskCompletionSource<bool> taskCompletionSource, IAnimatable owner, VisualElement visualElement,
        double xEnd, double? xStartOptional = null)
    {
        var nameAnimation = $"{visualElement.Id}TranslationX";
        var xStart = xStartOptional ?? visualElement.TranslationX;

        var animation = new Animation(v => visualElement.TranslationX = v, xStart, xEnd);
        animation.Commit(owner, nameAnimation, 10, 1500, Easing.Linear, endAnimation);

        async void endAnimation(double _, bool __)
        {
            this.AbortAnimation(nameAnimation);
            if (_stopingAnimationToken.IsCancellationRequested)
                taskCompletionSource.SetResult(true);
            else
            {
                await Task.Delay(1500);
                TranslationXAnimation(taskCompletionSource, owner, visualElement, xEnd, xStart);
            }
        }
    }
}