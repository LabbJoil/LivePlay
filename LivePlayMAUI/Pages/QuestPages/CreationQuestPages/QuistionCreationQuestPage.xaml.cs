using Microsoft.Maui.Controls;

namespace LivePlayMAUI.Pages.QuestPages.CreationQuestPages;

public partial class QuestionCreationQuestPage : ContentPage
{
    private List<CheckBox> checkBoxes { get; }

	public QuestionCreationQuestPage()
	{

        InitializeComponent();
        checkBoxes = [CheckBox1, CheckBox2, CheckBox3, CheckBox4];
    }

    private void CheckBox1_CheckedChanged(object sender, CheckedChangedEventArgs e)
    {
		if (sender is CheckBox ch && ch.IsChecked == true)
		{
            foreach (CheckBox cb in checkBoxes)
            {
                if (ch != cb && cb.IsChecked)
                    cb.IsChecked = false;
            }
        }

    }
}