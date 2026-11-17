
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

// FoodItem registrations
builder.Services.AddScoped<IFoodItemRepository, FoodItemRepository>();
builder.Services.AddScoped<IFoodItemService, FoodItemService>();

// Menu registrations
builder.Services.AddScoped<IMenuRepository, MenuRepository>();
builder.Services.AddScoped<IMenuService, MenuService>();

// CORS configuration
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAngular", policy =>
    {
        policy
            .WithOrigins("http://localhost:4200")
            .AllowAnyHeader()
            .AllowAnyMethod();
    });
});

var app = builder.Build();

// Configure HTTP request pipeline
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

// HTTP redirection disabled for local HTTP testing

app.UseRouting();

// Apply CORS policy
app.UseCors("AllowAngular");

app.UseAuthorization();

// Map API controllers
app.MapControllers();

// Start application
app.Run();
