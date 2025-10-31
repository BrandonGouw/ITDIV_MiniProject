using Beliyuk.API.Models;

namespace Beliyuk2.API.Services.Interfaces;

public interface IJwtService
{
    public string GenerateJwtToken(MsUser user);
    public string ExtractUserIdFromToken(string token);

}