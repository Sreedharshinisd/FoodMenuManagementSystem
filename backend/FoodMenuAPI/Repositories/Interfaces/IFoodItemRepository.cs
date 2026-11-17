using FoodMenuManagementSystem.Models;

namespace FoodMenuManagementSystem.Repositories.Interfaces;

public interface IFoodItemRepository
{
    Task<List<FoodItem>> GetAllAsync();

    Task<FoodItem?> GetByIdAsync(int id);

    Task AddAsync(FoodItem foodItem);

    Task UpdateAsync(FoodItem foodItem);

    Task DeleteAsync(FoodItem foodItem);
}