
using LivePlay.Server.Core.Interfaces.Quests;
using LivePlay.Server.Core.Models;

namespace LivePlay.Server.Application.Services.Quests;

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
