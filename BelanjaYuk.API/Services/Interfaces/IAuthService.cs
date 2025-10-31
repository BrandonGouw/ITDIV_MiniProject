using Beliyuk2.API.DTO.Request;
using Beliyuk2.API.DTO.Response;

public interface IAuthService
{
    Task<AuthResponseDto> RegisterAsync(RegisterRequestDto registerRequestDto);
    Task<AuthResponseDto> LoginAsync(LoginRequestDto loginRequestDto);
}