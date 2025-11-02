using Belanjayuk.API.DTO.Request;
using Belanjayuk.API.DTO.Response;

namespace Belanjayuk.API.Services.Interfaces;

public interface ISellerService 
{
    public Task<bool> IsSellerCodeExistsAsync(string sellerCode);
    public Task<bool> IsSellerNameExistsAsync(string sellerName);
    public Task<bool> IsSellerPhoneExistsAsync(string sellerPhone);
    public Task<SellerResponseDto> AddNewSellerAsync(NewSellerRequestDto newSellerRequestDto);
    public Task<SellerResponseDto?> GetSellerByIdUserAsync(string idUser);
    public Task<SellerResponseDto?> GetSellerByIdSellerAsync(string idSeller);
    
    public Task<List<ProductResponseDto?>> GetSellerProductByIdSellerAsync(string idSeller);
    
}