using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Beliyuk.API.Models;
using Beliyuk2.API.Services.Interfaces;
using Microsoft.IdentityModel.Tokens;

namespace Beliyuk2.API.Services;

public class JwtService : IJwtService
{
    private readonly IHttpContextAccessor _httpContextAccessor;
    private readonly string _secretKey = "temporarily-secret-key-for-jwt-token-generation";

    public JwtService(IHttpContextAccessor httpContextAccessor)
    {
        _httpContextAccessor = httpContextAccessor;
    }

    public string GenerateJwtToken(MsUser user)
    {
        var tokenHandler = new JwtSecurityTokenHandler();
        var key = Encoding.ASCII.GetBytes(_secretKey);

        var tokenDescriptor = new SecurityTokenDescriptor
        {
            Subject = new ClaimsIdentity(new[]
            {
                new Claim(ClaimTypes.NameIdentifier, user.IdUser),
                new Claim(ClaimTypes.Name, user.UserName),
                new Claim(ClaimTypes.Email, user.Email)
            }),
            Expires = DateTime.UtcNow.AddHours(24),
            SigningCredentials = new SigningCredentials(
                new SymmetricSecurityKey(key),
                SecurityAlgorithms.HmacSha256Signature)
        };

        var token = tokenHandler.CreateToken(tokenDescriptor);
        return tokenHandler.WriteToken(token);
    }

    public string ExtractUserIdFromToken(string token)
    {
        try
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_secretKey);

            tokenHandler.ValidateToken(token, new TokenValidationParameters
            {
                ValidateIssuerSigningKey = true,
                IssuerSigningKey = new SymmetricSecurityKey(key),
                ValidateIssuer = false,
                ValidateAudience = false,
                ClockSkew = TimeSpan.FromSeconds(30)
            }, out SecurityToken validatedToken);

            var jwtToken = validatedToken as JwtSecurityToken;
            var userId = jwtToken?.Claims.FirstOrDefault(c => c.Type == "nameid")?.Value;

            if (string.IsNullOrEmpty(userId))
            {
                var availableClaims = string.Join(", ", jwtToken?.Claims.Select(c => $"{c.Type}:{c.Value}") ?? new List<string>());
                throw new UnauthorizedAccessException($"User ID claim not found. Available claims: {availableClaims}");
            }
            
            return userId;
        }
        catch (Exception ex)
        {
            throw new UnauthorizedAccessException("Invalid or expired token", ex);
        }
    }
}