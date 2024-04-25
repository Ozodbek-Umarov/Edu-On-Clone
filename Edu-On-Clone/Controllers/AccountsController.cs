using EduOnClone.Application.DTOs.UserDtos;
using EduOnClone.Application.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Edu_On_Clone.Controllers;

[Route("api/[controller]")]
[ApiController]
public class AccountsController(IAccountService accountService) : ControllerBase
{
    private readonly IAccountService _accountService = accountService;

    [HttpPost("registr")]
    [AllowAnonymous]
    public async Task<IActionResult> RegistrAsync([FromForm] AddUserDto dto)
    {
        var result = await _accountService.RegistrAsync(dto);
        return Ok(result);
    }

    [HttpPost("login"), AllowAnonymous]
    public async Task<IActionResult> LoginAsync([FromForm] LoginDto dto)
    {
        var result = await _accountService.LoginAsync(dto);
        return Ok($"Token : {result}");
    }
    [HttpPost("sendcode")]
    public async Task<IActionResult> SendCodeAsync([FromForm] string email)
    {
        await _accountService.SendCodeAsync(email);
        return Ok();
    }
    [HttpPost("check")]
    public async Task<IActionResult> CheckCodeAsync([FromForm] string email, [FromForm] string code)
        => Ok(await _accountService.CheckCodeAsync(email, code));
}
