
using LivePlay.Front.Core.Enums;
using LivePlay.Front.Core.Models;

namespace LivePlay.Front.MAUI.Pages.QuestPages.CreationQuestPages;

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
            Type = (TypeQuest)PickerQuest.SelectedIndex
        };

        var shellParameters = new ShellNavigationQueryParameters { { $"QuestItemProperty", newQuestItem } };

        await Shell.Current.GoToAsync($"{nameof(QRcodeCreationQuestPage)}", shellParameters);
    }
}