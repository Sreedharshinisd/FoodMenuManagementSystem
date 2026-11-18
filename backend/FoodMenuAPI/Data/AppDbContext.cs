
using FoodMenuManagementSystem.Models;
using Microsoft.EntityFrameworkCore;

namespace FoodMenuManagementSystem.Data;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options)
    {
    }

    public DbSet<FoodItem> FoodItems { get; set; }

    public DbSet<Menu> Menus { get; set; }

    public DbSet<Customer> Customers { get; set; }

    public DbSet<Admin> Admins { get; set; }
}
