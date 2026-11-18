
namespace FoodMenuManagementSystem.Services.Interfaces;

public interface IJwtTokenService
{
    string GenerateToken(int adminId, string email);
}
