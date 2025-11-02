using Belanjayuk.API.Data;
using Belanjayuk.API.Models.Transaction;
using Belanjayuk.API.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Belanjayuk.API.Repositories;

public class AddressRepository : IAddressRepository {
    private readonly BelanjaYuk _dbContext;

    public AddressRepository(BelanjaYuk dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<TrHomeAddress?> GetByUserIdAsync(string userId)
    {
        var homeAddress = await _dbContext.TrHomeAddresses.FirstOrDefaultAsync(h => h.IdUser == userId);
        return homeAddress;
    }

    public async Task<TrHomeAddress> CreateAsync(TrHomeAddress address)
    {
        var addedAddress = await _dbContext.TrHomeAddresses.AddAsync(address);
        return addedAddress.Entity;
    }

    public Task UpdateAsync(TrHomeAddress address)
    {
        throw new NotImplementedException();
    }

    public Task DeleteAsync(string id)
    {
        throw new NotImplementedException();
    }
}