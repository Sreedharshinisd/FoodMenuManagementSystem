using FoodMenuManagementSystem.DTOs.FoodItem;

namespace FoodMenuManagementSystem.Services.Interfaces;

public interface IFoodItemService
{
    Task<List<FoodItemResponseDto>> GetAllAsync();

    Task<FoodItemResponseDto?> GetByIdAsync(int id);

    Task<FoodItemResponseDto> CreateAsync(CreateFoodItemDto dto);

    Task<FoodItemResponseDto?> UpdateAsync(int id, UpdateFoodItemDto dto);

    Task<bool> DeleteAsync(int id);
}