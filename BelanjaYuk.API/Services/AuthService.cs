using Beliyuk.API.Data;
using Beliyuk.API.Models;
using Beliyuk2.API.DTO.Request;
using Beliyuk2.API.Repositories.Interfaces;
using Beliyuk2.API.Services;
using Beliyuk2.API.Services.Interfaces;

public class AuthService : IAuthService
{
    private readonly BelanjaYuk _dbContext; // Keep for transactions
    private readonly IUserRepository _userRepository;
    private readonly IUserPasswordRepository _userPasswordRepository;
    private readonly PasswordHelper _passwordHelper;
    private readonly IJwtService _jwtService;

    public AuthService(BelanjaYuk dbContext, IUserRepository userRepository, IUserPasswordRepository userPasswordRepository, PasswordHelper passwordHelper, IJwtService jwtService)
    {
        _dbContext = dbContext;
        _userRepository = userRepository;
        _userPasswordRepository = userPasswordRepository;
        _passwordHelper = passwordHelper;
        _jwtService = jwtService;
    }

    public async Task<AuthResponseDto> RegisterAsync(RegisterRequestDto registerRequestDto)
    {
        await ValidateUserDoesNotExist(registerRequestDto.Email, registerRequestDto.PhoneNumber);
        
        using var transaction = await _dbContext.Database.BeginTransactionAsync();
        try
        {
            var newUser = await CreateUser(registerRequestDto);
            await CreateUserPassword(newUser.IdUser, registerRequestDto.Password);
            await transaction.CommitAsync();
            return CreateAuthResponse(newUser);
        }
        catch
        {
            await transaction.RollbackAsync();
            throw;
        }
    }

    public async Task<AuthResponseDto> LoginAsync(LoginRequestDto loginRequestDto)
    {
        var user = await GetUserByCredential(loginRequestDto.LoginCredential);
        await ValidateUserPassword(user.IdUser, loginRequestDto.Password);
        return CreateAuthResponse(user);
    }

    private async Task ValidateUserDoesNotExist(string email, string phoneNumber)
    {
        if (await _userRepository.ExistsByEmailOrPhoneAsync(email, phoneNumber))
        {
            throw new InvalidOperationException("User with given email or phone number already exists.");
        }
    }

    private async Task<MsUser> CreateUser(RegisterRequestDto dto)
    {
        var newUser = new MsUser
        {
            IdUser = Guid.NewGuid().ToString(),
            FirstName = dto.FirstName,
            LastName = dto.LastName,
            Email = dto.Email.ToLower(),
            PhoneNumber = dto.PhoneNumber,
            IdGender = dto.IdGender,
            UserName = dto.UserName,
            DOB = dto.DOB,
            UserIn = "SYSTEM",
            UserUp = "SYSTEM",
            DateUp = DateTime.UtcNow,
            DateIn = DateTime.UtcNow,
            
            IsActive = true,
        };

        await _userRepository.CreateAsync(newUser);
        return newUser;
    }

    private async Task CreateUserPassword(string userId, string password)
    {
        var hashedPass = _passwordHelper.HashPassword(password);
        var newUserPassword = new MsUserPassword
        {
            IdUserPassword = Guid.NewGuid().ToString(),
            IdUser = userId,
            PasswordHash = hashedPass,
            UserIn = "SYSTEM",
            UserUp = "SYSTEM",
            DateUp = DateTime.UtcNow,
            DateIn = DateTime.UtcNow,
            IsActive = true
        };

        await _userPasswordRepository.CreateAsync(newUserPassword);
    }

    private async Task<MsUser> GetUserByCredential(string credential)
    {
        var user = await _userRepository.GetByCredentialAsync(credential);
        if (user == null)
            throw new InvalidOperationException("User not found with the given credential.");
        return user;
    }

    private async Task ValidateUserPassword(string userId, string password)
    {
        var userPassword = await _userPasswordRepository.GetActivePasswordByUserIdAsync(userId);
        
        if (userPassword == null || !_passwordHelper.VerifyPassword(password, userPassword.PasswordHash))
        {
            throw new InvalidOperationException("Invalid password.");
        }
    }

    private AuthResponseDto CreateAuthResponse(MsUser user)
    {
        return new AuthResponseDto
        {
            Token = _jwtService.GenerateJwtToken(user),
            UserId = user.IdUser,
            Username = user.UserName
        };
    }
}