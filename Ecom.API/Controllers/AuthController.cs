using Ecom.API.Helper;
using Ecom.Core.Services;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace Ecom.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IJwtService _jwtService;

        public AuthController(IJwtService jwtService)
        {
            _jwtService = jwtService;
        }

        [HttpPost("login")]
        public IActionResult Login([FromBody] LoginDto loginDto)
        {
            try
            {
                // TODO: Implement actual user authentication logic
                // For now, we'll use a simple check
                if (loginDto.Email == "admin@ecom.com" && loginDto.Password == "admin123")
                {
                    var token = _jwtService.GenerateToken("1", loginDto.Email, "Admin");
                    return Ok(new ResponsAPI(200, "Login successful", new { Token = token }));
                }

                return Unauthorized(new ResponsAPI(401, "Invalid credentials"));
            }
            catch (Exception ex)
            {
                return BadRequest(new ResponsAPI(400, ex.Message));
            }
        }

        [HttpPost("register")]
        public IActionResult Register([FromBody] RegisterDto registerDto)
        {
            try
            {
                // TODO: Implement actual user registration logic
                var token = _jwtService.GenerateToken("1", registerDto.Email, "User");
                return Ok(new ResponsAPI(200, "Registration successful", new { Token = token }));
            }
            catch (Exception ex)
            {
                return BadRequest(new ResponsAPI(400, ex.Message));
            }
        }
    }

    public record LoginDto
    {
        [Required(ErrorMessage = "Email is required")]
        [EmailAddress(ErrorMessage = "Invalid email format")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Password is required")]
        [MinLength(6, ErrorMessage = "Password must be at least 6 characters")]
        public string Password { get; set; }
    }

    public record RegisterDto
    {
        [Required(ErrorMessage = "Name is required")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Email is required")]
        [EmailAddress(ErrorMessage = "Invalid email format")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Password is required")]
        [MinLength(6, ErrorMessage = "Password must be at least 6 characters")]
        public string Password { get; set; }
    }
}