
using AutoMapper;
using LivePlay.Server.Application.Services.QuestServices;
using LivePlay.Server.Core.Enums;
using LivePlay.Server.Core.Models;
using LivePlay.Server.WebApi.Contracts.Requests.QuestRequests.Add;
using LivePlay.Server.WebApi.Contracts.Requests.QuestRequests.Complete;
using LivePlay.Server.WebApi.Contracts.Requests.QuestRequests.Edit;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace LivePlay.Server.WebApi.Controllers.QuestControllers;

public class QRQuestController(QRQuestService questService, IMapper mapper) : Controller
{
    private readonly QRQuestService _qrQuestService = questService;
    private readonly IMapper _mapper = mapper;

    [HttpPost("/addqrquest")]
    [Authorize(Policy = nameof(Politic.EditQuest))]
    public IActionResult AddQRQuest([FromBody] AddingQRQuestRequest qrQuestRequest)
    {
        var quest = _mapper.Map<Quest>(qrQuestRequest.BaseQuest);
        var questionQuest = _mapper.Map<QRQuest>(qrQuestRequest.QrQuest);
        _qrQuestService.Create(quest, questionQuest);
        return NoContent();
    }

    [HttpPost("/editqrquest")]
    [Authorize(Policy = nameof(Politic.EditQuest))]
    public IActionResult EditQRQuest([FromBody] EditingQRQuestRequest qrQuestRequest)
    {
        var quest = _mapper.Map<Quest>(qrQuestRequest.BaseQuest);
        var questionQuest = _mapper.Map<QRQuest>(qrQuestRequest.QrQuest);
        _qrQuestService.Edit(quest, questionQuest);
        return NoContent();
    }

    [HttpPost("/completeqrquest")]
    [Authorize(Policy = nameof(Politic.EditQuest))]
    public IActionResult CompleteQRQuest([FromBody] CompletingQRQuestRequest questionQuestRequest)
    {
        _qrQuestService.CompleteQuest(HttpContext.User, questionQuestRequest.QuestId, questionQuestRequest.QRData);
        return NoContent();
    }
}
