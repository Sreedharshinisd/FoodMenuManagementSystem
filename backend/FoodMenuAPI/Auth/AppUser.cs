
using Microsoft.AspNetCore.Identity;

namespace FoodMenuManagementSystem.Auth;

public class AppUser : IdentityUser
{
    public string FullName { get; set; } = string.Empty;
}
