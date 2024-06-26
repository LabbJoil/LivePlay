
using LivePlay.Server.Application.CustomExceptions;
using LivePlay.Server.Application.Interfaces;
using LivePlay.Server.Core.Enums;
using LivePlay.Server.Core.Interfaces;
using LivePlay.Server.Core.Models;
using System.Security.Claims;

namespace LivePlay.Server.Application.Services;

public class CreativeQuestService(ICreativeQuestRepository creativeQuestRepository, IJwtProvider jwtProvider) : ICreativeQuestRepository
{
    private readonly ICreativeQuestRepository _creativeQuestRepository = creativeQuestRepository;
    private readonly IJwtProvider _jwtProvider = jwtProvider;

    public async Task<(Quest, CreativeQuest)> GetFullQuest(int idQuest)
    {
        var (quest, creativeQuest) = await _creativeQuestRepository.GetFullQuest(idQuest);
        return (quest, creativeQuest);
    }

    public void AddQuest(Quest quest)
    {
        _creativeQuestRepository.Create(quest);
    }

    public void EditQuest(Quest quest)
    {
        _creativeQuestRepository.Edit(quest);
    }

    public async void CompleteQuest(ClaimsPrincipal claimsPrincipal, int questId, CreativeQuest creativeQuest)
    {
        var userId = _jwtProvider.GetUserId(claimsPrincipal);
        var completeCreativeQuest = await _creativeQuestRepository.GetByQuestIdAndUserId(questId, userId);
        if (completeCreativeQuest != null)
            throw new RequestException(ErrorCode.RequestError, "The quest has already been completed");

    }
}
