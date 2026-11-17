using System.ComponentModel.DataAnnotations;

namespace FoodMenuManagementSystem.Models;

public class FoodItem
{
    public int FoodItemId { get; set; }

    [Required]
    [StringLength(100)]
    public string FoodName { get; set; } = string.Empty;

    [StringLength(500)]
    public string? Description { get; set; }

    [Range(0.01, 999999)]
    public decimal Price { get; set; }

    public string? ImageUrl { get; set; }

    public bool IsAvailable { get; set; } = true;
}