using Belanjayuk.API.DTO.Response;

namespace Belanjayuk.API.Services.Interfaces;

public interface IUserService
{
    Task<UserResponseDto> GetCurrentUserAsync();
    
    Task<UserResponseDto> GetUserByIdAsync(string userId);
    
    Task<UserResponseDto> GetUserFromTokenAsync(string token);
}