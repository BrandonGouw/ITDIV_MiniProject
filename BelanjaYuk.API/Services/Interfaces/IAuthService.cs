using Belanjayuk.API.DTO.Request;
using Belanjayuk.API.DTO.Response;

namespace Belanjayuk.API.Services.Interfaces;

public interface IAuthService
{
    Task<AuthResponseDto> RegisterAsync(RegisterRequestDto registerRequestDto);
    Task<AuthResponseDto> LoginAsync(LoginRequestDto loginRequestDto);
}