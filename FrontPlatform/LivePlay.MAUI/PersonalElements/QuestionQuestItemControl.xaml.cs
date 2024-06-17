using LivePlay.Front.Application.DeviceSettings;
using LivePlay.Front.Core.Models;
using LivePlay.Front.MAUI.Pages.QuestPages.CreationQuestPages;
using Microsoft.Maui.Controls;
using System.Windows.Input;

namespace LivePlay.Front.MAUI.PersonalElements;

public partial class QuestionQuestItemControl : ContentView
{
    private List<CheckBox> CheckBoxes { get; }

    public static readonly BindableProperty ForwardItemCommandProperty = BindableProperty.Create(
       propertyName: nameof(ForwardItemCommand),
       returnType: typeof(ICommand),
       declaringType: typeof(QuestionQuestItemControl),
       defaultValue: null,
       defaultBindingMode: BindingMode.TwoWay);

    public ICommand ForwardItemCommand
    {
        get => (ICommand)GetValue(ForwardItemCommandProperty);
        set => SetValue(ForwardItemCommandProperty, value);
    }

    public static readonly BindableProperty PreviousItemCommandProperty = BindableProperty.Create(
       propertyName: nameof(PreviousItemCommand),
       returnType: typeof(ICommand),
       declaringType: typeof(QuestionQuestItemControl),
       defaultValue: null,
       defaultBindingMode: BindingMode.TwoWay);

    public ICommand PreviousItemCommand
    {
        get => (ICommand)GetValue(PreviousItemCommandProperty);
        set => SetValue(PreviousItemCommandProperty, value);
    }

    public static readonly BindableProperty NowQuestionQuestProperty = BindableProperty.Create(
       propertyName: nameof(NowQuestionQuest),
       returnType: typeof(QuestionQuestModel),
       declaringType: typeof(QuestionQuestItemControl),
       defaultValue: null,
       defaultBindingMode: BindingMode.TwoWay);

    public static readonly BindableProperty ParentPageProperty = BindableProperty.Create(
       propertyName: nameof(ParentPage),
       returnType: typeof(QuestionCreationQuestPage),
       declaringType: typeof(QuestionQuestItemControl),
       defaultValue: null,
       defaultBindingMode: BindingMode.TwoWay);

    public QuestionCreationQuestPage ParentPage
    {
        get => (QuestionCreationQuestPage)GetValue(ParentPageProperty);
        set => SetValue(ParentPageProperty, value);
    }

    public QuestionQuestModel NowQuestionQuest
    {
        get => (QuestionQuestModel)GetValue(NowQuestionQuestProperty);
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

    private void Button_Clicked(object sender, EventArgs e)
    {
        //var parentPage = GetParentPage(Parent);
        ForwardItemCommand.Execute((ParentPage, NowQuestionQuest));
    }

    //private static QuestionCreationQuestPage GetParentPage(Element element)
    //{
    //    if (element is QuestionCreationQuestPage question)
    //        return question;
    //    return GetParentPage(element.Parent);
    //}

    private async void ImageButton_Clicked(object sender, EventArgs e)
    {
        NowQuestionQuest.ImagePath = await AppStorage.GetOneItemStorage();
    }

    private void PreviousItem(object sender, EventArgs e)
    {
        PreviousItemCommand.Execute((ParentPage, NowQuestionQuest));
    }

    private void ForwardItem(object sender, EventArgs e)
    {
        ForwardItemCommand.Execute((ParentPage, NowQuestionQuest));
    }
}