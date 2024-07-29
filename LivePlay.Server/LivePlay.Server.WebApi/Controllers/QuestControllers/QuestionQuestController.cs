
using AutoMapper;
using LivePlay.Server.Application.Services.QuestServices;
using LivePlay.Server.Core.Enums;
using LivePlay.Server.Core.Models;
using LivePlay.Server.WebApi.Contracts.Requests.QuestRequests.Add;
using LivePlay.Server.WebApi.Contracts.Requests.QuestRequests.Complete;
using LivePlay.Server.WebApi.Contracts.Requests.QuestRequests.Edit;
using LivePlay.Server.WebApi.Contracts.Responses.QuestResponses;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace LivePlay.Server.WebApi.Controllers.QuestControllers;

[Route("[controller]/")]
[ApiController]
public class QuestionQuestController(QuestionQuestService questionQuestService, IMapper mapper) : Controller
{
    private readonly QuestionQuestService _questionQuestService = questionQuestService;
    private readonly IMapper _mapper = mapper;

    [HttpGet("getQuestQuestions")]
    //[Authorize(Policy = nameof(Politic.GetActions))]
    public async Task<IActionResult> GetQuestions([FromQuery] int questId)
    {
        var questQuestions = await _questionQuestService.GetQuestQuestions(questId);
        return Ok(questQuestions);
    }

    [HttpPost("add")]
    [Authorize(Policy = nameof(Politic.EditQuest))]
    public async Task<IActionResult> AddQuestionQuest([FromBody] AddingQuestionQuestRequest questionQuestRequest)
    {
        var quest = _mapper.Map<Quest>(questionQuestRequest.BaseQuest);
        var questionQuest = _mapper.Map<QuestionQuest[]>(questionQuestRequest.Questions);
        await _questionQuestService.AddQuest(quest, questionQuest);
        return NoContent();
    }

    [HttpPost("edit")]
    [Authorize(Policy = nameof(Politic.EditQuest))]
    public IActionResult EditQuestionQuest([FromBody] EditingQuestionQuestRequest questionQuestRequest)
    {
        var quest = _mapper.Map<Quest>(questionQuestRequest.BaseQuest);
        var questionQuest = _mapper.Map<QuestionQuest[]>(questionQuestRequest.Questions);
        _questionQuestService.EditQuest(quest, questionQuest);
        return NoContent();
    }

    [HttpPost("complete")]
    [Authorize(Policy = nameof(Politic.EditQuest))]
    public async Task<IActionResult> CompleteQuestionQuest([FromBody] CompletingQuestionQuestRequest questionQuestRequest)
    {
        var (userPoints, reward) = await _questionQuestService.CompleteQuest(HttpContext.User, questionQuestRequest.QuestId, questionQuestRequest.AnswerQuestions);
        //var response = new CompletingQuestionQuestResponse
        //{
        //    UserPoints = userPoints,
        //    Reward = reward
        //};
        return Ok(reward);
    }
}
