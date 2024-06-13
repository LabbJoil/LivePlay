﻿
using LivePlay.Server.Application.Interfaces;
using LivePlay.Server.Core.Enums;
using LivePlay.Server.Persistence.Repositories;
using LivePlay.Server.WebApi.Contracts;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace LivePlay.Server.WebApi.Controllers
{
    [Route("[controller]/")]
    [ApiController]
    public class UserController(UserRepository userService) : ControllerBase
    {
        private readonly UserRepository UserDBHelper = userService;

        [HttpPost("/login")]
        public async Task<IActionResult> LoginUser([FromBody] LoginUserRequest userModel)
        {
            try
            {
                var token = await UserDBHelper.RegisterUser(userModel.Email, userModel.Password, userModel.FirstName);
                HttpContext.Response.Cookies.Append("tok-cookies", token);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        [HttpPost("/loginAdmin")]
        public async Task<IActionResult> LoginAdmin([FromBody] LoginUserRequest userModel)
        {
            try
            {
                var token = await UserDBHelper.RegisterAdmin(userModel.Email, userModel.Password, userModel.FirstName);
                HttpContext.Response.Cookies.Append("tok-cookies", token);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        [HttpGet("U")]
        [Authorize(Policy = nameof(Politic.OnlyRead))]
        public IActionResult Get()
        {
            return Ok("valueUser");
        }

        [HttpGet("A"), Authorize(Policy = nameof(Politic.Edit))]
        public IActionResult GetAdmin()
        {
            return Ok("valueAdmin");
        }

        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }
    }
}
