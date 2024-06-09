using LivePlayMAUI.Enum;
using LivePlayMAUI.Models.Domain;

namespace LivePlayMAUI.Pages.QuestPages.CreationQuestPages;

public partial class MainCreationQuestPage : ContentPage
{
    public DateTime MinDate { get; set; } = DateTime.UtcNow.AddDays(1);

    public MainCreationQuestPage()
	{
		InitializeComponent();
		BindingContext = this;
	}

    private async void ImageButton_Clicked(object sender, EventArgs e)
    {
        var newQuestItem = new QuestItem
        {
            Title = Title.Text,
            Description = DescriptionMini.Text,
            TotalDescription = Description.Text,
            FinalDate = DateQuest.Date,
            Price = int.Parse(Price.SelectedItem.ToString()),
            Type = TypeQuest.Search
        };

        var shellParameters = new ShellNavigationQueryParameters { { $"QuestItemProperty", newQuestItem } };

        await Shell.Current.GoToAsync($"{nameof(QuestionCreationQuestPage)}", shellParameters);
    }
}