
using CommunityToolkit.Maui.Views;
using CommunityToolkit.Mvvm.Input;
using LivePlay.Front.Infrastructure.HttpServices.QuestHttpServices;
using LivePlay.Front.MAUI.Abstracts;
using LivePlay.Front.MAUI.DeviceSettings;
using System.Text;
using System.Text.Json;

namespace LivePlay.Front.MAUI.Pages.UserPages.QuestPages.InProgress.ViewModels;

public partial class InProgressDrawingQuestViewModel(AppDesign designSettings, DrawingQuestHttpService drawingQuestHttpService) : BaseQuestViewModel(designSettings)
{
    private readonly DrawingQuestHttpService _drawingQuestHttpService = drawingQuestHttpService;

    [RelayCommand]
    public async Task ChooseFiles()
    {
        await AppStorage.GetSelectItemsStorage();
    }

    [RelayCommand]
    public async Task SendAnswer(DrawingView drawingView)
    {
        var serializeLines = JsonSerializer.Serialize(drawingView.Lines);
        var bytesLines = Encoding.UTF8.GetBytes(serializeLines);

        StartLoading();
        var error = await _drawingQuestHttpService.CompeteQuest(new() { PictureInfo = bytesLines}, CurrentQuestItem.Id);
        StopLoading();

        if (error != null)
        {
            ShowError(error);
            return;
        }

    }
}
