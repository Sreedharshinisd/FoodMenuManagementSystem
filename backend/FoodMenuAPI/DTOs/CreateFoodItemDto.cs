using System.ComponentModel.DataAnnotations;

namespace FoodMenuManagementSystem.DTOs.FoodItem;

public class CreateFoodItemDto
{
    [Required]
    [StringLength(100)]
    public string FoodName { get; set; } = string.Empty;

    [StringLength(500)]
    public string? Description { get; set; }

    [Range(0.01, 999999)]
    public decimal Price { get; set; }

    public string? ImageUrl { get; set; }
}