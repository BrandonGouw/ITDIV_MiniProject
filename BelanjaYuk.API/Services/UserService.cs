using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using Beliyuk.API.Data;
using Beliyuk.API.Models;
using Beliyuk2.API.DTO.Response;
using Beliyuk2.API.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Beliyuk2.API.Services;

public class UserService : IUserService {
    private readonly IUserRepository _userRepository;
    private readonly IHttpContextAccessor _httpContextAccessor;
    private readonly IJwtService _jwtService;

    public UserService(IUserRepository userRepository, IHttpContextAccessor httpContextAccessor, IJwtService jwtService)
    {
        _userRepository = userRepository;
        _httpContextAccessor = httpContextAccessor;
        _jwtService = jwtService;
    }

    public async Task<UserResponseDto> GetCurrentUserAsync()
    {
        var userId = _httpContextAccessor.HttpContext?.User
            .FindFirst(ClaimTypes.NameIdentifier)?.Value;

        if (string.IsNullOrEmpty(userId))
            throw new UnauthorizedAccessException("User not authenticated");

        var msUser = await _userRepository.GetByIdAsync(userId);
        
        return MsUserToDto(msUser);
    }
    
    public async Task<UserResponseDto> GetUserByIdAsync(string userId)
    {
        var msUser = await _userRepository.GetByIdAsync(userId);
        
        if(msUser == null) 
            throw new KeyNotFoundException("User not found");
        
        return MsUserToDto(msUser);
    }

    public async Task<UserResponseDto> GetUserFromTokenAsync(string token)
    {
        var extractUserIdFromToken = _jwtService.ExtractUserIdFromToken(token);
        var msUser =  await _userRepository.GetByIdAsync(extractUserIdFromToken);
        
        if(msUser == null) 
            throw new KeyNotFoundException("User not found");
        
        return MsUserToDto(msUser);
    }

    public UserResponseDto MsUserToDto(MsUser user)
    {
        return new UserResponseDto
        {
            UserId = user.IdUser,
            Username = user.UserName,
            Email = user.Email,
            FirstName = user.FirstName,
            LastName = user.LastName,
            PhoneNumber = user.PhoneNumber,
            DateOfBirth = user.DOB,
            
            IsActive = user.IsActive,
            // Gender logic needs to be added after repo is added
            Gender = user.LtGender?.GenderName ?? "Not specified"

        };
    }
}