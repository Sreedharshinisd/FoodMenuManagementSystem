using FoodMenuManagementSystem.DTOs.Menu;
using FoodMenuManagementSystem.Models;
using FoodMenuManagementSystem.Repositories.Interfaces;
using FoodMenuManagementSystem.Services.Interfaces;
public interface IMenuService
{
    Task<List<MenuResponseDto>> GetAllAsync();

    Task<MenuResponseDto?> GetByIdAsync(int id);

    Task<MenuResponseDto> CreateAsync(CreateMenuDto dto);

    Task<bool> UpdateAsync(int id, UpdateMenuDto dto);

    Task<bool> DeleteAsync(int id);
}
