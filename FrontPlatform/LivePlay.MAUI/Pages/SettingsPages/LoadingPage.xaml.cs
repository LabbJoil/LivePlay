
namespace LivePlayMAUI.Pages;

[QueryProperty(nameof(LoadPageRoute), "LoadPageRoute")]
public partial class LoadingPage : ContentPage
{
    private readonly Random Rand = new ();
    public string LoadPageRoute { get; set; }

    public LoadingPage()
	{
		InitializeComponent();

        StartAnimation(rect1);
        StartAnimation(rect2);
        StartAnimation(rect3);
        StartAnimation(rect4);

    }

    private async void ContentPage_Loaded(object sender, EventArgs e)
    {
        await Task.Delay(Rand.Next(100, 300) * 10);
        await Shell.Current.GoToAsync($"//{LoadPageRoute}");
    }

    private async void StartAnimation(Border rectangle)
    {
        while (true)
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

    public static void TranslationYAnimation(IAnimatable owner, VisualElement visualElement, double endAnimation, double? startAnimation = null)
    {
        var animationBackground = new Animation(v => visualElement.TranslationY = v, startAnimation ?? visualElement.TranslationY, endAnimation);
        animationBackground.Commit(owner, nameof(owner) + "TranslationY", 10, 1000);
    }

    public static void TranslationXAnimation(IAnimatable owner, VisualElement visualElement, double endAnimation, double? startAnimation = null)
    {
        var animationBackground = new Animation(v => visualElement.TranslationX = v, startAnimation ?? visualElement.TranslationX, endAnimation);
        animationBackground.Commit(owner, nameof(owner) + "TranslationX", 10, 1000);
    }
}