using EduOnClone.Application.DTOs.SubjectDtos;
using EduOnClone.Application.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Edu_On_Clone.Controllers;

[Route("api/[controller]")]
[ApiController]
public class SubjectsController(ISubjectService subjectService) : ControllerBase
{
    private readonly ISubjectService _subjectService = subjectService;

    [HttpPost, Authorize(Roles = "Admin, SuperAdmin")]
    public async Task<IActionResult> CreateAsync([FromForm] AddSubjectDto dto)
    {
        await _subjectService.CreateAsync(dto);
        return Ok();
    }

    [HttpGet, AllowAnonymous]
    public async Task<IActionResult> GetAllAsync()
    {
        return Ok(await _subjectService.GetAllAsync());
    }

    [HttpGet("{id}"), Authorize]
    public async Task<IActionResult> GetByIdAsync(int id)
    {
        return Ok(await _subjectService.GetByIdAsync(id));
    }

    [HttpGet("{name}"), Authorize]
    public async Task<IActionResult> GetByNameAsync(string name)
    {
        return Ok(await _subjectService.GetByNameAsync(name));
    }

    [HttpDelete("{id}"), Authorize(Roles = "Admin, SuperAdmin")]
    public async Task<IActionResult> DeleteAsync(int id)
    {
        await _subjectService.DeleteAsync(id);
        return Ok();
    }
    [HttpPut, Authorize("Admin, SuperAdmin")]
    public async Task<IActionResult> UpdateAsync([FromForm] SubjectDto dto)
    {
        await _subjectService.UpdateAsync(dto);
        return Ok();
    }
}
