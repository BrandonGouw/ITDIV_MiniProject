using Belanjayuk.API.Models.Transaction;

namespace Belanjayuk.API.Repositories.Interfaces;

public interface IProductImageRepository
{
    public Task<TrProductImages?> GetProductImageByIdAsync(string idProductImage);
    public Task<List<TrProductImages>> GetProductImagesByProductIdAsync(string idProduct);
    public Task<List<TrProductImages>> GetAllProductImagesAsync();
    public Task AddProductImageAsync(TrProductImages productImage);
    public void UpdateProductImageAsync(TrProductImages productImage);
    public Task DeleteProductImageAsync(string idProductImage);
    public Task SaveChangesAsync();
}
