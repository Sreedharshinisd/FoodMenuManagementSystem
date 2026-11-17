using FoodMenuManagementSystem.Data;
using FoodMenuManagementSystem.Models;
using FoodMenuManagementSystem.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace FoodMenuManagementSystem.Repositories;

public class FoodItemRepository : IFoodItemRepository
{
    private readonly AppDbContext _context;

    public FoodItemRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<List<FoodItem>> GetAllAsync()
    {
        return await _context.FoodItems
            .AsNoTracking()
            .ToListAsync();
    }

    public async Task<FoodItem?> GetByIdAsync(int id)
    {
        return await _context.FoodItems.FindAsync(id);
    }

    public async Task AddAsync(FoodItem foodItem)
    {
        await _context.FoodItems.AddAsync(foodItem);
        await _context.SaveChangesAsync();
    }

    public async Task UpdateAsync(FoodItem foodItem)
    {
        _context.FoodItems.Update(foodItem);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteAsync(FoodItem foodItem)
    {
        _context.FoodItems.Remove(foodItem);
        await _context.SaveChangesAsync();
    }
}