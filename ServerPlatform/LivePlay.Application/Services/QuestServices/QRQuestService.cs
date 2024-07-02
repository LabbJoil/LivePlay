
using LivePlay.Server.Application.Interfaces;
using LivePlay.Server.Core.CustomExceptions;
using LivePlay.Server.Core.Enums;
using LivePlay.Server.Core.Interfaces.QuestInterfaces;
using LivePlay.Server.Core.Models;
using System.Security.Claims;

namespace LivePlay.Server.Application.Services.QuestServices;

public class QRQuestService(IQRQuestRepository qrQuestRepository, IQuestRepository questRepository, IJwtProvider jwtProvider)
{
    private readonly IQRQuestRepository _qrQuestRepository = qrQuestRepository;
    private readonly IQuestRepository _questRepository = questRepository;
    private readonly IJwtProvider _jwtProvider = jwtProvider;

    public void Create(Quest quest, QRQuest questionQuest)
    {
        _qrQuestRepository.Add(quest, questionQuest);
    }

    public async void CompleteQuest(ClaimsPrincipal user, int questId, byte[] answerQR)
    {
        var qrQuest = await _qrQuestRepository.GetByQuestId(questId);
        if (qrQuest.QRInfo == answerQR)
        {
            var userId = _jwtProvider.GetUserId(user);
            _questRepository.AddLinkUser(questId, userId);
            return;
        }
        throw new RequestException(ErrorCode.FalseAnswer, "QR-код неправильно введён");
    }

    public void Edit(Quest quest, QRQuest questionQuest)
    {
        _qrQuestRepository.Edit(quest, questionQuest);
    }
}
