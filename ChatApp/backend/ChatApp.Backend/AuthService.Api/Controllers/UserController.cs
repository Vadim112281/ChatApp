using AuthService.Application.DTOs;
using AuthService.Application.Services;
using ChatApp.Shared.Responses;
using Microsoft.AspNetCore.Mvc;

namespace AuthService.Api.Controllers;

[ApiController]
[Route("user")]
public class UserController(IUserService userService): ControllerBase
{
    [HttpPost("register")]
    public async Task<IActionResult> RegisterUserAsync([FromBody] RegisterUserDto registerUserDto)
    {
        var result = await userService.RegisterUserAsync(registerUserDto);

        return Ok(result.Data);
    }

    [HttpPost("login")]
    public async Task<IActionResult> LoginUserAsync([FromBody] LoginUserDto loginUserDto)
    {
        var result = await userService.LoginUserAsync(loginUserDto);

        return Ok(result.Data);
    }
}