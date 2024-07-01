
using AutoMapper;
using LivePlay.Server.Application.Services.Quests;
using LivePlay.Server.Core.Enums;
using LivePlay.Server.Core.Models;
using LivePlay.Server.WebApi.Contracts.Requests.Quest.Add;
using LivePlay.Server.WebApi.Contracts.Requests.Quest.Edit;
using LivePlay.Server.WebApi.Contracts.Requests.Quests.Complete;
using LivePlay.Server.WebApi.Contracts.Responses.Quests;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LivePlay.Server.WebApi.Controllers.Quests;

public class QuestionQuestController(QuestionQuestService questionQuestService, IMapper mapper) : Controller
{
    private readonly QuestionQuestService _questionQuestService = questionQuestService;
    private readonly IMapper _mapper = mapper;

    [HttpPost("/addquestionquest")]
    [Authorize(Policy = nameof(Politic.EditQuest))]
    public IActionResult AddQuestionQuest([FromBody] AddingQuestionQuestRequest questionQuestRequest)
    {
        var quest = _mapper.Map<Quest>(questionQuestRequest.BaseQuest);
        var questionQuest = _mapper.Map<QuestionQuest[]>(questionQuestRequest.Questions);
        _questionQuestService.AddQuest(quest, questionQuest);
        return NoContent();
    }

    [HttpPost("/editquestionquest")]
    [Authorize(Policy = nameof(Politic.EditQuest))]
    public IActionResult EditQuestionQuest([FromBody] EditingQuestionQuestRequest questionQuestRequest)
    {
        var quest = _mapper.Map<Quest>(questionQuestRequest.BaseQuest);
        var questionQuest = _mapper.Map<QuestionQuest[]>(questionQuestRequest.Questions);
        _questionQuestService.EditQuest(quest, questionQuest);
        return NoContent();
    }

    [HttpPost("/completequestionquest")]
    [Authorize(Policy = nameof(Politic.EditQuest))]
    public async Task<IActionResult> CompleteQuestionQuest([FromBody] CompletingQuestionQuestRequest questionQuestRequest)
    {
        var (userPoints, reward) = await _questionQuestService.CompleteQuest(HttpContext.User, questionQuestRequest.QuestId, questionQuestRequest.AnswerQuestions);
        var response = new CompletingQuestionQuestResponse
        {
            UserPoints = userPoints,
            Reward = reward
        };
        return Ok(response);
    }
}
