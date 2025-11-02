using Belanjayuk.API.DTO.Request;
using Belanjayuk.API.DTO.Response;

namespace Belanjayuk.API.Services.Interfaces;

public interface IProductImageService
{
    public Task<ProductImageResponseDto> CreateProductImageAsync(ProductImageRequestDto requestDto);
    public Task<ProductImageResponseDto> GetProductImageByIdAsync(string idProductImage);
    public Task<List<ProductImageResponseDto>> GetProductImagesByProductIdAsync(string idProduct);
    public Task<List<ProductImageResponseDto>> GetAllProductImagesAsync();
    public Task<bool> UpdateProductImageAsync(string idProductImage, ProductImageRequestDto requestDto);
    public Task<bool> DeleteProductImageAsync(string idProductImage);
}
