
using CommunityToolkit.Maui.Core;
using LivePlay.Front.MAUI.Pages.UserPages.QuestPages.InProgress.ViewModels;
using System.Text.Json;

namespace LivePlay.Front.MAUI.Pages.UserPages.QuestPages.InProgress.Views;

//[QueryProperty(nameof(QuestItemProperty), nameof(QuestItemProperty))]
public partial class InProgressDrawingQuestPage : ContentPage
{
    //public QuestItem QuestItemProperty {
    //    set => InProgressPhotoVM.CurrentQuestItem = value;
    //}
    private readonly InProgressDrawingQuestViewModel InProgressPhotoVM;

    public InProgressDrawingQuestPage(InProgressDrawingQuestViewModel inProgressPhotoVM)
    {
        InitializeComponent();
        BindingContext = inProgressPhotoVM;
        InProgressPhotoVM = inProgressPhotoVM;
    }

    private void ChangeLineColor(object sender, EventArgs e)
    {
        if(sender is Button btn)
        {
            Drawing.LineColor = btn.BackgroundColor;
        }
    }

    private void ChangeLineWidth(object sender, EventArgs e)
    {
        if (sender is Button btn)
        {
            Drawing.LineWidth = (float)(btn.Width - 5);
        }
    }

    private void ClearDrawing(object sender, EventArgs e)
    {
        Drawing.Clear();
        DeletedDrawingLines.Clear();
        UndoButton.IsEnabled = false;
        RepeatButton.IsEnabled = false;
    }

    private Stack<IDrawingLine> DeletedDrawingLines = [];

    private void RemoveLastLine(object sender, EventArgs e)
    {
        if (Drawing.Lines.Count > 0)
        {
            DeletedDrawingLines.Push(Drawing.Lines.Last());
            Drawing.Lines.Remove(Drawing.Lines.Last());
            RepeatButton.IsEnabled = true;
        }
        if (Drawing.Lines.Count == 0)
            UndoButton.IsEnabled = false;
    }

    private void Repeat_Clicked(object sender, EventArgs e)
    {
        Drawing.Lines.Add(DeletedDrawingLines.Pop());
        UndoButton.IsEnabled = true;
        if (DeletedDrawingLines.Count == 0)
        {
            RepeatButton.IsEnabled = false;
        }
    }

    private void Drawing_DrawingLineCompleted(object sender, DrawingLineCompletedEventArgs e)
    {
        UndoButton.IsEnabled = true;
    }

    private async void Button_Clicked(object sender, EventArgs e)
    {
        var serializeLines = JsonSerializer.Serialize(Drawing.Lines);
    }
}