
using AutoMapper;
using LivePlay.Server.Application.Services;
using LivePlay.Server.WebApi.Contracts.Base;
using Microsoft.AspNetCore.Mvc;

namespace LivePlay.Server.WebApi.Controllers;

[Route("[controller]/")]
[ApiController]
public class NewsController(NewsService newsService, IMapper mapper) : Controller
{
    private readonly NewsService _newsService = newsService;
    private readonly IMapper _mapper = mapper;

    [HttpGet("getLastNews")]
    public IActionResult GetLastNews()
    {
        var news =  _newsService.GetLastNews();
        var newsContract = _mapper.Map<NewsContract[]>(news);
        return Ok(newsContract);
    }
}
