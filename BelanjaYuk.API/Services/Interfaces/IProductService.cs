using Beliyuk.API.Models;
using Beliyuk2.API.DTO.Request;
using Beliyuk2.API.DTO.Response;

namespace Beliyuk2.API.Services.Interfaces;

public interface IProductService
{
    Task<ProductResponseDto> GetProductAsync(String productID);
    Task<ProductsResponseDto> GetAllProductsOnPage(ProductRequestDto productRequestDto);
    
    Task<IEnumerable<MsProduct>> GetAllProducts();
}