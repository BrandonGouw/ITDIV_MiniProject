using Belanjayuk.API.DTO.Request;
using Belanjayuk.API.DTO.Response;
using Belanjayuk.API.Models.Master;

namespace Belanjayuk.API.Services.Interfaces;

public interface IProductService
{
    Task<ProductResponseDto> GetProductAsync(String productID);
    Task<ProductsResponseDto> GetAllProductsOnPage(ProductRequestDto productRequestDto);
    
    Task<IEnumerable<MsProduct>> GetAllProducts();
    
    Task<ProductResponseDto> CreateProductAsync(ProductCreationRequestDto productRequestDto);
}