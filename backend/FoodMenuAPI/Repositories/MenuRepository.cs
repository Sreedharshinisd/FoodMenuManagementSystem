
using FoodMenuManagementSystem.Data;
using FoodMenuManagementSystem.Models;
using FoodMenuManagementSystem.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace FoodMenuManagementSystem.Repositories;

public class MenuRepository : IMenuRepository
{
    private readonly AppDbContext _context;

    public MenuRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<List<Menu>> GetAllAsync()
    {
        return await _context.Menus.ToListAsync();
    }

    public async Task<Menu?> GetByIdAsync(int id)
    {
        return await _context.Menus.FindAsync(id);
    }

    public async Task AddAsync(Menu menu)
    {
        await _context.Menus.AddAsync(menu);
        await _context.SaveChangesAsync();
    }

    public async Task UpdateAsync(Menu menu)
    {
        _context.Menus.Update(menu);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteAsync(Menu menu)
    {
        _context.Menus.Remove(menu);
        await _context.SaveChangesAsync();
    }
}
