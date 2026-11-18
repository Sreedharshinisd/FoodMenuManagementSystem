
using System.ComponentModel.DataAnnotations;

namespace FoodMenuManagementSystem.DTOs.Admin;

public class AdminLoginDto
{
    [Required]
    [EmailAddress]
    public string Email { get; set; } = string.Empty;

    [Required]
    public string Password { get; set; } = string.Empty;
}
