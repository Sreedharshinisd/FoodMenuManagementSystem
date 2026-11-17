namespace FoodMenuManagementSystem.DTOs.FoodItem;

public class FoodItemResponseDto
{
    public int FoodItemId { get; set; }

    public string FoodName { get; set; } = string.Empty;

    public string? Description { get; set; }

    public decimal Price { get; set; }

    public string? ImageUrl { get; set; }

    public bool IsAvailable { get; set; }
}