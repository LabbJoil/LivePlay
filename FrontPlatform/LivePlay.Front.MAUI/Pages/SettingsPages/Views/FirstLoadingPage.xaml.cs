
using Camera.MAUI;
using Microsoft.Maui.Controls.Shapes;

namespace LivePlay.Front.MAUI.Pages.SettingsPages.Views;

public partial class FirstLoadingPage : ContentPage, IQueryAttributable
{
    private VisualElement[] _visualElements = [];
    private CancellationTokenSource? _stopingAnimationSource;

    public FirstLoadingPage()
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
            _stopingAnimationSource = cancellationTokenSource;
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
        while (_stopingAnimationSource != null && !_stopingAnimationSource.IsCancellationRequested)
            await Task.Delay(50);
        Content = null;
    }

    private async Task StartAnimation()
    {
        var borderAnimations = CreateContent();
        if (borderAnimations.Count == 0)
            return;

        while (!borderAnimations.All(ba => ba.Item1.IsLoaded))
            await Task.Delay(100);

        foreach (var borderAnimation in borderAnimations)
        {
            var percent10 = borderAnimation.Item2 * 30 / 100;
            TranslationXAnimation(this, borderAnimation.Item1, borderAnimation.Item2 + percent10, -percent10);
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

    private List<(Border, double)> CreateContent()
    {
        List<(Border, double)> borderAnimations = [];
        var absoluteLayout = new AbsoluteLayout();

        foreach (var visualElement in _visualElements)
        {
            var staticBorder = new Border()
            {
                WidthRequest = visualElement.Width,
                HeightRequest = visualElement.Height,
                BackgroundColor = Colors.LightGray,
                Stroke = Colors.Transparent,
                StrokeShape = new RoundRectangle() { CornerRadius = 5 },
                Shadow = new Shadow()
                {
                    Brush = Colors.Black,
                    Radius = 40,
                    Opacity = 0.8f
                },
            };

            var animationGrid = new Grid()
            {
                WidthRequest = visualElement.Width,
                HeightRequest = visualElement.Height
            };

            AbsoluteLayout.SetLayoutBounds(animationGrid, new Rect(visualElement.X, visualElement.Y,
                animationGrid.Width, animationGrid.Height));

            var animationBorder = new Border()
            {
                WidthRequest = 15,
                HeightRequest = visualElement.Height + visualElement.Height * 10 / 100,
                HorizontalOptions = LayoutOptions.Start,
                Background = gradientBrush,
                Stroke = Colors.Transparent,
                StrokeShape = new RoundRectangle() { CornerRadius = 5 },
                Rotation = 15
            };

            absoluteLayout.Children.Add(staticBorder);
            staticBorder.Content = animationGrid;
            animationGrid.Children.Add(animationBorder);

            borderAnimations.Add((animationBorder, visualElement.Width));
        }
        Content = absoluteLayout;
        return borderAnimations;
    }

    private void TranslationXAnimation(IAnimatable owner, VisualElement visualElement,
        double xEnd, double? xStartOptional = null)
    {
        var nameAnimation = $"{visualElement.Id}TranslationX";
        var xStart = xStartOptional ?? visualElement.TranslationX;

        var animation = new Animation(v => visualElement.TranslationX = v, xStart, xEnd);
        animation.Commit(owner, nameAnimation, 10, 1500, Easing.Linear, endAnimation);

        async void endAnimation(double _, bool __)
        {
            this.AbortAnimation(nameAnimation);
            if (_stopingAnimationSource != null && !_stopingAnimationSource.IsCancellationRequested)
            {
                await Task.Delay(1500);
                TranslationXAnimation(owner, visualElement, xEnd, xStart);
            }
        }
    }
}