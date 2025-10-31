using Beliyuk2.API.DTO.Response;

namespace Beliyuk2.API.Services.Interfaces;

public interface IUserService
{
    Task<UserResponseDto> GetCurrentUserAsync();
    
    Task<UserResponseDto> GetUserByIdAsync(string userId);
    
    Task<UserResponseDto> GetUserFromTokenAsync(string token);
}