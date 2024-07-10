
using LivePlay.Front.MAUI.DeviceSettings;
using Microsoft.Maui.Controls;
using System.Windows.Input;
using LivePlay.Front.Core.Models.QuestModels;

namespace LivePlay.Front.MAUI.PersonalElements;

public partial class QuestionQuestItemControl : ContentView
{
    private List<CheckBox> CheckBoxes { get; }

    public static readonly BindableProperty NowQuestionQuestProperty = BindableProperty.Create(
       propertyName: nameof(NowQuestionQuest),
       returnType: typeof(QuestionQuest),
       declaringType: typeof(QuestionQuestItemControl),
       defaultValue: null,
       defaultBindingMode: BindingMode.TwoWay);

    public QuestionQuest NowQuestionQuest
    {
        get => (QuestionQuest)GetValue(NowQuestionQuestProperty);
        set
        {
            SetValue(NowQuestionQuestProperty, value);
            CheckBoxes[value.RightAnswer].IsChecked = true;
        }
    }

    public QuestionQuestItemControl()
    {
        InitializeComponent();
        CheckBoxes = [CheckBox1, CheckBox2, CheckBox3, CheckBox4];
        CheckBox1.IsChecked = true;
        NowQuestionQuest = new();
    }

    private void CheckBox1_CheckedChanged(object sender, CheckedChangedEventArgs e)
    {
        if (sender is CheckBox ch)
        {
            if (ch.IsChecked == true)
                foreach (CheckBox cb in CheckBoxes)
                {
                    if (ch != cb && cb.IsChecked)
                    {
                        cb.IsChecked = false;
                        break;
                    }
                }
            else if (ch.IsChecked == false)
            {
                foreach (CheckBox cb in CheckBoxes)
                    if (ch != cb && cb.IsChecked)
                        return;
                ch.IsChecked = true;
            }

            if (NowQuestionQuest != null)
                NowQuestionQuest.RightAnswer = Enumerable.Range(0, CheckBoxes.Count).FirstOrDefault(b => CheckBoxes[b] == ch);
        }

    }

    private async void ImageButton_Clicked(object sender, EventArgs e)
    {
        var imagePath = await AppStorage.GetOneItemStorage();
        NowQuestionQuest.Image = File.ReadAllBytes(imagePath);
    }
}