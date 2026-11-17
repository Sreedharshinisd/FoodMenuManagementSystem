using FoodMenuManagementSystem.DTOs.Menu;
using FoodMenuManagementSystem.Models;
using FoodMenuManagementSystem.Repositories.Interfaces;
using FoodMenuManagementSystem.Services.Interfaces;

namespace FoodMenuManagementSystem.Services;

public class MenuService : IMenuService
{
    private readonly IMenuRepository _repository;

    public MenuService(IMenuRepository repository)
    {
        _repository = repository;
    }

    public async Task<List<MenuResponseDto>> GetAllAsync()
    {
        var menus = await _repository.GetAllAsync();

        return menus.Select(m => new MenuResponseDto
        {
            MenuId = m.MenuId,
            MenuName = m.MenuName,
            Description = m.Description,
            IsActive = m.IsActive
        }).ToList();
    }

    public async Task<MenuResponseDto?> GetByIdAsync(int id)
    {
        var menu = await _repository.GetByIdAsync(id);

        if (menu == null)
            return null;

        return new MenuResponseDto
        {
            MenuId = menu.MenuId,
            MenuName = menu.MenuName,
            Description = menu.Description,
            IsActive = menu.IsActive
        };
    }

    public async Task<MenuResponseDto> CreateAsync(CreateMenuDto dto)
    {
        var menu = new Menu
        {
            MenuName = dto.MenuName,
            Description = dto.Description,
            IsActive = true
        };

        await _repository.AddAsync(menu);

        return new MenuResponseDto
        {
            MenuId = menu.MenuId,
            MenuName = menu.MenuName,
            Description = menu.Description,
            IsActive = menu.IsActive
        };
    }

    public async Task<bool> UpdateAsync(int id, UpdateMenuDto dto)
    {
        var menu = await _repository.GetByIdAsync(id);

        if (menu == null)
            return false;

        menu.MenuName = dto.MenuName;
        menu.Description = dto.Description;
        menu.IsActive = dto.IsActive;

        await _repository.UpdateAsync(menu);

        return true;
    }

    public async Task<bool> DeleteAsync(int id)
    {
        var menu = await _repository.GetByIdAsync(id);

        if (menu == null)
            return false;

        await _repository.DeleteAsync(menu);

        return true;
    }
}