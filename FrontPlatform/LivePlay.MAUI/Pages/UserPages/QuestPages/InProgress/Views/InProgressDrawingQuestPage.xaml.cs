
using CommunityToolkit.Maui.Core;
using LivePlay.Front.Core.Models.QuestModels;
using LivePlay.Front.MAUI.Pages.UserPages.QuestPages.InProgress.ViewModels;
using System.Text.Json;

namespace LivePlay.Front.MAUI.Pages.UserPages.QuestPages.InProgress.Views;

[QueryProperty(nameof(QuestProperty), nameof(QuestProperty))]
public partial class InProgressDrawingQuestPage : ContentPage
{
    public Quest QuestProperty
    {
        set => InProgressDrawingQuestVM.CurrentQuestItem = value;
    }

    private readonly InProgressDrawingQuestViewModel InProgressDrawingQuestVM;

    public InProgressDrawingQuestPage(InProgressDrawingQuestViewModel inProgressDrawingQuestVM)
    {
        InitializeComponent();
        BindingContext = inProgressDrawingQuestVM;
        InProgressDrawingQuestVM = inProgressDrawingQuestVM;
    }

    private void ChangeLineColor(object sender, EventArgs e)
    {
        if(sender is Button btn)
        {
            DrawingViewDraw.LineColor = btn.BackgroundColor;
        }
    }

    private void ChangeLineWidth(object sender, EventArgs e)
    {
        if (sender is Button btn)
        {
            DrawingViewDraw.LineWidth = (float)(btn.Width - 5);
        }
    }

    private void ClearDrawing(object sender, EventArgs e)
    {
        DrawingViewDraw.Clear();
        DeletedDrawingLines.Clear();
        UndoButton.IsEnabled = false;
        RepeatButton.IsEnabled = false;
    }

    private Stack<IDrawingLine> DeletedDrawingLines = [];

    private void RemoveLastLine(object sender, EventArgs e)
    {
        if (DrawingViewDraw.Lines.Count > 0)
        {
            DeletedDrawingLines.Push(DrawingViewDraw.Lines.Last());
            DrawingViewDraw.Lines.Remove(DrawingViewDraw.Lines.Last());
            RepeatButton.IsEnabled = true;
        }
        if (DrawingViewDraw.Lines.Count == 0)
            UndoButton.IsEnabled = false;
    }

    private void Repeat_Clicked(object sender, EventArgs e)
    {
        DrawingViewDraw.Lines.Add(DeletedDrawingLines.Pop());
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

    //private async void Button_Clicked(object sender, EventArgs e)
    //{
    //    var serializeLines = JsonSerializer.Serialize(Drawing.Lines);
    //}
}