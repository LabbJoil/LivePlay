
using LivePlay.Front.Infrastructure.HttpServices.QuestHttpServices;
using LivePlay.Front.MAUI.Abstracts;
using LivePlay.Front.MAUI.DeviceSettings;

namespace LivePlay.Front.MAUI.Pages.AdminPages.QuestPages.Creations.ViewModels;

public class CreationDrawingQuestViewModel(AppDesign appDesign, DrawingQuestHttpService drawingQuestHttpService):BaseQuestViewModel(appDesign)
{
    private readonly DrawingQuestHttpService _drawingQuestHttpService = drawingQuestHttpService;

    public async Task CreateQuest()
    {

    }
}
