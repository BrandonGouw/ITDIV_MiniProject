using Belanjayuk.API.DTO.Request;
using Belanjayuk.API.DTO.Response;
using Belanjayuk.API.Models.Transaction;
using Belanjayuk.API.Repositories.Interfaces;
using Belanjayuk.API.Services.Interfaces;

namespace Belanjayuk.API.Services;

public class ProductImageService : IProductImageService
{
    private readonly IProductImageRepository _productImageRepository;
    
    public ProductImageService(IProductImageRepository productImageRepository)
    {
        _productImageRepository = productImageRepository;
    }
    
    public async Task<ProductImageResponseDto> CreateProductImageAsync(ProductImageRequestDto requestDto)
    {
        var productImage = new TrProductImages
        {
            IdProductImage = Guid.NewGuid().ToString(),
            IdProduct = requestDto.IdProduct,
            ProductImage = requestDto.ProductImage,
            DateIn = DateTime.UtcNow,
            UserIn = "SYSTEM",
            DateUp = DateTime.UtcNow,
            UserUp = "SYSTEM",
            IsActive = true
        };
        
        await _productImageRepository.AddProductImageAsync(productImage);
        
        return await GetProductImageByIdAsync(productImage.IdProductImage);
    }
    
    public async Task<ProductImageResponseDto> GetProductImageByIdAsync(string idProductImage)
    {
        var productImage = await _productImageRepository.GetProductImageByIdAsync(idProductImage);
        
        if (productImage == null)
            throw new Exception("Product image not found");
        
        return ConvertToResponseDto(productImage);
    }
    
    public async Task<List<ProductImageResponseDto>> GetProductImagesByProductIdAsync(string idProduct)
    {
        var productImages = await _productImageRepository.GetProductImagesByProductIdAsync(idProduct);
        
        return productImages.Select(pi => ConvertToResponseDto(pi)).ToList();
    }
    
    public async Task<List<ProductImageResponseDto>> GetAllProductImagesAsync()
    {
        var productImages = await _productImageRepository.GetAllProductImagesAsync();
        
        return productImages.Select(pi => ConvertToResponseDto(pi)).ToList();
    }
    
    public async Task<bool> UpdateProductImageAsync(string idProductImage, ProductImageRequestDto requestDto)
    {
        var productImage = await _productImageRepository.GetProductImageByIdAsync(idProductImage);
        
        if (productImage == null)
            throw new Exception("Product image not found");
        
        productImage.IdProduct = requestDto.IdProduct;
        productImage.ProductImage = requestDto.ProductImage;
        productImage.DateUp = DateTime.UtcNow;
        productImage.UserUp = "SYSTEM";
        
        _productImageRepository.UpdateProductImageAsync(productImage);
        await _productImageRepository.SaveChangesAsync();
        
        return true;
    }
    
    public async Task<bool> DeleteProductImageAsync(string idProductImage)
    {
        await _productImageRepository.DeleteProductImageAsync(idProductImage);
        return true;
    }
    
    private ProductImageResponseDto ConvertToResponseDto(TrProductImages productImage)
    {
        return new ProductImageResponseDto
        {
            IdProductImage = productImage.IdProductImage,
            IdProduct = productImage.IdProduct,
            ProductName = productImage.Product?.ProductName ?? string.Empty,
            ProductImage = productImage.ProductImage,
            DateIn = productImage.DateIn,
            IsActive = productImage.IsActive
        };
    }
}
