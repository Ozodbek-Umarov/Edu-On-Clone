using EduOnClone.Application.DTOs.OptionDtos;
using EduOnClone.Application.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Edu_On_Clone.Controllers;

[Route("api/[controller]")]
[ApiController]
public class OptionController(IOptionService optionService) : ControllerBase
{
    private readonly IOptionService _optionService = optionService;

    [HttpPost]
    [Authorize(Roles = "Admin, SuperAdmin")]
    public async Task<IActionResult> CreateAsync([FromForm] AddOptionDto dto)
    {
        await _optionService.CreateAsync(dto);
        return Ok();
    }

    [HttpGet]
    [Authorize(Roles = "Admin, SuperAdmin")]
    public async Task<IActionResult> GetAllAsync()
    {
        return Ok(await _optionService.GetAllAsync());
    }

    [HttpGet("{id}")]
    [Authorize(Roles = "Admin, SuperAdmin")]
    public async Task<IActionResult> GetByIdAsync(int id)
    {
        return Ok(await _optionService.GetByIdAsync(id));
    }

    [HttpDelete("id")]
    [Authorize(Roles = "SuperAdmin, Admin")]
    public async Task<IActionResult> DeleteAsync(int id)
    {
        await _optionService.DeleteAsync(id);
        return Ok();
    }

    [HttpPut]
    [Authorize(Roles = "SuperAdmin, Admin")]
    public async Task<IActionResult> UpdateAsync([FromForm] OptionDto dto)
    {
        await _optionService.UpdateAsync(dto);
        return Ok();
    }
}
