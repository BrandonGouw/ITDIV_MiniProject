using Belanjayuk.API.Data;
using Belanjayuk.API.Models.Transaction;
using Belanjayuk.API.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Belanjayuk.API.Repositories;

public class BuyerTransactionRepository : IBuyerTransactionRepository
{
    private readonly BelanjaYuk _dbContext;
    
    public BuyerTransactionRepository(BelanjaYuk dbContext)
    {
        _dbContext = dbContext;
    }
    
    public async Task<TrBuyerTransaction?> GetTransactionByIdAsync(string idTransaction)
    {
        return await _dbContext.TrBuyerTransactions
            .Include(t => t.User)
            .Include(t => t.Payment)
            .Include(t => t.Details)
                .ThenInclude(d => d.Product)
            .FirstOrDefaultAsync(t => t.IdBuyerTransaction == idTransaction);
    }
    
    public async Task<List<TrBuyerTransaction>> GetTransactionsByUserIdAsync(string idUser)
    {
        return await _dbContext.TrBuyerTransactions
            .Include(t => t.User)
            .Include(t => t.Payment)
            .Include(t => t.Details)
                .ThenInclude(d => d.Product)
            .Where(t => t.IdUser == idUser)
            .ToListAsync();
    }
    
    public async Task<List<TrBuyerTransaction>> GetAllTransactionsAsync()
    {
        return await _dbContext.TrBuyerTransactions
            .Include(t => t.User)
            .Include(t => t.Payment)
            .Include(t => t.Details)
                .ThenInclude(d => d.Product)
            .ToListAsync();
    }
    
    public async Task AddTransactionAsync(TrBuyerTransaction transaction)
    {
        await _dbContext.TrBuyerTransactions.AddAsync(transaction);
        await _dbContext.SaveChangesAsync();
    }
    
    public void UpdateTransactionAsync(TrBuyerTransaction transaction)
    {
        _dbContext.TrBuyerTransactions.Update(transaction);
    }
    
    public async Task SaveChangesAsync()
    {
        await _dbContext.SaveChangesAsync();
    }
}
