
using LivePlay.Front.Infrastructure.HttpServices;
using LivePlay.Front.Infrastructure.HttpServices.QuestHttpServices;
using LivePlay.Front.Infrastructure.Interfaces;
using LivePlay.Front.MAUI.Abstracts;
using LivePlay.Front.MAUI.DeviceSettings;

namespace LivePlay.Front.MAUI.Pages.AdminPages.QuestPages.Creations.ViewModels;

public class CreationDrawingQuestViewModel : BaseQuestViewModel
{
    private readonly DrawingQuestHttpService _drawingQuestHttpService;

    public CreationDrawingQuestViewModel(IServiceScopeFactory serviceScopeFactory) : base(serviceScopeFactory)
    {
        using var scope = serviceScopeFactory.CreateScope();
        _drawingQuestHttpService = scope.ServiceProvider.GetRequiredService<DrawingQuestHttpService>();
    }

    public async Task CreateQuest()
    {

    }
}
