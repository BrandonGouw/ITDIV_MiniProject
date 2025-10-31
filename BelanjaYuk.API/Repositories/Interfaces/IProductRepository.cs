using Beliyuk.API.Models;
using Beliyuk2.API.DTO.Request;

namespace Beliyuk2.API.Repositories.Interfaces;

public interface IProductRepository  {
    public Task<MsProduct> GetProduct(string productId);
    
    public Task<MsProduct?> GetByIdAsync(string id);
    
    public Task<IEnumerable<MsProduct>> GetAllProductsAsync();
    
    public Task<IEnumerable<MsProduct>> GetProductBasedFilters(ProductRequestDto productRequestDto);
    
    public Task CreateProductAsync(MsProduct product);
    
    public Task UpdateProductAsync(MsProduct product);
    
    public Task DeleteProductAsync(string productId);
    
    public Task<bool> ProductExistsAsync(string productId);

}