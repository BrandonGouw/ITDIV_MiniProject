using Belanjayuk.API.Data;
using Belanjayuk.API.Models.Transaction;
using Belanjayuk.API.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Belanjayuk.API.Repositories;

public class BuyerCartRepository : IBuyerCartRepository
{
    private readonly BelanjaYuk _dbContext;
    
    public BuyerCartRepository(BelanjaYuk dbContext)
    {
        _dbContext = dbContext;
    }
    
    public async Task<TrBuyerCart?> GetCartByIdBuyerAsync(string idBuyer) {
        return await _dbContext.TrBuyerCarts.FirstOrDefaultAsync(c => c.IdUser == idBuyer); 
    }
    
    public async Task<List<TrBuyerCart>> GetBuyerCart(string idBuyer)
    {
        return await _dbContext.TrBuyerCarts
            .Where(c => c.IdUser == idBuyer)
            .ToListAsync();
    }

    public async Task<TrBuyerCart?> GetCartByIdBuyerCartAsync(string idBuyerCart)
    {
        return await _dbContext.TrBuyerCarts.FindAsync(idBuyerCart);
    }

    public async Task AddNewCartAsync(TrBuyerCart cart) {
        await _dbContext.TrBuyerCarts.AddAsync(cart);
        await _dbContext.SaveChangesAsync();
    }

    public void UpdateCartAsync(TrBuyerCart cart) {
        _dbContext.TrBuyerCarts.Update(cart);
    }
    
    public async Task RemoveCartAsync(String cartId) {
        var cart = await _dbContext.TrBuyerCarts.FindAsync(cartId);
        if (cart == null) {
            throw new KeyNotFoundException("Cart not found");
        }
        
        
        _dbContext.TrBuyerCarts.Remove(cart);
        await _dbContext.SaveChangesAsync();
    }
}