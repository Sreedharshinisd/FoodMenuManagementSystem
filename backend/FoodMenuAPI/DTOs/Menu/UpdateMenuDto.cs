
namespace FoodMenuManagementSystem.DTOs.Menu;

public class UpdateMenuDto
{
    public string MenuName { get; set; } = string.Empty;

    public string? Description { get; set; }

    public bool IsActive { get; set; }
}
