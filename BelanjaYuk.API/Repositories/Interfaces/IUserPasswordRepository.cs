using Beliyuk.API.Models;

namespace Beliyuk2.API.Repositories.Interfaces;

// Repositories/Interfaces/IUserPasswordRepository.cs
public interface IUserPasswordRepository {
    Task<MsUserPassword?> GetActivePasswordByUserIdAsync(string userId);
    Task CreateAsync(MsUserPassword userPassword);
}