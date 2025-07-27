using System.Security.Claims;

namespace Ecom.Core.Services
{
    public interface IJwtService
    {
        string GenerateToken(string userId, string email, string role);
        ClaimsPrincipal ValidateToken(string token);
        string GetUserIdFromToken(string token);
    }
}