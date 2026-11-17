using FoodMenuManagementSystem.DTOs.FoodItem;
using FoodMenuManagementSystem.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace FoodMenuManagementSystem.Controllers;

[Route("api/[controller]")]
[ApiController]
public class FoodItemController : ControllerBase
{
    private readonly IFoodItemService _service;

    public FoodItemController(IFoodItemService service)
    {
        _service = service;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var items = await _service.GetAllAsync();

        return Ok(items);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(int id)
    {
        var item = await _service.GetByIdAsync(id);

        if (item == null)
            return NotFound("Food item not found.");

        return Ok(item);
    }

    [HttpPost]
    public async Task<IActionResult> Create(CreateFoodItemDto dto)
    {
        var item = await _service.CreateAsync(dto);

        return CreatedAtAction(
            nameof(GetById),
            new { id = item.FoodItemId },
            item);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update(int id, UpdateFoodItemDto dto)
    {
        var item = await _service.UpdateAsync(id, dto);

        if (item == null)
            return NotFound("Food item not found.");

        return Ok(item);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        var result = await _service.DeleteAsync(id);

        if (!result)
            return NotFound("Food item not found.");

        return Ok("Food item deleted successfully.");
    }
}