
using FoodMenuManagementSystem.Models;

namespace FoodMenuManagementSystem.Repositories.Interfaces;

public interface IMenuRepository
{
    Task<List<Menu>> GetAllAsync();

    Task<Menu?> GetByIdAsync(int id);

    Task AddAsync(Menu menu);

    Task UpdateAsync(Menu menu);

    Task DeleteAsync(Menu menu);
}
