
using AutoMapper;
using LivePlay.Server.Application.Services.QuestServices;
using LivePlay.Server.Core.Enums;
using LivePlay.Server.Core.Models;
using LivePlay.Server.WebApi.Contracts.Base.QuestContracts;
using LivePlay.Server.WebApi.Contracts.Requests.QuestRequests.Add;
using LivePlay.Server.WebApi.Contracts.Requests.QuestRequests.Complete;
using LivePlay.Server.WebApi.Contracts.Requests.QuestRequests.Edit;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace LivePlay.Server.WebApi.Controllers.QuestControllers;

[Route("[controller]/")]
[ApiController]
public class CreativeQuestController(CreativeQuestService questService, IMapper mapper) : Controller
{
    private readonly CreativeQuestService _creativeQuestService = questService;
    private readonly IMapper _mapper = mapper;

    [HttpPost("/get/{id}")]
    public async Task<IActionResult> GetCreativeQuest(int id)
    {
        var creativeQuest = await _creativeQuestService.GetQRQuestById(id);
        var response = _mapper.Map<CreativeQuestContract>(creativeQuest);
        return Ok(response);
    }

    [HttpPost("/add")]
    [Authorize(Policy = nameof(Politic.EditQuest))]
    public IActionResult AddCreativeQuest([FromBody] AddingCreativeQuestRequest creativeQuestRequest)
    {
        var quest = _mapper.Map<Quest>(creativeQuestRequest.BaseQuest);
        _creativeQuestService.Add(quest);
        return NoContent();
    }

    [HttpPost("/edit")]
    [Authorize(Policy = nameof(Politic.EditQuest))]
    public IActionResult EditCreativeQuest([FromBody] EditingCreativeQuestRequest creativeQuestRequest)
    {
        var quest = _mapper.Map<Quest>(creativeQuestRequest.BaseQuest);
        _creativeQuestService.Edit(quest);
        return NoContent();
    }

    [HttpPost("/complete")]
    [Authorize(Policy = nameof(Politic.EditQuest))]
    public IActionResult CompleteCreativeQuest([FromBody] CompletingCreativeQuestRequest questionQuestRequest)
    {
        var creativeQuest = _mapper.Map<CreativeQuest>(questionQuestRequest.PictureInfo);
        _creativeQuestService.CompleteQuest(HttpContext.User, questionQuestRequest.QuestId, creativeQuest);
        return NoContent();
    }
}
