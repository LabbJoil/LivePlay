
using LivePlay.Server.Application.CustomExceptions;
using LivePlay.Server.Application.Services;
using LivePlay.Server.Core.Enums;
using LivePlay.Server.Core.Models;
using LivePlay.Server.Persistence.EntityModels.Base;
using LivePlay.Server.Persistence.Repositories;
using LivePlay.Server.WebApi.Contracts.Requests.Quest.Add;
using LivePlay.Server.WebApi.Contracts.Requests.Quest.Edit;
using LivePlay.Server.WebApi.Contracts.Requests.Quests.Complete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace LivePlay.Server.WebApi.Controllers;

public class QRQuestController() : Controller
{
    [HttpPost("/addqrquest")]
    //[Authorize(Policy = nameof(Politic.EditQuest))]
    public IActionResult AddQRQuest([FromBody] AddingQRQuestRequest qrQuestRequest)
    {
        var quest = _mapper.Map<Quest>(qrQuestRequest.BaseQuest);
        var questionQuest = _mapper.Map<QRQuest>(qrQuestRequest.QrQuest);
        _userService.AddQuest(quest, questionQuest);
        return NoContent();
    }

    [HttpPost("/editqrquest")]
    //[Authorize(Policy = nameof(Politic.EditQuest))]
    public IActionResult EditQRQuest([FromBody] EditingQRQuestRequest qrQuestRequest)
    {
        var quest = _mapper.Map<Quest>(qrQuestRequest.QrQuest);
        var questionQuest = _mapper.Map<CreativeQuest>(qrQuestRequest.QrQuest);
        _questService.EditQuest(quest, questionQuest);
        return NoContent();
    }

    [HttpPost("/completeqrquest")]
    //[Authorize(Policy = nameof(Politic.EditQuest))]
    public IActionResult CompleteQRQuest([FromBody] CompletingQuestionQuestRequest questionQuestRequest)
    {
        _questService.CompleteQRQuest(HttpContext.User, questionQuestRequest.QuestId, questionQuestRequest.AnswerQuestions);
        return NoContent();
    }
}
