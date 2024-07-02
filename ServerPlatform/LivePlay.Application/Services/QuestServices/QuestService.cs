
using LivePlay.Server.Core.Interfaces.QuestInterfaces;
using LivePlay.Server.Core.Models;

namespace LivePlay.Server.Application.Services.QuestServices;

public class QuestService(IQuestRepository repository)
{
    private readonly IQuestRepository _questRepository = repository;

    public async Task<Quest[]> GetAllQuestsBase()
    {
        var allBaseQuests = await _questRepository.GetAll();
        return allBaseQuests;
    }

    public void DeleteQuest(int id)
    {
        _questRepository.Delete(id);
    }
}
