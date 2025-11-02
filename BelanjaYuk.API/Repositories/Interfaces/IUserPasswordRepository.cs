using Belanjayuk.API.Models.Master;

namespace Belanjayuk.API.Repositories.Interfaces;

// Repositories/Interfaces/IUserPasswordRepository.cs
public interface IUserPasswordRepository {
    Task<MsUserPassword?> GetActivePasswordByUserIdAsync(string userId);
    Task CreateAsync(MsUserPassword userPassword);
}