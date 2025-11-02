using Belanjayuk.API.Data;
using Belanjayuk.API.Models.Transaction;
using Belanjayuk.API.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Belanjayuk.API.Repositories;

public class ProductImageRepository : IProductImageRepository
{
    private readonly BelanjaYuk _dbContext;
    
    public ProductImageRepository(BelanjaYuk dbContext)
    {
        _dbContext = dbContext;
    }
    
    public async Task<TrProductImages?> GetProductImageByIdAsync(string idProductImage)
    {
        return await _dbContext.TrProductImages
            .Include(pi => pi.Product)
            .FirstOrDefaultAsync(pi => pi.IdProductImage == idProductImage);
    }
    
    public async Task<List<TrProductImages>> GetProductImagesByProductIdAsync(string idProduct)
    {
        return await _dbContext.TrProductImages
            .Include(pi => pi.Product)
            .Where(pi => pi.IdProduct == idProduct)
            .ToListAsync();
    }
    
    public async Task<List<TrProductImages>> GetAllProductImagesAsync()
    {
        return await _dbContext.TrProductImages
            .Include(pi => pi.Product)
            .ToListAsync();
    }
    
    public async Task AddProductImageAsync(TrProductImages productImage)
    {
        await _dbContext.TrProductImages.AddAsync(productImage);
        await _dbContext.SaveChangesAsync();
    }
    
    public void UpdateProductImageAsync(TrProductImages productImage)
    {
        _dbContext.TrProductImages.Update(productImage);
    }
    
    public async Task DeleteProductImageAsync(string idProductImage)
    {
        var productImage = await _dbContext.TrProductImages.FindAsync(idProductImage);
        if (productImage == null)
        {
            throw new KeyNotFoundException("Product image not found");
        }
        
        _dbContext.TrProductImages.Remove(productImage);
        await _dbContext.SaveChangesAsync();
    }
    
    public async Task SaveChangesAsync()
    {
        await _dbContext.SaveChangesAsync();
    }
}
