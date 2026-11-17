namespace FoodMenuManagementSystem.DTOs.Menu;

public class MenuResponseDto
{
    public int MenuId { get; set; }

    public string MenuName { get; set; } = string.Empty;

    public string? Description { get; set; }

    public bool IsActive { get; set; }
}
