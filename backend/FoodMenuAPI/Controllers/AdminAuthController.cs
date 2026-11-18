
using FoodMenuManagementSystem.Data;
using FoodMenuManagementSystem.DTOs.Admin;
using FoodMenuManagementSystem.Models;
using FoodMenuManagementSystem.Services.Interfaces;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FoodMenuManagementSystem.Controllers;

[Route("api/[controller]")]
[ApiController]
public class AdminAuthController : ControllerBase
{
    private readonly AppDbContext _context;
    private readonly IJwtTokenService _jwtTokenService;
    private readonly PasswordHasher<Admin> _passwordHasher;

    public AdminAuthController(
        AppDbContext context,
        IJwtTokenService jwtTokenService)
    {
        _context = context;
        _jwtTokenService = jwtTokenService;
        _passwordHasher = new PasswordHasher<Admin>();
    }

    [HttpPost("login")]
    public async Task<IActionResult> Login(AdminLoginDto request)
    {
        var admin = await _context.Admins
            .FirstOrDefaultAsync(a => a.Email == request.Email);

        if (admin == null)
        {
            return Unauthorized(new
            {
                message = "Invalid email or password"
            });
        }

        var result = _passwordHasher.VerifyHashedPassword(
            admin,
            admin.PasswordHash,
            request.Password);

        if (result == PasswordVerificationResult.Failed)
        {
            return Unauthorized(new
            {
                message = "Invalid email or password"
            });
        }

        var token = _jwtTokenService.GenerateToken(
            admin.AdminId,
            admin.Email);

        return Ok(new
        {
            message = "Login successful",
            token = token,
            email = admin.Email
        });
    }
}
