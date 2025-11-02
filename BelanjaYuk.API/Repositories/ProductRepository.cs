using Belanjayuk.API.Data;
using Belanjayuk.API.DTO.Request;
using Belanjayuk.API.Models.Master;
using Belanjayuk.API.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Belanjayuk.API.Repositories;

public class ProductRepository : IProductRepository
{
    private BelanjaYuk _dbContext;

    public ProductRepository(BelanjaYuk dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<MsProduct> GetProduct(string productId)
    {
        var msProduct = await _dbContext.MsProducts.FirstOrDefaultAsync(p => p.IdProduct == productId);

        if (msProduct == null) throw new KeyNotFoundException("Product not found");

        return msProduct;
    }

    public Task<MsProduct?> GetByIdAsync(string id)
    {
        return _dbContext.MsProducts.FirstOrDefaultAsync(p => p.IdProduct == id);
    }

    public async Task<IEnumerable<MsProduct>> GetAllProductsAsync()
    {
        var msProducts = await _dbContext.MsProducts.ToListAsync();
        
        return msProducts;
    }

    public async Task<IEnumerable<MsProduct>> GetProductBasedFilters(ProductRequestDto productRequestDto) {
        var query = _dbContext.MsProducts.AsQueryable();
        
        if (!string.IsNullOrEmpty(productRequestDto.Search))
        {
            query = query.Where(p => p.ProductName.Contains(productRequestDto.Search) 
                                  || p.ProductDesc.Contains(productRequestDto.Search));
        }
        
        if (!string.IsNullOrEmpty(productRequestDto.Category))
        {
            query = query.Where(p => p.Category.CategoryName == productRequestDto.Category);
        }
        
        var products = await query
            .Skip((productRequestDto.CurrentPage - 1) * productRequestDto.PageSize)
            .Take(productRequestDto.PageSize)
            .ToListAsync();

        return products;
    }

    public async Task CreateProductAsync(MsProduct product)
    {
        await _dbContext.MsProducts.AddAsync(product);
        await _dbContext.SaveChangesAsync();
        
    }

    public async Task UpdateProductAsync(MsProduct product) {
        _dbContext.Update(product);
        await _dbContext.SaveChangesAsync();
    }

    public async Task DeleteProductAsync(string productId)
    {
        var product = await _dbContext.MsProducts.FirstOrDefaultAsync(p => p.IdProduct == productId);
        
        if(product == null) throw new KeyNotFoundException("Product not found");

        _dbContext.MsProducts.Remove(product);
        await _dbContext.SaveChangesAsync();
    }

    public async Task<bool> ProductExistsAsync(string productId)
    {
        return await _dbContext.MsProducts.AnyAsync(p => p.IdProduct == productId);
    }
}