using Belanjayuk.API.Models.Master;

namespace Belanjayuk.API.Services.Interfaces;

public interface IJwtService
{
    public string GenerateJwtToken(MsUser user);
    public string ExtractUserIdFromToken(string token);

}