
using AutoMapper;
using LivePlay.Server.Application.Services;
using LivePlay.Server.Core.Enums;
using LivePlay.Server.Core.Models;
using LivePlay.Server.WebApi.Contracts.Requests.User;
using LivePlay.Server.WebApi.Contracts.Responses.UserResponses;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace LivePlay.Server.WebApi.Controllers;

[Route("[controller]/")]
[ApiController]
public class UserController(UserService userService, IMapper mapper) : ControllerBase
{
    private readonly UserService _userService = userService;
    private readonly IMapper _mapper = mapper;

    [HttpPost("login")]
    public async Task<IActionResult> LoginUser([FromBody] LoginUserRequest loginUser)
    {
        var token = await _userService.LogInUser(loginUser.Email, loginUser.Password);
        return Ok(token);
    }

    [HttpGet("verifyEmail/{email}")]
    public async Task<IActionResult> VerifyEmail(string email)
    {
        var numberRegistration = await _userService.VerifyEmail(email);
        return Ok(numberRegistration);
    }

    [HttpGet("checkEmailCode/{numberRegistration}/{code}")]
    public IActionResult CheckEmailCode(uint numberRegistration, string code)
    {
        _userService.VerifyCodeEmail(numberRegistration, code);
        return NoContent();
    }

    [HttpPost("registration/{numberRegistration}")]
    public async Task<IActionResult> RegistrationUser(uint numberRegistration, [FromBody] RegistrationUserRequest newUser)
    {
        User user = _mapper.Map<User>(newUser);
        string token = await _userService.RegisterUser(numberRegistration, user);
        //HttpContext.Response.Cookies.Append("tok-cookies", token);
        return NoContent();
    }

    [HttpGet("sendCodeAgain/{numberRegistration}")]
    public IActionResult SendCodeAgain(uint numberRegistration)
    {
        _userService.SendCodeAgain(numberRegistration);
        return NoContent();
    }

    [HttpPut("editInfo")]
    [Authorize(Policy = nameof(Politic.PersonalInfo))]
    public async Task<IActionResult> EditInfo([FromBody] UpdateUserRequest updateUser)
    {
        var user = _mapper.Map<User>(updateUser);
        await _userService.EditUser(HttpContext.User, user);
        return NoContent();
    }

    [HttpDelete("delete")]
    [Authorize(Policy=nameof(Politic.PersonalInfo))]
    public async Task<IActionResult> DeleteUser()
    {
        await _userService.DeleteUser(HttpContext.User);
        return NoContent();
    }

    [HttpGet("getPersonalQR")]
    [Authorize(Policy = nameof(Politic.PersonalInfo))]
    public IActionResult GetPersonalQR()
    {
        string qr = _userService.GetQRCode(HttpContext.User);
        return Ok(qr);
    }

    [HttpGet("getUser")]
    [Authorize(Policy = nameof(Politic.PersonalInfo))]
    public async Task<IActionResult> GetUser()
    {
        var user = await _userService.GetUser(HttpContext.User);
        var userInfo = _mapper.Map<UserInfoResponse>(user);
        return Ok(userInfo);
    }
}
