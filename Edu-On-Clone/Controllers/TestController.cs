using EduOnClone.Application.DTOs.TestDtos;
using EduOnClone.Application.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Edu_On_Clone.Controllers;

[Route("api/[controller]")]
[ApiController]
public class TestController(ITestService testService) : ControllerBase
{
    private readonly ITestService _testService = testService;

    [HttpPost]
    [Authorize(Roles = "Admin, SuperAdmin")]
    public async Task<IActionResult> CreateAsync([FromForm] AddTestDto dto)
    {
        await _testService.CreateAsync(dto);
        return Ok();
    }

    [HttpGet]
    [Authorize]
    public async Task<IActionResult> GetAllAsync()
    {
        return Ok(await _testService.GetAllAsync());
    }

    [HttpGet("{id}")]
    [Authorize(Roles = "Admin, SuperAdmin")]
    public async Task<IActionResult> GetByIdAsync(int id)
    {
        return Ok(await _testService.GetByIdAsync(id));
    }

    [HttpDelete("{id}")]
    [Authorize(Roles = "Admin, SuperAdmin")]
    public async Task<IActionResult> DeleteAsync(int id)
    {
        await _testService.DeleteAsync(id);
        return Ok();
    }

    [HttpPut]
    [Authorize(Roles = "Admin, SuperAdmin")]
    public async Task<IActionResult> UpdateAsync([FromForm] TestDto dto)
    {
        await _testService.UpdateAsync(dto);
        return Ok();
    }
}
