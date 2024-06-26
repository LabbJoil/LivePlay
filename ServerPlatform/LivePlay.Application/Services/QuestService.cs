
using LivePlay.Server.Core.Interfaces;
using LivePlay.Server.Core.Models;
using System.Security.Claims;

namespace LivePlay.Server.Application.Services;

public class QuestService(IQuestRepository repository)
{
    private readonly IQuestRepository _questRepository = repository;

    public void AddQuest<T>(Quest quest, T? subquest = null) where T : class
    {
        _questRepository.AddQuest(quest, subquest);
    }

    public void EditQuest<T>(Quest quest, T? subquest = null) where T : class
    {
        _questRepository.EditQuest(quest, subquest);
    }

    public async Task<Quest[]> GetAllQuestsBase()
    {
        var allBaseQuests = await _questRepository.GetAll();
        return allBaseQuests;
    }

    public async Task<(Quest, dynamic)> GetQuest(int idQuest)
    {
        var fullQuest = await _questRepository.GetQuestById(idQuest);
        return fullQuest;
    }

    public void DeleteQuest(int id)
    {
        _questRepository.Delete(id);
    }

    public async void CompleteQuestionQuest(ClaimsPrincipal claims, int idQuest, Dictionary<int, int> questionAnswers)
    {
        _questRepository.
    }
}
