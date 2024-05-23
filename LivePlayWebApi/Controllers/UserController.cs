using LivePlayWebApi.Contracts;
using LivePlayWebApi.Models.CoreModels;
using LivePlayWebApi.Services;
using Microsoft.AspNetCore.Authentication.OAuth;
using Microsoft.AspNetCore.Mvc;
using Npgsql.Replication.PgOutput.Messages;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text.Json;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace LivePlayWebApi.Controllers
{
    [Route("[controller]/")]
    [ApiController]
    public class UserController(UserService userService, Microsoft.Extensions.Options.IOptions<RolePermissionOptions> authorizationOptions) : ControllerBase
    {
        private readonly UserService UserDBHelper = userService;

        private readonly RolePermissionOptions authorization = authorizationOptions.Value;


        [HttpPost("/login")]
        public async Task<IActionResult> LoginUser([FromBody] LoginUserRequest userModel)
        {
            try
            {
                var token = await UserDBHelper.Register(userModel.Email, userModel.Password, userModel.FirstName);
                //Logger.LogInformation("|{date}|\t|User (id - {idUser})|\t|The user has successfully signup", DateTime.Now, authorizeUser.Id);
                return Ok(token);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
