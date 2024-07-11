
using LivePlay.Server.Application.Interfaces;
using LivePlay.Server.Core.CustomExceptions;
using LivePlay.Server.Core.Enums;
using LivePlay.Server.Core.Interfaces.QuestInterfaces;
using LivePlay.Server.Core.Models;
using System.Security.Claims;

namespace LivePlay.Server.Application.Services.QuestServices;

public class QuestService(IQuestRepository repository, IJwtProvider jwtProvider)
{
    private readonly IQuestRepository _questRepository = repository;
    private readonly IJwtProvider _jwtProvider = jwtProvider;

    public async Task<Quest[]> GetAllQuestsBase()
    {
        var allBaseQuests = await _questRepository.GetAll();
        return allBaseQuests;
    }

    public void DeleteQuest(int id)
    {
        _questRepository.Delete(id);
    }

    public void TakePart(int questId, ClaimsPrincipal claimsPrincipal)
    {
        var userId = _jwtProvider.GetUserId(claimsPrincipal);
        if (_questRepository.GetByIdAndUserId(questId, userId) != null)
            throw new RequestException(ErrorCode.RequestError, "The user is already taking part in the quest", $"User id - {userId} Quest id - {questId}");
        
    }
}
