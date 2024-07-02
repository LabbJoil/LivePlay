
namespace LivePlay.Front.MAUI.Pages.SettingsPages.Views;

[QueryProperty(nameof(StopingAnimationSource), "StopingAnimationSource")]
public partial class LoadingPage : ContentPage
{
    public CancellationTokenSource? StopingAnimationSource { get; set; }

    private readonly Random Rand = new();
    private CancellationToken StopingAnimationToken;
    private readonly List<Task> RectangleAnimationTasks = [];

    public LoadingPage()
    {
        InitializeComponent();
    }

    private async void ContentPage_Loaded(object sender, EventArgs e)
    {
        if (StopingAnimationSource == null)
        {
            await StopAnimation();
            return;
        }
        StopingAnimationToken = StopingAnimationSource.Token;

        var allRectangles = new Border[] { rect1, rect2, rect3, rect4 };

        foreach (var rec in allRectangles)
        {
            var task = RectangleAnimation(rec);
            RectangleAnimationTasks.Add(task);
        }
        await StopAnimation();
    }

    private async Task RectangleAnimation(Border rectangle)
    {
        while (!StopingAnimationToken.IsCancellationRequested)
        {
            int direction = Rand.Next(0, 2);
            int offset = Rand.Next(100, 300);

            if (Rand.Next(0, 2) == 1)
                offset = -offset;

            if (MainGrid.Width < 0)
                offset = 0;

            switch (direction)
            {
                case 0:
                    var rectangleXNow = rectangle.TranslationX + rectangle.X + offset;
                    if (rectangleXNow > MainGrid.Width || rectangleXNow < 0)
                        offset = -offset;
                    TranslationXAnimation(this, rectangle, rectangle.TranslationX + offset);
                    break;

                case 1:
                    var rectangleYNow = rectangle.TranslationY + rectangle.Y + offset;
                    if (rectangleYNow > MainGrid.Height || rectangleYNow < 0)
                        offset = -offset;
                    TranslationYAnimation(this, rectangle, rectangle.TranslationY + offset);
                    break;
            }

            await Task.Delay(Rand.Next(1, 100) * 10);
        }
    }

    public async Task StopAnimation()
    {
        await Task.WhenAll(RectangleAnimationTasks);
        await Shell.Current.GoToAsync($"..");
    }

    private static void TranslationYAnimation(IAnimatable owner, VisualElement visualElement, double endAnimation, double? startAnimation = null)
    {
        var animationBackground = new Animation(v => visualElement.TranslationY = v, startAnimation ?? visualElement.TranslationY, endAnimation);
        animationBackground.Commit(owner, nameof(owner) + "TranslationY", 10, 1000);
    }

    private static void TranslationXAnimation(IAnimatable owner, VisualElement visualElement, double endAnimation, double? startAnimation = null)
    {
        var animationBackground = new Animation(v => visualElement.TranslationX = v, startAnimation ?? visualElement.TranslationX, endAnimation);
        animationBackground.Commit(owner, nameof(owner) + "TranslationX", 10, 1000);
    }
}