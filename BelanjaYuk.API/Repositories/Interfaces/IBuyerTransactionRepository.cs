using Belanjayuk.API.Models.Transaction;

namespace Belanjayuk.API.Repositories.Interfaces;

public interface IBuyerTransactionRepository
{
    public Task<TrBuyerTransaction?> GetTransactionByIdAsync(string idTransaction);
    public Task<List<TrBuyerTransaction>> GetTransactionsByUserIdAsync(string idUser);
    public Task<List<TrBuyerTransaction>> GetAllTransactionsAsync();
    public Task AddTransactionAsync(TrBuyerTransaction transaction);
    public void UpdateTransactionAsync(TrBuyerTransaction transaction);
    public Task SaveChangesAsync();
}
