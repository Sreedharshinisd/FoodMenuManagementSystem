using FoodMenuManagementSystem.DTOs.FoodItem;
using FoodMenuManagementSystem.Models;
using FoodMenuManagementSystem.Repositories.Interfaces;
using FoodMenuManagementSystem.Services.Interfaces;

namespace FoodMenuManagementSystem.Services;

public class FoodItemService : IFoodItemService
{
    private readonly IFoodItemRepository _repository;

    public FoodItemService(IFoodItemRepository repository)
    {
        _repository = repository;
    }

    public async Task<List<FoodItemResponseDto>> GetAllAsync()
    {
        var items = await _repository.GetAllAsync();

        return items.Select(item => MapToResponse(item)).ToList();
    }

    public async Task<FoodItemResponseDto?> GetByIdAsync(int id)
    {
        var item = await _repository.GetByIdAsync(id);

        return item == null ? null : MapToResponse(item);
    }

    public async Task<FoodItemResponseDto> CreateAsync(CreateFoodItemDto dto)
    {
        var item = new FoodItem
        {
            FoodName = dto.FoodName,
            Description = dto.Description,
            Price = dto.Price,
            ImageUrl = dto.ImageUrl,
            IsAvailable = true
        };

        await _repository.AddAsync(item);

        return MapToResponse(item);
    }

    public async Task<FoodItemResponseDto?> UpdateAsync(
        int id, UpdateFoodItemDto dto)
    {
        var item = await _repository.GetByIdAsync(id);

        if (item == null)
            return null;

        item.FoodName = dto.FoodName;
        item.Description = dto.Description;
        item.Price = dto.Price;
        item.ImageUrl = dto.ImageUrl;
        item.IsAvailable = dto.IsAvailable;

        await _repository.UpdateAsync(item);

        return MapToResponse(item);
    }

    public async Task<bool> DeleteAsync(int id)
    {
        var item = await _repository.GetByIdAsync(id);

        if (item == null)
            return false;

        await _repository.DeleteAsync(item);

        return true;
    }

    private static FoodItemResponseDto MapToResponse(FoodItem item)
    {
        return new FoodItemResponseDto
        {
            FoodItemId = item.FoodItemId,
            FoodName = item.FoodName,
            Description = item.Description,
            Price = item.Price,
            ImageUrl = item.ImageUrl,
            IsAvailable = item.IsAvailable
        };
    }
}