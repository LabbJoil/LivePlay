﻿
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
public class UserController(UserService userService, IMapper mapper) : Controller
{
    private readonly UserService _userService = userService;
    private readonly IMapper _mapper = mapper;

    [HttpGet("login")]
    public async Task<IActionResult> LoginUser([FromQuery] string email, string password)
    {
        var (token, roles) = await _userService.LoginUser(email, password);
        return Ok(new LoginResponse
        {
            Token = token,
            Roles = roles.Select(r => r.ToString()).ToArray()
        });
    }

    [HttpGet("verifyEmail")]
    public async Task<IActionResult> VerifyEmail([FromQuery] string email)
    {
        var numberRegistration = await _userService.VerifyEmail(email);
        return Ok(numberRegistration);
    }

    [HttpGet("checkEmailCode")]
    public IActionResult CheckEmailCode([FromQuery] uint numberRegistration, string code)
    {
        _userService.VerifyCodeEmail(numberRegistration, code);
        return NoContent();
    }

    [HttpPost("registration")]
    public async Task<IActionResult> RegistrationUser([FromQuery] uint numberRegistration, [FromBody] RegistrationUserRequest newUser)
    {
        User user = _mapper.Map<User>(newUser);
        await _userService.RegisterUser(numberRegistration, user);
        return NoContent();
    }

    [HttpGet("sendCodeAgain")]
    public IActionResult SendCodeAgain([FromQuery] uint numberRegistration)
    {
        _userService.SendCodeAgain(numberRegistration);
        return NoContent();
    }

    [HttpGet("checkToken")]
    [Authorize(Policy = nameof(Politic.GetActions))]
    public async Task<IActionResult> CheckToken()
    {
        var rolesEnums = await _userService.GetUserRoles(HttpContext.User);
        string[] roles = rolesEnums.Select(r => r.ToString()).ToArray();
        return Ok(roles);
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

    [HttpGet("getPoints")]
    [Authorize(Policy = nameof(Politic.PersonalInfo))]
    public async Task<IActionResult> GetPoints()
    {
        var points = await _userService.GetPoints(HttpContext.User);
        return Ok(points);
    }
}
