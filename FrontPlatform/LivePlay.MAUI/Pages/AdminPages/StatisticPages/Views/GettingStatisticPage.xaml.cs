
namespace LivePlay.Front.MAUI.Pages.AdminPages.StaticPages;

public partial class GettingStatisticsPage : ContentPage
{
    public DateTime MinDate { get; set; } = DateTime.UtcNow.AddDays(1);

    public GettingStatisticsPage()
	{
		InitializeComponent();
		BindingContext = this;
	}

    private async void ImageButton_Clicked(object sender, EventArgs e)
    {
        //var newQuestItem = new QuestItem
        //{
        //    Title = Title.Text,
        //    Description = DescriptionMini.Text,
        //    TotalDescription = Description.Text,
        //    FinalDate = DateQuest.Date,
        //    Price = int.Parse(Price.SelectedItem.ToString()),
        //    Type = TypeQuest.Search
        //};

        //var shellParameters = new ShellNavigationQueryParameters { { $"QuestItemProperty", newQuestItem } };
    }
}