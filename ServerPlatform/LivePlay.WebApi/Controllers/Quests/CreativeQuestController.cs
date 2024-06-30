
using AutoMapper;
using LivePlay.Server.Application.Services.Quests;
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

namespace LivePlay.Server.WebApi.Controllers.Quests;

public class CreativeQuestController(CreativeQuestService questService, IMapper mapper) : Controller
{
    private readonly CreativeQuestService _creativeQuestService = questService;
    private readonly IMapper _mapper = mapper;

    [HttpPost("/getcreativequest/{id}")]
    public async Task<IActionResult> GetCreativeQuest(int id)
    {
        var creativeQuest = await _creativeQuestService.GetQRQuestById(id);
        var response = _mapper.Map<CreativeQuestContract>(creativeQuest);
        return Ok(response);
    }

    [HttpPost("/addcreativequest")]
    [Authorize(Policy = nameof(Politic.EditQuest))]
    public IActionResult AddCreativeQuest([FromBody] AddingCreativeQuestRequest creativeQuestRequest)
    {
        var quest = _mapper.Map<Quest>(creativeQuestRequest.BaseQuest);
        _creativeQuestService.Add(quest);
        return NoContent();
    }

    [HttpPost("/editcreativequest")]
    [Authorize(Policy = nameof(Politic.EditQuest))]
    public IActionResult EditCreativeQuest([FromBody] EditingCreativeQuestRequest creativeQuestRequest)
    {
        var quest = _mapper.Map<Quest>(creativeQuestRequest.BaseQuest);
        _creativeQuestService.Edit(quest);
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
