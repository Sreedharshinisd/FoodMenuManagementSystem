
using FoodMenuManagementSystem.Models;
using Microsoft.EntityFrameworkCore;

namespace FoodMenuManagementSystem.Data;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options)
    {
    }

    // FoodItem table
    public DbSet<FoodItem> FoodItems { get; set; }

    // Configure entity properties
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<FoodItem>()
            .Property(f => f.Price)
            .HasPrecision(10, 2);
    }
}
