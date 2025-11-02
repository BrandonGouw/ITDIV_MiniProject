using Belanjayuk.API.Models.Transaction;

namespace Belanjayuk.API.Repositories.Interfaces;

public interface IAddressRepository {
    
    public Task<TrHomeAddress?> GetByUserIdAsync(String userId);
    public Task<TrHomeAddress> CreateAsync(TrHomeAddress address);
    public Task UpdateAsync(TrHomeAddress address);
    public Task DeleteAsync(String id);
    
}