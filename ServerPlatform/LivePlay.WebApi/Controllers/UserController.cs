
using LivePlay.Server.Application.Interfaces;
using LivePlay.Server.Application.Services;
using LivePlay.Server.Core.Enums;
using LivePlay.Server.Persistence.Repositories;
using LivePlay.Server.WebApi.Contracts;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace LivePlay.Server.WebApi.Controllers
{
    [Route("[controller]/")]
    [ApiController]
    public class UserController(UserService userService) : ControllerBase
    {
        private readonly UserService UserService = userService;

        [HttpPost("/login")]
        public async Task<IActionResult> LoginUser([FromBody] LoginUserRequest userModel)
        {
            try
            {
                //var token = await UserDBHelper.RegisterUser(userModel.Email, userModel.Password, userModel.FirstName);
                //HttpContext.Response.Cookies.Append("tok-cookies", token);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        [HttpGet("/verifyemail/{email}")]
        public IActionResult Get(string email)
        {
            var numberRegistration = UserService.VerifyEmail(email);
            return Ok(numberRegistration);
        }

        [HttpGet("/verifyemailcode/{numberRegistration}/{code}"), Authorize(Policy = nameof(Politic.Edit))]
        public IActionResult GetAdmin(uint numberRegistration, string code)
        {
            if (UserService.VerifyCodeEmail(numberRegistration, code))
                return NoContent();
            return BadRequest();
        }
    }
}
