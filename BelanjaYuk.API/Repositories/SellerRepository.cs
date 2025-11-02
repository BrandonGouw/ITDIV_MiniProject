using Belanjayuk.API.Data;
using Belanjayuk.API.Models.Master;
using Belanjayuk.API.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Belanjayuk.API.Repositories;

public class SellerRepository : ISellerRepository {
    private readonly BelanjaYuk _dbContext;

    public SellerRepository(BelanjaYuk dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<bool> IsSellerCodeExistsAsync(string sellerCode) {
        return await _dbContext.MsUserSellers.AnyAsync(s => s.SellerCode == sellerCode);
        
    }

    public async Task<bool> IsSellerNameExistsAsync(string sellerName) {
        return await _dbContext.MsUserSellers.AnyAsync(s => s.SellerName == sellerName);
    }
    
    public async Task<bool> IsSellerPhoneExistsAsync(string sellerPhone) {
        return await _dbContext.MsUserSellers.AnyAsync(s => s.PhoneNumber == sellerPhone);
    }

    public async Task AddNewSellerAsync(MsUserSeller seller)
    {
        if (seller == null)
        {
            throw new ArgumentNullException(nameof(seller));
        }
        
        await _dbContext.MsUserSellers.AddAsync(seller);
        await  _dbContext.SaveChangesAsync();
    }

    public async Task<MsUserSeller?> GetSellerByIdUserAsync(string idUser)
    {
         return await _dbContext.MsUserSellers.Include(s=> s.Products).FirstOrDefaultAsync(s => s.IdUser == idUser);
    }

    public async Task<MsUserSeller?> GetSellerByIdSellerAsync(string idSeller)
    {
        return await _dbContext.MsUserSellers.FindAsync(idSeller);
    }
}