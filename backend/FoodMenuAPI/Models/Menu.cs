
namespace FoodMenuManagementSystem.Models;

public class Menu
{
    public int MenuId { get; set; }

    public string MenuName { get; set; } = string.Empty;

    public string? Description { get; set; }

    public bool IsActive { get; set; } = true;
}
