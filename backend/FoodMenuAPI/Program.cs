
using FoodMenuManagementSystem.Data;
using FoodMenuManagementSystem.Repositories;
using FoodMenuManagementSystem.Repositories.Interfaces;
using FoodMenuManagementSystem.Services;
using FoodMenuManagementSystem.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services
builder.Services.AddControllers();
builder.Services.AddOpenApi();

// Database connection
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(
        builder.Configuration.GetConnectionString("DefaultConnection")));

// Repository registration
builder.Services.AddScoped<IFoodItemRepository, FoodItemRepository>();

// Service registration
builder.Services.AddScoped<IFoodItemService, FoodItemService>();

var app = builder.Build();

// Configure HTTP request pipeline
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

app.Run();
