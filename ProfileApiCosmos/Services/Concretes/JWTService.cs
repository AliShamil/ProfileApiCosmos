using System.Security.Claims;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Text;
using System.Data;
using ProfileApiCosmos.Services.Interfaces;
using ProfileApiCosmos.Models;

namespace ProfileApiCosmos.Services.Concretes
{
    public class JWTService : IJWTService
    {
        private readonly JWTConfig _config;

        public JWTService(JWTConfig config)
        {
            _config = config;
        }

        public string GenerateSecurityToken(string id, string email)
        {
            var claims = new[]
 {
            new Claim(ClaimTypes.Email, email),
            new Claim("userId", id),

        };
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config.Secret));

            var signingCredentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                issuer: _config.Issuer,
                audience: _config.Audience,
                expires: DateTime.UtcNow.AddMinutes(_config.ExpireMunites),
                signingCredentials: signingCredentials,
                claims: claims
                );

            var accessToken = new JwtSecurityTokenHandler().WriteToken(token);

            return accessToken;
        }
    }
}
