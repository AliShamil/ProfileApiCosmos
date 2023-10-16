using System.Security.Claims;

namespace ProfileApiCosmos.Services.Interfaces
{
    public interface IJWTService
    {
        string GenerateSecurityToken(string id, string email);
    }
}
