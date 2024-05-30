
using LivePlay.Application.Interfaces;
using LivePlay.Core.Enums;
using LivePlay.Persistence.Repositories;
using LivePlayApplication.Contracts;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace LivePlayApplication.Controllers
{
    [Route("[controller]/")]
    [ApiController]
    public class UserController(UserRepository userService, IJwtProvider jwtProvider) : ControllerBase
    {
        private readonly UserRepository UserDBHelper = userService;
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
