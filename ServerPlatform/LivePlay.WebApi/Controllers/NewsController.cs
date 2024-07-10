
using LivePlay.Server.Application.Services;
using Microsoft.AspNetCore.Mvc;

namespace LivePlay.Server.WebApi.Controllers;

[Route("[controller]/")]
[ApiController]
public class NewsController(NewsService newsService) : Controller
{
    private readonly NewsService _newsService = newsService;

    [HttpGet("getLastNews")]
    public IActionResult GetLastNews()
    {
        var news =  _newsService.GetLastNews();
        return Ok(news);
    }
}
