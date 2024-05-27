using LivePlayWebApi.Contracts;
using LivePlayWebApi.Enums;
using LivePlayWebApi.Interfaces;
using LivePlayWebApi.Models.CoreModels;
using LivePlayWebApi.Services.Auth;
using LivePlayWebApi.Services.ConfigurationOptions;
using LivePlayWebApi.Services.Repositories;
using Microsoft.AspNetCore.Authentication.OAuth;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using Npgsql.Replication.PgOutput.Messages;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text.Json;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace LivePlayWebApi.Controllers
{
    [Route("[controller]/")]
    [ApiController]
    public class UserController(UserService userService, IJwtProvider jwtProvider) : ControllerBase
    {
        private readonly UserService UserDBHelper = userService;
        private readonly IJwtProvider _jwtProvider = jwtProvider;

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

        [HttpDelete("{id}"), Authorize]
        public async Task<IActionResult> Delete(int id)
        {
            var userId = _jwtProvider.GetUserId(HttpContext.User);

            var userPermissions = await UserDBHelper.GetUserPermissions(userId);
            Permission[] needPoliticPermissions = [Permission.Read];
            if (needPoliticPermissions.All(userPermissions.Contains))
                return Ok("ok");
            return Ok("KKK");
        }
    }
}
