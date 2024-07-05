
using CommunityToolkit.Maui.Views;
using CommunityToolkit.Mvvm.Input;
using LivePlay.Front.MAUI.Abstracts;
using LivePlay.Front.MAUI.DeviceSettings;
using System.Text.Json;

namespace LivePlay.Front.MAUI.Pages.UserPages.QuestPages.InProgress.ViewModels;

public partial class InProgressDrawingQuestViewModel(AppDesign designSettings) : BaseQuestViewModel(designSettings)
{
    [RelayCommand]
    public async Task ChooseFiles()
    {
        await AppStorage.GetSelectItemsStorage();
    }

    [RelayCommand]
    public async Task SendAnswer(DrawingView drawingView)
    {
        var serializeLines = JsonSerializer.Serialize(drawingView.Lines);

    }
}
