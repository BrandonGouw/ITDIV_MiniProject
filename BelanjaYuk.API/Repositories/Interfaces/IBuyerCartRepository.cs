using Belanjayuk.API.Models.Transaction;

namespace Belanjayuk.API.Repositories.Interfaces;

public interface IBuyerCartRepository {
    public Task<TrBuyerCart?> GetCartByIdBuyerAsync(string idBuyer);
    public Task<TrBuyerCart?> GetCartByIdBuyerCartAsync(string idBuyerCart);
    public Task<List<TrBuyerCart>> GetBuyerCart(string idBuyerCart);
    public Task AddNewCartAsync(TrBuyerCart cart);
    void UpdateCartAsync(TrBuyerCart cart);
    public Task RemoveCartAsync(String buyerCartId);

}