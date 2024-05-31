using LivePlayMAUI.Models.Domain;
using LivePlayMAUI.Pages.AccountPages;
using LivePlayMAUI.Services;
using Microsoft.Maui.Controls;
using System.Reflection;
using System.Text.Json;

namespace LivePlayMAUI.Pages.QuestPages.CreationQuestPages;

[QueryProperty(nameof(QuestItemProperty), nameof(QuestItemProperty))]
public partial class QuestionCreationQuestPage : ContentPage
{
    private List<CheckBox> checkBoxes { get; }
    private DeviceStorage DeviceStorage { get; }
    public QuestItem QuestItemProperty { get; set; }

    private string ImageChosePath = string.Empty;

    public QuestionCreationQuestPage(DeviceStorage deviceStorage)
	{
        InitializeComponent();
        checkBoxes = [CheckBox1, CheckBox2, CheckBox3, CheckBox4];
        CheckBox1.IsChecked = true;
        DeviceStorage = deviceStorage;
    }

    private void CheckBox1_CheckedChanged(object sender, CheckedChangedEventArgs e)
    {
		if (sender is CheckBox ch)
		{
            if(ch.IsChecked == true)
                foreach (CheckBox cb in checkBoxes)
                {
                    if (ch != cb && cb.IsChecked)
                    {
                        cb.IsChecked = false;
                        return;
                    }
                }
            else if (ch.IsChecked == false)
            {
                foreach (CheckBox cb in checkBoxes)
                    if (ch != cb && cb.IsChecked)
                        return;
                ch.IsChecked = true;
            }
        }

    }

    private async void Button_Clicked(object sender, EventArgs e)
    {
        var hehe = new QuestionQuestModel
        {
            Question = Question.Text,
            Answer1 = Answer1.Text,
            Answer2 = Answer2.Text,
            Answer3 = Answer3.Text,
            Answer4 = Answer4.Text,
            RightAnswer = Enumerable.Range(0, checkBoxes.Count).FirstOrDefault(b => checkBoxes[b].IsChecked == true),
            ImagePath = ImageChosePath,
            NowItem = QuestItemProperty
        };
        Preferences.Set(nameof(QuestionQuestModel), JsonSerializer.Serialize(hehe));
        await Shell.Current.DisplayAlert("Создан", "Квест успешно создан", "ok");
        await Shell.Current.GoToAsync($"//{nameof(EmptyPage)}");
    }

    private async void ImageButton_Clicked(object sender, EventArgs e)
    {
        ImageChosePath = await DeviceStorage.GetOneItemStorage();
        GetImage.Source = ImageChosePath;
    }
}