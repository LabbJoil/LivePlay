using LivePlay.Server.Application.CustomExceptions;
using LivePlay.Server.Application.Interfaces;
using LivePlay.Server.Core.Enums;
using LivePlay.Server.Core.Interfaces.Quests;
using LivePlay.Server.Core.Models;
using System.Security.Claims;

namespace LivePlay.Server.Application.Services.Quests;

public class CreativeQuestService(ICreativeQuestRepository creativeQuestRepository, IJwtProvider jwtProvider)
{
    private readonly ICreativeQuestRepository _creativeQuestRepository = creativeQuestRepository;
    private readonly IJwtProvider _jwtProvider = jwtProvider;

    public void Add(Quest quest)
    {
        _creativeQuestRepository.Create(quest);
    }

    public void Edit(Quest quest)
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

    public async Task<CreativeQuest> GetQRQuestById(int id)
    {
        var creativeQuest =  await _creativeQuestRepository.GetById(id);
        return creativeQuest;
    }
}
