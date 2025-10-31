using Beliyuk.API.Models;

public interface IUserRepository
{
    Task<MsUser?> GetByIdAsync(String id);
    Task<MsUser?> GetByUsernameAsync(string username);
    Task<MsUser?> GetByEmailAsync(string email);
    Task<IEnumerable<MsUser>> GetAllAsync();
    Task<MsUser> CreateAsync(MsUser user);
    Task UpdateAsync(MsUser user);
    Task DeleteAsync(String id);
    Task<bool> UsernameExistsAsync(string username);
    Task<bool> EmailExistsAsync(string email);
    
    Task<bool> PhoneNumberExistsAsync(string phoneNumber);
    
    Task<MsUser?> GetByCredentialAsync(string credential); // email or phone
    Task<bool> ExistsByEmailOrPhoneAsync(string email, string phoneNumber);
    
}