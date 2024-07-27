
using CommunityToolkit.Maui.Views;
using CommunityToolkit.Mvvm.Input;
using LivePlay.Front.Infrastructure.HttpServices;
using LivePlay.Front.Infrastructure.HttpServices.QuestHttpServices;
using LivePlay.Front.Infrastructure.Interfaces;
using LivePlay.Front.MAUI.Abstracts;
using LivePlay.Front.MAUI.DeviceSettings;
using System.Text;
using System.Text.Json;

namespace LivePlay.Front.MAUI.Pages.UserPages.QuestPages.InProgress.ViewModels;

public partial class InProgressDrawingQuestViewModel : BaseQuestViewModel
{
    private readonly DrawingQuestHttpService _drawingQuestHttpService;

    public InProgressDrawingQuestViewModel(IServiceScopeFactory serviceScopeFactory) : base(serviceScopeFactory)
    {
        using var scope = serviceScopeFactory.CreateScope();
        _drawingQuestHttpService = scope.ServiceProvider.GetRequiredService<DrawingQuestHttpService>();
    }

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

        StartMiddleLoading();
        var error = await _drawingQuestHttpService.CompeteQuest(new() { PictureInfo = bytesLines}, CurrentQuestItem.Id);
        StopLoading();

        if (error != null)
        {
            ShowError(error);
            return;
        }

    }
}
