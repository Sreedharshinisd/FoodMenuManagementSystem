
using FoodMenuManagementSystem.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace FoodMenuManagementSystem.Data;

public static class AdminSeeder
{
    public static async Task SeedAdminAsync(
        AppDbContext context,
        IConfiguration configuration)
    {
        var email = configuration["Admin:Email"];
        var password = configuration["Admin:Password"];

        if (string.IsNullOrWhiteSpace(email) ||
            string.IsNullOrWhiteSpace(password))
        {
            throw new InvalidOperationException(
                "Admin credentials are missing from configuration.");
        }

        var existingAdmin = await context.Admins
            .FirstOrDefaultAsync(a => a.Email == email);

        if (existingAdmin != null)
            return;

        var admin = new Admin
        {
            Email = email
        };

        var passwordHasher = new PasswordHasher<Admin>();

        admin.PasswordHash = passwordHasher.HashPassword(
            admin, password);

        context.Admins.Add(admin);

        await context.SaveChangesAsync();
    }
}
