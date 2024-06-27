
using AutoMapper;
using LivePlay.Server.Application.Services;
using LivePlay.Server.Core.Enums;
using LivePlay.Server.Core.Models;
using LivePlay.Server.WebApi.Contracts.Base.Quest;
using LivePlay.Server.WebApi.Contracts.Requests.Quest.Edit;
using LivePlay.Server.WebApi.Contracts.Requests.Quests.Add;
using LivePlay.Server.WebApi.Contracts.Requests.Quests.Complete;
using LivePlay.Server.WebApi.Contracts.Responses.Quest;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LivePlay.Server.WebApi.Controllers;

public class CreativeQuestController(CreativeQuestService questService, IMapper mapper) : Controller
{
    private readonly CreativeQuestService _creativeQuestService = questService;
    private readonly IMapper _mapper = mapper;

    [HttpPost("/getcreativequest/{id}")]
    public async Task<IActionResult> GetFullQuest(int id)
    {
        var (quest, creativeQuest) = await _creativeQuestService.GetFullQuest(id);
        var response = new FullQuestResponse<CreativeQuestController>
        {
            Quest = _mapper.Map<QuestContract>(quest),
            Subquest = _mapper.Map<CreativeQuestController>(creativeQuest)
        };
        return Ok();
    }

    [HttpPost("/addcreativequest")]
    [Authorize(Policy = nameof(Politic.EditQuest))]
    public IActionResult AddCreativeQuest([FromBody] AddingCreativeQuestRequest creativeQuestRequest)
    {
        var quest = _mapper.Map<Quest>(creativeQuestRequest.BaseQuest);
        _creativeQuestService.AddQuest(quest);
        return NoContent();
    }

    [HttpPost("/editcreativequest")]
    [Authorize(Policy = nameof(Politic.EditQuest))]
    public IActionResult EditCreativeQuest([FromBody] EditingCreativeQuestRequest creativeQuestRequest)
    {
        var quest = _mapper.Map<Quest>(creativeQuestRequest.BaseQuest);
        _creativeQuestService.EditQuest(quest);
        return NoContent();
    }

    [HttpPost("/completecreativequest")]
    [Authorize(Policy = nameof(Politic.EditQuest))]
    public IActionResult CompleteCreativeQuest([FromBody] CompletingCreativeQuestRequest questionQuestRequest)
    {
        var creativeQuest = _mapper.Map<CreativeQuest>(questionQuestRequest.PictureInfo);
        _creativeQuestService.CompleteQuest(HttpContext.User, questionQuestRequest.QuestId, creativeQuest);
        return NoContent();
    }
}
