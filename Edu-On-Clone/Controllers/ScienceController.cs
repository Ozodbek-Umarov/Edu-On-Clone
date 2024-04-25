using EduOnClone.Application.DTOs.ScienceDtos;
using EduOnClone.Application.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Edu_On_Clone.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ScienceController(IScienceService scienceService) : ControllerBase
{
    private readonly IScienceService _scienceService = scienceService;
    [HttpPost]
    [Authorize(Roles = "Admin, SuperAdmin")]
    public async Task<IActionResult> CreateAsync([FromForm] AddScienceDto dto)
    {
        await _scienceService.CreateAsync(dto);
        return Ok();
    }
    [HttpGet("id")]
    public async Task<IActionResult> GetByIdAsync(int id)
    {
        return Ok(await _scienceService.GetByIdAsync(id));
    }

    [HttpGet("movies")]
    [Authorize]
    public async Task<IActionResult> GetAllAsync()
    {
        return Ok(await _scienceService.GetAllAsync());
    }

    [HttpDelete("id")]
    [Authorize(Roles = "SuperAdmin, Admin")]
    public async Task<IActionResult> DeleteAsync(int id)
    {
        await _scienceService.DeleteAsync(id);
        return Ok();
    }

    [HttpPut]
    [Authorize(Roles = "SuperAdmin, Admin")]
    public async Task<IActionResult> UpdateAsync([FromForm] ScienceDto dto)
    {
        await _scienceService.UpdateAsync(dto);
        return Ok();
    }
}
