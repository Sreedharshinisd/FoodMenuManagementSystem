
using FoodMenuManagementSystem.DTOs.Menu;
using FoodMenuManagementSystem.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace FoodMenuManagementSystem.Controllers;

[ApiController]
[Route("api/[controller]")]
public class MenuController : ControllerBase
{
    private readonly IMenuService _service;

    public MenuController(IMenuService service)
    {
        _service = service;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        return Ok(await _service.GetAllAsync());
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(int id)
    {
        var menu = await _service.GetByIdAsync(id);

        if (menu == null)
            return NotFound();

        return Ok(menu);
    }

    [HttpPost]
    public async Task<IActionResult> Create(CreateMenuDto dto)
    {
        var menu = await _service.CreateAsync(dto);

        return Ok(menu);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update(int id, UpdateMenuDto dto)
    {
        var result = await _service.UpdateAsync(id, dto);

        if (!result)
            return NotFound();

        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        var result = await _service.DeleteAsync(id);

        if (!result)
            return NotFound();

        return NoContent();
    }
}
