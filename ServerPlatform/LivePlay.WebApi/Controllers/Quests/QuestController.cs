
using AutoMapper;
using LivePlay.Server.Application.Services.Quests;
using LivePlay.Server.Core.Enums;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace LivePlay.Server.WebApi.Controllers.Quests;

[Route("[controller]/")]
[ApiController]
public class QuestController(QuestService questService, IMapper mapper) : Controller
{
    private readonly QuestService _questService = questService;
    private readonly IMapper _mapper = mapper;

    [HttpGet("/allquests")]
    [Authorize(Policy = nameof(Politic.ReadQuestCoupon))]
    public async Task<IActionResult> GetAllQuests()
    {
        var allQuests = await _questService.GetAllQuestsBase();
        return Ok(allQuests);
    }

    [HttpDelete("/deletequest/{id}")]
    [Authorize(Policy = nameof(Politic.EditQuest))]
    public IActionResult DeleteQuest(int id)
    {
        _questService.DeleteQuest(id);
        return NoContent();
    }
}
