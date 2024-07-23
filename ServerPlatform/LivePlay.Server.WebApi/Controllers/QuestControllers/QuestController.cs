
using AutoMapper;
using LivePlay.Server.Application.Services.QuestServices;
using LivePlay.Server.Core.Enums;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace LivePlay.Server.WebApi.Controllers.QuestControllers;

[Route("[controller]/")]
[ApiController]
public class QuestController(QuestService questService, IMapper mapper) : Controller
{
    private readonly QuestService _questService = questService;
    private readonly IMapper _mapper = mapper;

    [HttpGet("getAll")]
    [Authorize(Policy = nameof(Politic.GetActions))]
    public async Task<IActionResult> GetAllQuests()
    {
        var allQuests = await _questService.GetAllQuestsBase();
        return Ok(allQuests);
    }

    [HttpGet("takePart")]
    [Authorize(Policy = nameof(Politic.GetActions))]
    public IActionResult TakePartQuest([FromQuery] int id)
    {
        _questService.DeleteQuest(id);
        return NoContent();
    }

    [HttpDelete("delete")]
    [Authorize(Policy = nameof(Politic.EditQuest))]
    public IActionResult DeleteQuest([FromQuery] int id)
    {
        _questService.DeleteQuest(id);
        return NoContent();
    }
}
